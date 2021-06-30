using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMachTu.Model
{
    public class MedicineCollector
    {
        public int MaThuoc { get; set; }
        
        public string TenThuoc { get; set; }

        public string DonVi { get; set; }

        public int Gia { get; set; }
        public int SoLuong { get; set; }
        public int SoLanDung { get; set; }
        public MedicineCollector(int stt, string tenthuoc, string donvi, int soluong, int solandung)
        {
            MaThuoc = stt;
            TenThuoc = tenthuoc;
            DonVi = donvi;
            SoLuong = soluong;
            SoLanDung = solandung;
        }
        public MedicineCollector() { }
    }
}
