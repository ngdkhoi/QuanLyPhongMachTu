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
    public class ReportViewModel : BaseViewModel
    {
        private ObservableCollection<int> _Months = new ObservableCollection<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        private ObservableCollection<int> _Years;
        private ObservableCollection<MedicineCollector> _MedicineList;
        private ObservableCollection<RevenueCollector> _RevenueList;

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
        public ObservableCollection<MedicineCollector> MedicineList
        {
            get
            {
                if (_MedicineList == null)
                {
                    _MedicineList = new ObservableCollection<MedicineCollector>();
                }

                return _MedicineList;
            }
            set
            {
                _MedicineList = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<RevenueCollector> RevenueList 
        {
            get 
            { 
                if(_RevenueList == null)
                {
                    _RevenueList = new ObservableCollection<RevenueCollector>();
                }
                return _RevenueList; 
            }
            set 
            { 
                _RevenueList = value; 
            }
        }

        private int _selectedMonth;
        private int _selectedYear;
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
        public ICommand MedicineReportCommand { get; set; }
        public ICommand RevenueReportCommand { get; set; }
        

        void doSomeThing() { }
        void LoadUsedMedicineData(DateTime startDate, DateTime endDate)
        {
            MedicineList.Clear();
            var query = from pk in DataProvider.Ins.DB.PhieuKhams
                        join ctdt in DataProvider.Ins.DB.ChiTietDonThuocs
                        on pk.MaPK equals ctdt.MaPK
                        where pk.NgayKham >= startDate && pk.NgayKham < endDate
                        select new
                        {
                            thuoc = ctdt.LoaiThuoc.TenThuoc,
                            donvi = ctdt.LoaiThuoc.DonVi.TenDonVi,
                            soluong = ctdt.SoLuong
                        };
            var CountUsedTimes = from q in query
                                 group q by q.thuoc into UsedTimes
                                 select new
                                 {
                                     thuoc = UsedTimes.Key,
                                     donvi = UsedTimes.FirstOrDefault().donvi,
                                     soluong = UsedTimes.Sum(x => x.soluong),
                                     slsd = UsedTimes.Count()
                                 };

            int stt = 1;
            foreach (var i in CountUsedTimes)
            {
                MedicineList.Add(new MedicineCollector(stt, i.thuoc, i.donvi, i.soluong, i.slsd));
                stt++;
            }
        }
        void LoadRevenueData(DateTime startDate, DateTime endDate)
        {
            RevenueList.Clear();
            //var revenuePerMonth = from pk in DataProvider.Ins.DB.PhieuKhams
            //                      join ctdt in DataProvider.Ins.DB.ChiTietDonThuocs
            //                      on pk.MaPK equals ctdt.MaPK
            //                      join lt in DataProvider.Ins.DB.LoaiThuocs
            //                      on ctdt.MaThuoc equals lt.MaThuoc
            //                      where pk.NgayKham >= startDate && pk.NgayKham < endDate
            //                      select new
            //                      {
            //                          tienkham = pk.
            //                      };
            var query = from pk in DataProvider.Ins.DB.PhieuKhams
                        where pk.NgayKham >= startDate && pk.NgayKham < endDate
                        group pk by pk.NgayKham into RevenueMonth
                        select new
                        {
                            ngaykham = RevenueMonth.Key,
                            soluong = RevenueMonth.Count(),
                            tien = RevenueMonth.Sum(x=>x.TienKham)+ RevenueMonth.Sum(x => x.TienThuoc),
                        };
            int stt = 1;
            int total = 0;
            if (query.Any())
            {
                total = query.Sum(x => x.tien);
            }

            foreach (var i in query)
            {
                RevenueList.Add(new RevenueCollector(stt, i.ngaykham, i.soluong, i.tien, ((double)i.tien / (double)total)));
                stt++;
            }
        }
        public ReportViewModel()
        {
            MedicineReportCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedMonth == 0 && SelectedMonth == 0)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                DateTime startDate = DateTime.Parse(SelectedMonth.ToString() + "/01/" + SelectedYear.ToString());
                DateTime endDate = DateTime.Parse(SelectedMonth.ToString() + "/01/" + SelectedYear.ToString()).AddMonths(1);

                LoadUsedMedicineData(startDate, endDate);
            });

            RevenueReportCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedMonth == 0 || SelectedMonth == 0)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                DateTime startDate = DateTime.Parse(SelectedMonth.ToString() + "/01/" + SelectedYear.ToString());
                DateTime endDate = DateTime.Parse(SelectedMonth.ToString() + "/01/" + SelectedYear.ToString()).AddMonths(1);

                LoadRevenueData(startDate, endDate);
            });
        }
    }
}
