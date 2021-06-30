using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongMachTu.Model;
using System.Collections.ObjectModel;

namespace QuanLyPhongMachTu.ViewModel
{
    public class SearchPatientViewModel : BaseViewModel
    {
        private DateTime _Date = DateTime.Now;
        public DateTime Date 
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
                LoadData();
            }
        }

        private ObservableCollection<PatientCollector> _PatientList = new ObservableCollection<PatientCollector>();
        public ObservableCollection<PatientCollector> PatientList 
        { 
            get => _PatientList;
            set
            { 
                _PatientList = value;
                OnPropertyChanged();
            }
        
        }
        private bool compareDate(DateTime a, DateTime b)
        {
            string[] str_a = a.ToString().Split(' ');
            string[] str_b = b.ToString().Split(' ');

            return str_a[0] == str_b[0];
        }
        private void LoadData()
        {
            PatientList.Clear();
            DateTime theNextDate = Date.AddDays(1);
            var query = from pk in DataProvider.Ins.DB.PhieuKhams
                        join bn in DataProvider.Ins.DB.BenhNhans
                        on pk.MaBN equals bn.MaSoBN
                        where (pk.NgayKham >= Date.Date) && (pk.NgayKham < theNextDate.Date)
                        select new
                        {
                            hoten = bn.HoTen,
                            ngaykham = pk.NgayKham,
                            loaibenh = DataProvider.Ins.DB.LoaiBenhs.Where(x => x.MaBenh == pk.MaLoaiBenh).FirstOrDefault().TenBenh,
                            trieuchung = pk.TrieuChung
                        };
            
            int stt = 1;
            foreach(var i in query)
            {
                PatientList.Add(new PatientCollector(stt, i.hoten, i.ngaykham, i.loaibenh, i.trieuchung));
                stt++;
            }
        }
        public SearchPatientViewModel() 
        {
        }

        
    }
}
