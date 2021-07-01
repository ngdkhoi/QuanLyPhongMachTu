using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.IO;
using System.Data.Entity;
using QuanLyPhongMachTu.Model;
using System.Windows;
using System.Windows.Controls;

namespace QuanLyPhongMachTu.ViewModel
{
    public class PatientListViewModel : BaseViewModel
    {
        //private ObservableCollection<Patient> _Patients = new ObservableCollection<Patient>();
        private DateTime _Date;
        private string _HoTen;
        private string _GioiTinh;
        private int _NamSinh;
        private string _DiaChi;
        private string _SellectedEle;
        public DateTime Date { get => _Date;  set { _Date = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        private void InitialAddCommand()
        {
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (HoTen.Length < 0 || GioiTinh.Length < 0 || NamSinh < 1000 || NamSinh > DateTime.Now.Year || DiaChi.Length < 5)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                BenhNhan newPatient = AddNewPatientToDB();
                PatientList.Add(newPatient);
                AddNewDiagnosisToDB(newPatient.MaSoBN);
            });
        }
        public ICommand UpdateCommand { get; set; }
        private void InitialUpdateCommand()
        {
            UpdateCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {

            });
        }
        public ICommand DeleteCommand { get; set; }
        private void InitialDeleteCommand()
        {
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {

            });
        }
        public ICommand SearchPatientCommand { get; set; }
        private void InitialSearchPatientCommand()
        {
            SearchPatientCommand = new RelayCommand<TextBox>((p) =>
            {
                if (p.Text.Length > 0)
                {
                    return true;
                }

                SearchResults.Clear();
                return false;

            }, (p) =>
            {
                string searchText = p.Text;
                LoadData(searchText);
            });
        }
        public ICommand AddOldPatientCommand { get; set; }
        private void InitialAddOldPatientCommand()
        {
            AddOldPatientCommand = new RelayCommand<BenhNhan>((p) =>
            {
                var result = PatientList.Where(pa => pa.MaSoBN == p.MaSoBN).ToList();
                if (result.Count == 0)
                {
                    return true;
                }
                return false;

            }, (p) =>
            {
                PatientList.Add(p);
                int Id = DataProvider.Ins.DB.PhieuKhams.Max(pk => pk.MaPK) + 1;
                AddNewDiagnosisToDB(p.MaSoBN);
            });
        }

        public ICommand ExamCommand { get; set; }

        private void InitialExamCommand()
        {
            ExamCommand = new RelayCommand<BenhNhan>((p) =>                     //Can review lai
            {
                if(p!= null)
                {
                    var pk = p.PhieuKhams.ToList();
                    int count = pk.Count;
                    foreach(var x in pk)
                    {
                        if(x.NgayKham.Date == DateTime.Now.Date && x.TienKham !=0)
                        {
                            return false;
                        }
                    }
                }
                return true; // Nếu là nhân viên thì return false

            }, (p) =>
            {
                var x = p.PhieuKhams;
                var result = x.Where(pk => pk.NgayKham.Date == DateTime.Now.Date).First();

                var newScreen = DiagnosisScreen.Instance(result.MaPK);
                var mainWindow = MainWindow.Instance;
                mainWindow.GridPriciple.Children.Clear();
                mainWindow.GridPriciple.Children.Add(newScreen);
                mainWindow.ListViewMenu.SelectedIndex = 1;
            });
        }

        public ObservableCollection<BenhNhan> PatientList
        {
            get => _PatientList;
            set { 
                _PatientList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<BenhNhan> _searchResults;
        public ObservableCollection<BenhNhan> SearchResults
        {
            get => _searchResults;
            set
            {
                _searchResults = value;
                OnPropertyChanged();
            }
        }

        public string HoTen { get => _HoTen; set => _HoTen = value; }
        public string GioiTinh { get => _GioiTinh; set { _GioiTinh = value; OnPropertyChanged(); } }
        public int NamSinh { get => _NamSinh; set => _NamSinh = value; }
        public string DiaChi { get => _DiaChi; set => _DiaChi = value; }
        public string SellectedEle { get => _SellectedEle; set => _SellectedEle = value; }

        private ObservableCollection<BenhNhan> _PatientList;
        private void LoadData(string text)
        {
            var patients = DataProvider.Ins.DB.BenhNhans.Where(p => p.HoTen.Contains(text) && p.Xoa != true).ToList();
            SearchResults = new ObservableCollection<BenhNhan>(patients);
        }

        private void LoadData()
        {
            var currDate = DateTime.Now.Date;
            var result = DataProvider.Ins.DB.PhieuKhams.Where(pk => DbFunctions.TruncateTime(pk.NgayKham) == currDate
                                                                    && pk.Xoa != true).ToList();
            PatientList = new ObservableCollection<BenhNhan>();
            foreach(var pattient in result)
            {
                PatientList.Add(pattient.BenhNhan);
            }
            //PatientList = new ObservableCollection<BenhNhan>(result);
        }

        public PatientListViewModel()
        {

            LoadData();
            Date = DateTime.Now;
            HoTen = "";
            GioiTinh = "Nam";
            NamSinh = DateTime.Now.Year;
            DiaChi = "";

            InitialExamCommand();
            InitialAddCommand();
            InitialSearchPatientCommand();
            InitialAddOldPatientCommand();
        }

        private BenhNhan AddNewPatientToDB()
        {
            int id = DataProvider.Ins.DB.BenhNhans.Max(x => x.MaSoBN) + 1;
            var newPatient = new BenhNhan()
            {
                DiaChi = DiaChi,
                GioiTinh = GioiTinh,
                HoTen = HoTen,
                MaSoBN = id,
                NamSinh = NamSinh,
                Xoa = false
            };

            DataProvider.Ins.DB.BenhNhans.Add(newPatient);
            DataProvider.Ins.DB.SaveChanges();

            return newPatient;
        }

        private void AddNewDiagnosisToDB(int patientID)
        {
            int Id = DataProvider.Ins.DB.PhieuKhams.Max(pk => pk.MaPK) + 1;
            PhieuKham newDiagnosis = new PhieuKham()
            {
                MaPK = Id,
                MaBN = patientID,
                NgayKham = Date,
                Xoa = false,
                MaLoaiBenh = 0,
                TienKham = 0,
                TienThuoc = 0,
                TrieuChung = ""
            };

            DataProvider.Ins.DB.PhieuKhams.Add(newDiagnosis);
            DataProvider.Ins.DB.SaveChanges();
        }
    }
}
