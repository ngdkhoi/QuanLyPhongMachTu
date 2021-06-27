using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyPhongMachTu.Model;

namespace QuanLyPhongMachTu.ViewModel
{
    public class AddMedicineViewModel : BaseViewModel
    {
        private string _NewUsing;
        private string _NewUnit;
        public ICommand AddNewUsingCommand { get; set; }
        public ICommand AddNewUnitCommand { get; set; }
        public string NewUsing { get => _NewUsing; set { _NewUsing = value; OnPropertyChanged(); } }

        public string NewUnit { get => _NewUnit; set { _NewUnit = value; OnPropertyChanged(); } }

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
                int id = DataProvider.Ins.DB.DonVis.Max(x => x.MaDonVi) + 1;
                DataProvider.Ins.DB.DonVis.Add(new DonVi() { MaDonVi = id, TenDonVi = NewUnit });
                DataProvider.Ins.DB.SaveChanges();
                NewUnit = null;
                Notification notification = new Notification("Thêm thành công");
                notification.Show();
            });

        }
    }
}
