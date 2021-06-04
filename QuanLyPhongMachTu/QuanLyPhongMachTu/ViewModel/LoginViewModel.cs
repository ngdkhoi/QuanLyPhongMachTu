using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Input;

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
            LoginCommand = new RelayCommand<LoginScreen>((p) =>
            {
                if (Account != null && Password != null)
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                if (Account == "khoi" && Password =="1234")
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    p.Close();
                }
                else
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
                  p.Close();
              });
        }
    }
}
