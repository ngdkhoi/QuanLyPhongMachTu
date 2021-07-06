using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using QuanLyPhongMachTu.Model;

namespace QuanLyPhongMachTu.totalCostConverter
{
    public class TotalCostConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null) {
                var diag = value as PhieuKham;
                int sum = diag.TienKham + diag.TienThuoc;
                string con = sum.ToString("###,###,###,### VND").Replace(',', '.');
                return con;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
