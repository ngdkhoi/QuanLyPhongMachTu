using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMachTu.Model
{
    public class PatientCollector
    {
        private int _MaSoBN;
        private string _HoTen;
        private string _GioiTinh;
        private int _NamSinh;
        private string _Diachi;
        DateTime _NgayKham;
        bool _Xoa;
        public PatientCollector(int maso, string hoten, string gioitinh, int namsinh, string diachi, DateTime ngaykham)
        {
            this.MaSoBN = maso;
            this.HoTen = hoten;
            this.GioiTinh = gioitinh;
            this.NamSinh = namsinh;
            this.Diachi = diachi;
            this.NgayKham = ngaykham;
            this.Xoa = false;
        }

        public int MaSoBN { get => _MaSoBN; set => _MaSoBN = value; }
        public string HoTen { get => _HoTen; set => _HoTen = value; }
        public string GioiTinh { get => _GioiTinh; set => _GioiTinh = value; }
        public int NamSinh { get => _NamSinh; set => _NamSinh = value; }
        public string Diachi { get => _Diachi; set => _Diachi = value; }
        public DateTime NgayKham { get => _NgayKham; set => _NgayKham = value; }
        public bool Xoa { get => _Xoa; set => _Xoa = value; }
    }
}
