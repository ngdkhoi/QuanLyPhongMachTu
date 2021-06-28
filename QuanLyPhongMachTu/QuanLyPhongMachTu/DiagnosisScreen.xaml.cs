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
using QuanLyPhongMachTu.ViewModel;

namespace QuanLyPhongMachTu
{
    /// <summary>
    /// Interaction logic for DiagnosisScreen.xaml
    /// </summary>
    public partial class DiagnosisScreen : UserControl
    {
        private static DiagnosisScreen _instance;

        protected DiagnosisScreen(int patientID)
        {
            this.DataContext = new DiagnosisViewModel(patientID);
            InitializeComponent();
        }

        public static DiagnosisScreen Instance(int patientID)
        {
            if(_instance == null)
            {
                _instance = new DiagnosisScreen(patientID);
            }

            return _instance;
        }
        public static DiagnosisScreen Instance()
        {
            MessageBox.Show("Vui lòng chọn bệnh nhân!!");
            return null;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).DataContext as DetailPrescriptionCollector;
            a.DonVi = (e.AddedItems[0] as MedicineCollector).DonVi;
            
        }
    }
}
