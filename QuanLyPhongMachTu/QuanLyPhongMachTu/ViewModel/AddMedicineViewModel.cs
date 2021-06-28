using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using QuanLyPhongMachTu.Model;

namespace QuanLyPhongMachTu.ViewModel
{
    public class AddMedicineViewModel : BaseViewModel
    {
        private string _NewUsing;
        private string _NewUnit;
        
        private string _NewMedicine;
        private string _NewUnit2;
        private int _NewPrice;
        private int _NewAmount;

        private string _UpdateMedicine;
        private string _Unit;
        private int _Price;
        private int _Amount;
        private int _ID = -1;

        private ObservableCollection<string> _UnitList;
        private ObservableCollection<string> _UsingList;
        private ObservableCollection<string> _MedicineList;
        public ICommand AddNewUsingCommand { get; set; }
        public ICommand AddNewUnitCommand { get; set; }
        public ICommand AddNewMedicineCommand { get; set; }
        public ICommand UpdateMedicineCommand { get; set; }
        public ICommand CancelAddCommand { get; set; }
        public ICommand CancelUpdateCommand { get; set; }
        public string NewUsing { get => _NewUsing; set { _NewUsing = value; OnPropertyChanged(); } }

        public string NewUnit { get => _NewUnit; set { _NewUnit = value; OnPropertyChanged(); } }

        public ObservableCollection<string> UnitList {
            get
            {
                if (_UnitList == null)
                {
                    _UnitList = new ObservableCollection<string>();
                    var query = DataProvider.Ins.DB.DonVis;
                    foreach(var i in query)
                    {
                        _UnitList.Add(i.TenDonVi);
                    }
                }

                return _UnitList;
            }
            set { 
                _UnitList = value; 
                OnPropertyChanged(); 
            } 
        }
        public ObservableCollection<string> MedicineList 
        {
            get
            {
                if (_MedicineList == null)
                {
                    _MedicineList = new ObservableCollection<string>();
                    var query = DataProvider.Ins.DB.LoaiThuocs;
                    foreach(var i in query)
                    {
                        MedicineList.Add(i.TenThuoc);
                    }
                }

                return _MedicineList;
            }
            set
            {
                _MedicineList = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> UsingList 
        { 
            get => _UsingList; 
            set => _UsingList = value; 
        }
        public string NewMedicine { get => _NewMedicine; set { _NewMedicine = value; OnPropertyChanged(); } }
        public int NewAmount { get => _NewAmount; set { _NewAmount = value; OnPropertyChanged(); } }

        public string NewUnit2 { get => _NewUnit2; set { _NewUnit2 = value; OnPropertyChanged(); } }

        public int NewPrice { get => _NewPrice; set { _NewPrice = value; OnPropertyChanged(); } }


        public string Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }
        public int Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }
        public int Amount { get => _Amount; set { _Amount = value; OnPropertyChanged(); } }

        public int ID
        {
            get => _ID;
            set 
            { 
                _ID = value;
                if(ID != -1)
                {
                    int UnitID = DataProvider.Ins.DB.LoaiThuocs.Where(x => x.MaThuoc == ID + 1).FirstOrDefault().MaDonVi;
                    Unit = DataProvider.Ins.DB.DonVis.Where(x => x.MaDonVi == UnitID).FirstOrDefault().TenDonVi;
                    Price = DataProvider.Ins.DB.LoaiThuocs.Where(x => x.MaThuoc == ID + 1).FirstOrDefault().Gia;
                    Amount = DataProvider.Ins.DB.LoaiThuocs.Where(x => x.MaThuoc == ID + 1).FirstOrDefault().SoLuong;
                    OnPropertyChanged("Unit");
                    OnPropertyChanged("Price");
                    OnPropertyChanged("Amount");
                }
            }
        }

        public string UpdateMedicine { get => _UpdateMedicine; set { _UpdateMedicine = value; OnPropertyChanged(); } }



