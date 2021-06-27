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
        public MedicineCollector(LoaiThuoc a)
        {
            MaThuoc = a.MaThuoc;
            TenThuoc = a.TenThuoc;
            DonVi = DataProvider.Ins.DB.DonVis.Where(x => x.MaDonVi == a.MaDonVi).FirstOrDefault().TenDonVi;
            Gia = a.Gia;
            SoLuong = a.SoLuong;
        }
        public MedicineCollector() { }
    }
}
