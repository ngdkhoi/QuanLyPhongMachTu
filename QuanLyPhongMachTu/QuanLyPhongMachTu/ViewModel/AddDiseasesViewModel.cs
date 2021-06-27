using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongMachTu.Model;
using System.Windows.Input;

namespace QuanLyPhongMachTu.ViewModel
{
    public class AddDiseasesViewModel : BaseViewModel
    {
        private string _NewDisease;
        public ICommand AddNewDiseaseCommand { get; set; }

        public string NewDisease { get => _NewDisease; set { _NewDisease = value; OnPropertyChanged(); } }

        public AddDiseasesViewModel()
        {
            AddNewDiseaseCommand = new RelayCommand<object>((p) =>
            {
                if (NewDisease == null)
                {
                    return false;
                }

                return true;
            }, (p) => {
                int id = DataProvider.Ins.DB.LoaiBenhs.Max(x => x.MaBenh) + 1;
                DataProvider.Ins.DB.LoaiBenhs.Add(new LoaiBenh() { MaBenh = id, TenBenh = NewDisease });
                DataProvider.Ins.DB.SaveChanges();
                NewDisease = null;
                Notification notification = new Notification("Thêm thành công");
                notification.Show();
            });
        }
    }
}