        public AddMedicineViewModel()
        {
            AddNewUsingCommand = new RelayCommand<object>((p) =>
              {
                  if (NewUsing == null)
                  {
                      return false;
                  }

                  return true;
              },(p)=> {
                  

                  int id = DataProvider.Ins.DB.CachDungs.Max(x => x.MaCachDung) + 1;
                  DataProvider.Ins.DB.CachDungs.Add(new CachDung() { MaCachDung = id, CachSuDung = NewUsing });
                  DataProvider.Ins.DB.SaveChanges();
                  NewUsing = null;

                  Notification notification = new Notification("Thêm thành công");
                  notification.Show();
              });

            AddNewUnitCommand = new RelayCommand<object>((p) =>
            {
                if (NewUnit == null)
                {
                    return false;
                }

                return true;
            }, (p) => {
                UnitList.Add(NewUnit);

                int id = DataProvider.Ins.DB.DonVis.Max(x => x.MaDonVi) + 1;
                DataProvider.Ins.DB.DonVis.Add(new DonVi() { MaDonVi = id, TenDonVi = NewUnit });
                DataProvider.Ins.DB.SaveChanges();
                NewUnit = null;

                Notification notification = new Notification("Thêm thành công");
                notification.Show();
            });

            AddNewMedicineCommand = new RelayCommand<object>((p) =>
            {
                if (NewMedicine == null || NewUnit2 == null || NewPrice == 0 || NewAmount == 0)
                {
                    return false;
                }

                return true;
            }, (p) => {
                MedicineList.Add(NewMedicine);

                int id = DataProvider.Ins.DB.LoaiThuocs.Max(x => x.MaThuoc) + 1;
                DataProvider.Ins.DB.LoaiThuocs.Add(new LoaiThuoc() { MaThuoc = id, TenThuoc = NewMedicine, MaDonVi = UnitList.IndexOf(NewUnit2) + 1, Gia = NewPrice, SoLuong = NewPrice, SoLanSuDung = 0 });
                DataProvider.Ins.DB.SaveChanges();
                Notification notification = new Notification("Thêm thành công");
                notification.Show();
                NewMedicine = null;
                NewUnit2 = null;
                NewPrice = 0;
                NewAmount = 0;
            });

            UpdateMedicineCommand = new RelayCommand<object>((p) =>
            {
                if (UpdateMedicine == null || Unit == null || Price == 0 || Amount == 0)
                {
                    return false;
                }

                return true;
            }, (p) => {
                var item = DataProvider.Ins.DB.LoaiThuocs.Where(x => x.MaThuoc == ID + 1).FirstOrDefault();
                item.TenThuoc = UpdateMedicine;
                item.MaDonVi = UnitList.IndexOf(Unit) + 1;
                item.Gia = Price;
                item.SoLuong = Amount;
                DataProvider.Ins.DB.SaveChanges();
                Notification notification = new Notification("Cập nhật thành công");
                notification.Show();
                UpdateMedicine = null;
                Unit = null;
                Price = 0;
                Amount = 0;
                ID = -1;
            });

            CancelAddCommand = new RelayCommand<object>((p) =>
            {
                if (!(NewMedicine == null && NewUnit2 == null && NewPrice == 0 && NewAmount == 0))
                {
                    return true;
                }

                return false;
            }, (p) => {
                NewMedicine = null;
                NewUnit2 = null;
                NewPrice = 0;
                NewAmount = 0;
                Notification notification = new Notification("Hủy thành công");
                notification.Show();
            });

            CancelUpdateCommand = new RelayCommand<object>((p) =>
            {
                if (!(UpdateMedicine == null && Unit == null && Price == 0 && Amount == 0))
                {
                    return true;
                }

                return false;
            }, (p) => {
                UpdateMedicine = null;
                Unit = null;
                Price = 0;
                Amount = 0;
                ID = -1;
                Notification notification = new Notification("Hủy thành công");
                notification.Show();
            });

        }
    }
}
