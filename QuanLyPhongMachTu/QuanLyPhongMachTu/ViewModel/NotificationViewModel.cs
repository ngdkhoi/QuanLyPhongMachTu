using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Input;

namespace QuanLyPhongMachTu.ViewModel
{
    public class NotificationViewModel : BaseViewModel
    {
        public ICommand OKCommand { get; set; }

        public NotificationViewModel()
        {
            OKCommand = new RelayCommand<Notification>((p) =>
              {
                  return true;
              }, (p) =>
             {
                 p.Close();
              });
        }
    }
}
