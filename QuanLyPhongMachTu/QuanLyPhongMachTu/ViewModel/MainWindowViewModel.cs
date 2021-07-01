using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyPhongMachTu.Model;

namespace QuanLyPhongMachTu.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _TenNhanVien;
        public ICommand LogoutCommand { get; set; }
        public string TenNhanVien 
        {
            get
            {
                _TenNhanVien = DataProvider.Ins.DB.NhanViens.Where(x => x.MaSoNV == Global.UserID).FirstOrDefault().HoTen;
                return _TenNhanVien;
            }
            set 
            { 
                _TenNhanVien = value; OnPropertyChanged(); 
            } 
        }
        void doSomething() { }

        public MainWindowViewModel()
        {
            doSomething();
            
            LogoutCommand = new RelayCommand<MainWindow>((p) =>
              {
                  return true;
              }, (p) =>
              {
                  LoginScreen newscreen = new LoginScreen();
                  newscreen.Show();
                  MainWindow.Instance = null;
                  p.Close();
              });

        }
    }
}
