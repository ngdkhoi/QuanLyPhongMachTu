using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyPhongMachTu.Model;

namespace QuanLyPhongMachTu.ViewModel
{
    public class UpdateRegulationsViewModel : BaseViewModel
    {
        private int _NewNumOfPatient;
        private int _NewDiagnosisMoney;
        public ICommand UpdateNumOfPatientCommand { get; set; }
        public ICommand UpdateDiagnosisMoneyCommand { get; set; }
        public int NewNumOfPatient 
        { 
            get => _NewNumOfPatient; 
            set 
            {
                _NewNumOfPatient = value;
                OnPropertyChanged(); 
            } 
        }
        public int NewDiagnosisMoney { get => _NewDiagnosisMoney; set { _NewDiagnosisMoney = value; OnPropertyChanged(); } }
        void DoSonething()
        {

        }
        public UpdateRegulationsViewModel()
        {
            NewNumOfPatient = DataProvider.Ins.DB.QuyDinhs.Where(x => x.MaQD == 1).SingleOrDefault().SoLuongQD;
            NewDiagnosisMoney = DataProvider.Ins.DB.QuyDinhs.Where(x => x.MaQD == 2).SingleOrDefault().SoLuongQD;

            UpdateNumOfPatientCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) => {
                var item = DataProvider.Ins.DB.QuyDinhs.Where(x => x.MaQD == 1).SingleOrDefault();
                item.SoLuongQD = NewNumOfPatient;
                DataProvider.Ins.DB.SaveChanges();
                Notification notification = new Notification("Cập nhật thành công");
                notification.Show();
            });

            UpdateDiagnosisMoneyCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) => {
                var item = DataProvider.Ins.DB.QuyDinhs.Where(x => x.MaQD == 2).SingleOrDefault();
                item.SoLuongQD = NewDiagnosisMoney;
                DataProvider.Ins.DB.SaveChanges();
                Notification notification = new Notification("Cập nhật thành công");
                notification.Show();
            });
        }
    }
}
