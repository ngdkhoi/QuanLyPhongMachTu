using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;

namespace QuanLyPhongMachTu.dateConverter
{
    public class DateConveter :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strD = value.ToString();
            string[] DateAndTime = strD.Split(' ');
            string[] tmp = DateAndTime[0].Split('/');
            if (tmp[0].Length == 1)
            {
                tmp[0] = "0" + tmp[0];
            }
            if (tmp[1].Length == 1)
            {
                tmp[1] = "0" + tmp[1];
            }
            string Date = "";
            Date = tmp[1] + "/" + tmp[0] + "/" + tmp[2];
            return Date;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
