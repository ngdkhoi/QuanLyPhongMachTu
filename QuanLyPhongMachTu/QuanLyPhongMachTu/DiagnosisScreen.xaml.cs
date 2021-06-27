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
using QuanLyPhongMachTu.Model;

namespace QuanLyPhongMachTu
{
    /// <summary>
    /// Interaction logic for DiagnosisScreen.xaml
    /// </summary>
    public partial class DiagnosisScreen : UserControl
    {
        public DiagnosisScreen()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).DataContext as DetailPrescriptionCollector;
            a.DonVi = (e.AddedItems[0] as MedicineCollector).DonVi;
            
        }
    }
}
