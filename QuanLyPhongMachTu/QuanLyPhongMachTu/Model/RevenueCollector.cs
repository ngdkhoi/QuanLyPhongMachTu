using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMachTu.Model
{
    public class RevenueCollector
    {
        private DateTime _Ngay;
        private int _STT;
        private int _SoBenhNhan;
        private int _DoanhThu;
        private double _TiLe;
        public RevenueCollector(int stt, DateTime ngay, int sobenh, int doanhthu, double tile)
        {
            this.STT = stt;
            this.Ngay = ngay;
            this.SoBenhNhan = sobenh;
            this.DoanhThu = doanhthu;
            this.TiLe = tile;
        }

        public DateTime Ngay { get => _Ngay; set => _Ngay = value; }
        public int STT { get => _STT; set => _STT = value; }
        public int SoBenhNhan { get => _SoBenhNhan; set => _SoBenhNhan = value; }
        public int DoanhThu { get => _DoanhThu; set => _DoanhThu = value; }
        public double TiLe { get => _TiLe; set => _TiLe = value; }
    }
}
