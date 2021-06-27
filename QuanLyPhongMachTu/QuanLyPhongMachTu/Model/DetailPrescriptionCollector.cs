using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace QuanLyPhongMachTu.Model
{
    public class DetailPrescriptionCollector : INotifyPropertyChanged
    {
        private int _maThuoc;
        public int MaThuoc
        {
            get
            {
                return _maThuoc;
            }
            set
            {
                _maThuoc = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MaThuoc"));
                }
            }
        }

        private int _soLuong;
        public int SoLuong
        {
            get
            {
                return _soLuong;
            }
            set
            {
                _soLuong = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SoLuong"));
                }
            }
        }

        private int _maCachDung;
        public int MaCachDung
        {
            get
            {
                return _maCachDung;
            }
            set
            {
                _maCachDung = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
