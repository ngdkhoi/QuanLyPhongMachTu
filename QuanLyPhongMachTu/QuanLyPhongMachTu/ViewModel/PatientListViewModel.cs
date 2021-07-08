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
        private int _ID =-1;

        private bool isUpdateMode = false;
        public string textSearch { get; set; }
        public DateTime Date { get => _Date;  set { _Date = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        private void InitialAddCommand()
        {
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (!isUpdateMode)
                {
                    if (HoTen == null || GioiTinh == null || NamSinh == 0 || NamSinh > DateTime.Now.Year || DiaChi == null)
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            }, (p) =>
            {
                BenhNhan newPatient = AddNewPatientToDB();
                PatientList.Add(newPatient);

                HoTen = null;
                GioiTinh = null;
                NamSinh = 0;
                DiaChi = null;

                AddNewDiagnosisToDB(newPatient.MaSoBN);
            });
        }
        public ICommand UpdateCommand { get; set; }
        private void InitialUpdateCommand()
        {
            UpdateCommand = new RelayCommand<DataGrid>((p) =>
            {
                if (p!= null && p.SelectedItem != null)
                {
                    var bn = p.SelectedItem as BenhNhan;
                    if (bn.MaSoBN != ID)
                    {
                        ID = bn.MaSoBN;
                        HoTen = bn.HoTen;
                        GioiTinh = bn.GioiTinh;
                        NamSinh = bn.NamSinh;
                        DiaChi = bn.DiaChi;
                        isUpdateMode = true;
                    }
                    return true;
                }
                return false;
            }, (p) =>
            {
                var patient = DataProvider.Ins.DB.BenhNhans.Where(bn => bn.MaSoBN == ID).First();
                patient.HoTen = HoTen;
                patient.GioiTinh = GioiTinh;
                patient.NamSinh = NamSinh;
                patient.DiaChi = DiaChi;
                DataProvider.Ins.DB.SaveChanges();
                HoTen = "";
                GioiTinh = "Nam";
                NamSinh = DateTime.Now.Year;
                DiaChi = "";
                ID = -1;
                isUpdateMode = false;
                LoadData(textSearch);
                LoadData();
                p.SelectedIndex = -1;
            });
        }
        public ICommand DeleteCommand { get; set; }
        private void InitialDeleteCommand()
        {
            DeleteCommand = new RelayCommand<BenhNhan>((p) =>
            {
                if (isUpdateMode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }, (p) =>
            {
                SearchResults.Remove(p);
                PatientList.Remove(p);
                p.Xoa = true;
                if (DataProvider.Ins.DB.PhieuKhams.Count(x=>x.MaBN == p.MaSoBN && x.TienKham == 0) != 0)
                {
                    var pk = p.PhieuKhams.Where(x => x.MaBN == p.MaSoBN && x.NgayKham.Date == DateTime.Now.Date && x.TienKham == 0).First();
                    if (pk != null)
                    {
                        DataProvider.Ins.DB.PhieuKhams.Remove(pk);
                    }
                }
                DataProvider.Ins.DB.SaveChanges();
                LoadData();
                HoTen = "";
                GioiTinh = "Nam";
                NamSinh = DateTime.Now.Year;
                DiaChi = "";
                ID = -1;
                isUpdateMode = false;
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
                    var check = p.PhieuKhams.Where(pk => pk.NgayKham.Date == DateTime.Now.Date).First();
                    if(check.TienKham != 0)
                    {
                        return false;
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

        public ICommand DeletePatientInListCommand { get; set; }

        private void InitialDeletePatientInListCommand()
        {
            DeletePatientInListCommand = new RelayCommand<BenhNhan>((p) =>                     //Can review lai
            {
                if (p != null)
                {
                    var check = p.PhieuKhams.Where(pk => pk.NgayKham.Date == DateTime.Now.Date).First();
                    if (check.TienKham != 0)
                    {
                        return false;
                    }
                }
                return true;

            }, (p) =>
            {
                PatientList.Remove(p);
                var pk = p.PhieuKhams.Where(x => x.NgayKham.Date == Date.Date).First();
                DataProvider.Ins.DB.PhieuKhams.Remove(pk);
                DataProvider.Ins.DB.SaveChanges();
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

        public string HoTen { get => _HoTen; set { _HoTen = value; OnPropertyChanged("HoTen"); } }
        public string GioiTinh { get => _GioiTinh; set { _GioiTinh = value; OnPropertyChanged(); } }
        public int NamSinh { get => _NamSinh; set { _NamSinh = value; OnPropertyChanged(); } }
        public string DiaChi { get => _DiaChi; set { _DiaChi = value; OnPropertyChanged("DiaChi"); } }
        public string SellectedEle { get => _SellectedEle; set => _SellectedEle = value; }
        public int ID { get => _ID; set => _ID = value; }

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

            InitialExamCommand();
            InitialAddCommand();
            InitialSearchPatientCommand();
            InitialAddOldPatientCommand();
            InitialDeletePatientInListCommand();
            InitialUpdateCommand();
            InitialDeleteCommand();
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
