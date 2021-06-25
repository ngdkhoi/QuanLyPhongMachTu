using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.IO;
using QuanLyPhongMachTu.Model;

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
        public DateTime Date { get => _Date;  set { _Date = value; OnPropertyChanged(); } }
        public ICommand PayCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ObservableCollection<PatientCollector> PatientList
        {
            get => _PatientList;
            set { 
                _PatientList = value;
                OnPropertyChanged();
            }
        }

        public string HoTen { get => _HoTen; set => _HoTen = value; }
        public string GioiTinh { get => _GioiTinh; set => _GioiTinh = value; }
        public int NamSinh { get => _NamSinh; set => _NamSinh = value; }
        public string DiaChi { get => _DiaChi; set => _DiaChi = value; }

        private ObservableCollection<PatientCollector> _PatientList = new ObservableCollection<PatientCollector>();
        private void LoadData()
        {
            var query = from a in DataProvider.Ins.DB.BenhNhans.Where(x => x.NgayKham == Date)
                        select new
                        {
                            maso = a.MaSoBN,
                            hoten = a.HoTen,
                            gioitinh = a.GioiTinh,
                            namsinh = a.NamSinh,
                            diachi=a.DiaChi,
                            ngaykham=a.NgayKham
                        };
            foreach(var i in query)
            {
                PatientList.Add(new PatientCollector(i.maso, i.hoten, i.gioitinh, i.namsinh, i.diachi, i.ngaykham));
            }
        }
        
        public PatientListViewModel()
        {
            Date = DateTime.Now;
            // Patient temp = new Patient() { stt = 1, Name = "Nguyễn Đình Khôi", Gender = "Nam", YoB = 2000, Address = "Gò Vấp" };
            LoadData();
            AddCommand = new RelayCommand<object>((p) =>
              {
                  return true;
              }, (p) =>
              {
                  int id = DataProvider.Ins.DB.BenhNhans.Max(x => x.MaSoBN) + 1;
                  PatientList.Add(new PatientCollector(id, HoTen, GioiTinh.Contains("Nam") ? "Nam" : "Nữ", NamSinh, DiaChi, Date));
                  //DataProvider.Ins.DB.BenhNhans.Add(new BenhNhan() { MaSoBN = id, HoTen = HoTen, GioiTinh = GioiTinh.Contains("Nam")?"Nam":"Nữ", NamSinh = NamSinh, DiaChi = DiaChi, NgayKham = Date, Xoa = false });
                  //DataProvider.Ins.DB.SaveChanges();
                  HoTen = "";

              });
            UpdateCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                
            });
            PayCommand = new RelayCommand<PatientListScreen>((p) =>
            {
                return true;
            }, (p) =>
            {
                PayScreen ps = new PayScreen();
                ps.Show();
            });
        }
    }
}
