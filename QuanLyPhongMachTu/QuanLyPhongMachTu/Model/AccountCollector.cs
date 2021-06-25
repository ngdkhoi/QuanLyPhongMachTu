using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongMachTu.ViewModel;

namespace QuanLyPhongMachTu.Model
{
    public class AccountCollector
    {
        private string _Account;
        private string _Passwork;
        public AccountCollector()
        {

        }

        public string Account { get => _Account; set => _Account = value; }
        public string Passwork { get => _Passwork; set => _Passwork = value; }
    }
}
