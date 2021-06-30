using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Input;
using System.Collections.ObjectModel;
using QuanLyPhongMachTu.Model;


namespace QuanLyPhongMachTu.ViewModel
{
    public class MedicineReportViewModel : BaseViewModel
    {
        private ObservableCollection<int> _Months = new ObservableCollection<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        private ObservableCollection<int> _Years;
        private ObservableCollection<MedicineCollector> _MedicineList;
        
        public ObservableCollection<int> Months { get => _Months; set => _Months = value; }
        public ObservableCollection<int> Years 
        {
            get
            {
                if (_Years == null)
                {
                    var currYear = DateTime.Now.Year;
                    Years = new ObservableCollection<int>();
                    for (int i = 0; i < 10; i++)
                    {
                        int year = currYear - i;
                        Years.Add(year);
                    }
                }
                return _Years;
            }
            set => _Years = value; 
        }
        public ObservableCollection<MedicineCollector> MedicineList { get => _MedicineList; set { _MedicineList = value; OnPropertyChanged(); } }

        private int _selectedMonth;
        private int _selectedYear;
        private DateTime startDate;
        private DateTime endDate;
        public int SelectedMonth
        {
            get
            {
                return _selectedMonth;
            }
            set
            {
                _selectedMonth = value;
                OnPropertyChanged();
            }
        }
        public int SelectedYear { get => _selectedYear; set { _selectedYear = value; OnPropertyChanged(); } }
        public ICommand ReportCommand { get; set; }
        void doSomeThing() { }
        public MedicineReportViewModel()
        {
            ReportCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedMonth == 0 || SelectedMonth == 0)
                {
                    return false;
                }
                return true;
            }, (p) => 
            {
                doSomeThing();
            });
        }
    }
}
