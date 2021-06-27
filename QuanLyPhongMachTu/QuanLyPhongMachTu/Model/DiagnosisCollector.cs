using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace QuanLyPhongMachTu.Model
{
    public class DiagnosisCollector : INotifyPropertyChanged
    {
        private int _maPK;
        public int MaPK { 
            get { return _maPK; }

            set 
            {
                _maPK = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MaPK"));
                }
            }
        }
        
        public int MaBN { get; set; }

        public string TenBN { get; set; }

        private string _trieuChung;
        public string TrieuChung
        {
            get { return _trieuChung; }
            set
            {
                _trieuChung = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("TrieuChung"));
                }
            }
        }

        private int _maLoaiBenh;
        public int MaLoaibenh
        {
            get { return _maLoaiBenh; }
            set
            {
                _maLoaiBenh = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MaLoaiBenh"));
                }
            }
        }

        public int TienKham { get; set; }

        private int _tienThuoc;
        public int TienThuoc
        {
            get { return _tienThuoc; }
            set
            {
                _tienThuoc = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("TienThuoc"));
                }
            }
        }

        public DateTime NgayKham { get; set; }

        public bool Xoa { get; set; }

        public DiagnosisCollector(int patientID, string patientName)
        {
            MaBN = patientID;
            TenBN = patientName;
            NgayKham = DateTime.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
