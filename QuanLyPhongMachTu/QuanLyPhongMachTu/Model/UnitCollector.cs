using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMachTu.Model
{
    public class UnitCollector
    {
        private int _MaDV;
        private string _DonVi;
        public int MaDV { get => _MaDV; set => _MaDV = value; }
        public string DonVi { get => _DonVi; set => _DonVi = value; }

        public UnitCollector()
        {

        }
    }
}
