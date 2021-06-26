using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Input;
using System.Collections.ObjectModel;


namespace QuanLyPhongMachTu.ViewModel
{
    public class MedicineReportViewModel : BaseViewModel
    {
        public ObservableCollection<int> Months { get; set; }
        public ObservableCollection<int> Years { get; set; }

        private int _selectedMonth;
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
        public MedicineReportViewModel()
        {
            Months = new ObservableCollection<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
            };

            var currYear = DateTime.Now.Year;
            Years = new ObservableCollection<int>();
            for( int i = 0; i < 10; i++)
            {
                int year = currYear - i;
                Years.Add(year);
            }
        }
    }
}
