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
        private bool _Xoa;
        DateTime _NgayKham;
        private string _LoaiBenh;
        private string _TrieuChung;

        public PatientCollector(int maso, string hoten, string gioitinh, int namsinh, string diachi)
        {
            this.MaSoBN = maso;
            this.HoTen = hoten;
            this.GioiTinh = gioitinh;
            this.NamSinh = namsinh;
            this.Diachi = diachi;
            this.Xoa = false;
        }
        public PatientCollector(int STT, string hoten, DateTime ngaykham, string loaibenh, string trieuchung)
        {
            this.MaSoBN = STT;
            this.HoTen = hoten;
            this.NgayKham = ngaykham;
            this.LoaiBenh = loaibenh;
            this.TrieuChung = trieuchung;
        }

        public int MaSoBN { get => _MaSoBN; set => _MaSoBN = value; }
        public string HoTen { get => _HoTen; set => _HoTen = value; }
        public string GioiTinh { get => _GioiTinh; set => _GioiTinh = value; }
        public int NamSinh { get => _NamSinh; set => _NamSinh = value; }
        public string Diachi { get => _Diachi; set => _Diachi = value; }
        public bool Xoa { get => _Xoa; set => _Xoa = value; }
        public DateTime NgayKham { get => _NgayKham; set => _NgayKham = value; }
        public string LoaiBenh { get => _LoaiBenh; set => _LoaiBenh = value; }
        public string TrieuChung { get => _TrieuChung; set => _TrieuChung = value; }
    }
}
