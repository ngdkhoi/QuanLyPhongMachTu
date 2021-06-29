using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongMachTu.Model;

namespace QuanLyPhongMachTu.ViewModel
{
    public class SearchPatientViewModel : BaseViewModel
    {
        private DateTime _Date;
        public SearchPatientViewModel() { }

        public DateTime Date { get => _Date; set => _Date = value; }
    }
}
