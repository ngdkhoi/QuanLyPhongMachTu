using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Input;
using QuanLyPhongMachTu.Model;

namespace QuanLyPhongMachTu.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string _Account;
        private  string _Password;
        public void doSomething() { }
        public ICommand CloseCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public string Account { get => _Account; set => _Account = value; }
        public string Password { private get => _Password; set => _Password = value; }
        
        public LoginViewModel()
        {
            Account = null;
            Password = null;
            LoginCommand = new RelayCommand<LoginScreen>((p) =>
            {
                if (Account != null && Password != null)
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                bool isSuccess = false;
                foreach(var i in DataProvider.Ins.DB.NhanViens)
                {
                    if(i.Account==Account && i.Password == Password)
                    {
                        Global.UserID = i.MaSoNV;
                        MainWindow mainWindow = MainWindow.Instance;
                        mainWindow.Show();
                        isSuccess = true;
                        p.Close();
                    }
                }
                if (!isSuccess)
                {
                    Notification notification = new Notification("Tài khoản hoặc mật khẩu bị sai");
                    notification.Show();
                }
            });
            CloseCommand = new RelayCommand<LoginScreen>((p) =>
              {
                  return true;
              }, (p) =>
              {
                  System.Environment.Exit(0);
              });
        }
    }
}
