using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuanLyPhongMachTu.ViewModel;

namespace QuanLyPhongMachTu
{
    /// <summary>
    /// Interaction logic for MedicineScreen.xaml
    /// </summary>
    public partial class MedicineReportScreen : UserControl
    {
        public ReportViewModel VM { get; set; }
        public MedicineReportScreen()
        {
            InitializeComponent();
            this.DataContext = VM = new ReportViewModel();
        }
    }
}
