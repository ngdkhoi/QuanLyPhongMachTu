using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.IO;

namespace QuanLyPhongMachTu.ViewModel
{
    public class PatientListViewModel : BaseViewModel
    {
        //private ObservableCollection<Patient> _Patients = new ObservableCollection<Patient>();
        private DateTime _Date;
        public DateTime Date { get => _Date;  set { _Date = value; OnPropertyChanged(); } }
        public ICommand PayCommand { get; set; }

        //private ObservableCollection<Patient> Patients 
        //{ 
        //    get => _Patients; 
        //    set 
        //    { 
        //        _Patients = value;
        //        OnPropertyChanged();
        //    } 
        //}
        
        public PatientListViewModel()
        {
            Date = DateTime.Now;
            // Patient temp = new Patient() { stt = 1, Name = "Nguyễn Đình Khôi", Gender = "Nam", YoB = 2000, Address = "Gò Vấp" };
            PayCommand = new RelayCommand<PatientListScreen>((p) =>
              {
                  return true;
              }, (p) =>
              {
                  PayScreen ps = new PayScreen();
                  ps.Show();
              });
        }
    }
}
