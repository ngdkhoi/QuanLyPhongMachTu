using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows;

namespace QuanLyPhongMachTu.ViewModel
{
    public class DiagnosisViewModel : BaseViewModel
    {
        public class ChiTietThuoc : BaseViewModel
        {

            private int _stt;
            public int STT
            {
                get
                {
                    return _stt;
                }
                set
                {
                    _stt = value;
                    OnPropertyChanged();
                }
            }

            private string _name;
            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }

            private string _donVi;
            public string DonVi
            {
                get
                {
                    return _donVi;
                }
                set
                {
                    _donVi = value;
                    OnPropertyChanged();
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
                    OnPropertyChanged();
                }
            }

            private string _cachDung;  
            public string CachDung
            {
                get
                {
                    return _cachDung;
                }
                set
                {
                    _cachDung = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<ChiTietThuoc> _donThuoc;
        public ObservableCollection<ChiTietThuoc> DonThuoc
        {
            get
            {
                return _donThuoc;
            }
            set
            {
                _donThuoc = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> DanhSachThuoc { get; set; }

        public ICommand AddMedicineCommand { get; set; }
        public ICommand DeleteMedicineCommand { get; set; }


        public DiagnosisViewModel()
        {
            AddMedicineCommand = new RelayCommand<DiagnosisScreen>((p) =>
            {
                return true;
            }, (p) =>
            {
                int newOrder = DonThuoc[DonThuoc.Count - 1].STT + 1;
                DonThuoc.Add(new ChiTietThuoc() { 
                    STT = newOrder,
                    Name = "",
                    SoLuong = 0,
                    DonVi = "viên",
                    CachDung = ""
                });
            });

            DeleteMedicineCommand = new RelayCommand<ChiTietThuoc>((p) =>
            {
                return true;
            }, (HandleDeleteMedicine));

            DonThuoc = new ObservableCollection<ChiTietThuoc>()
            {
                new ChiTietThuoc()
                {
                    STT = 1,
                    Name = "Paracetamol",
                    CachDung = "3 lần/ngày",
                    SoLuong = 21,
                    DonVi = "viên"
                },
                new ChiTietThuoc()
                {
                    STT = 2,
                    Name = "",
                    CachDung = "3 lần/ngày",
                    SoLuong = 21,
                    DonVi = "viên"
                },
                new ChiTietThuoc()
                {
                    STT = 3,
                    Name = "",
                    CachDung = "1 lần/ngày",
                    SoLuong = 7,
                    DonVi = "gói"
                }
            };

            DanhSachThuoc = new ObservableCollection<string>()
            {
                "Paracetamol",
                "Cafein",
                "Heroin"
            };
        }

        private void HandleDeleteMedicine(ChiTietThuoc target)
        {
            DonThuoc.Remove(target);
        }
    }
}
