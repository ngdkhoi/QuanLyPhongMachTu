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

namespace QuanLyPhongMachTu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListViewMenu.SelectedIndex = 1;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;

            switch (index)
            {
                case 0:
                    GridPriciple.Children.Clear();
                    GridPriciple.Children.Add(new PatientListScreen());
                    break;
                case 1:
                    GridPriciple.Children.Clear();
                    GridPriciple.Children.Add(new DiagnosisScreen());
                    break;
                case 2:
                    GridPriciple.Children.Clear();
                    GridPriciple.Children.Add(new SearchScreen());
                    break;
                case 3:
                    GridPriciple.Children.Clear();
                    GridPriciple.Children.Add(new MedicineReportScreen());
                    break;
                case 4:
                    GridPriciple.Children.Clear();
                    GridPriciple.Children.Add(new RevenueScreen());
                    break;
                case 5:
                    GridPriciple.Children.Clear();
                    GridPriciple.Children.Add(new SettingScreen());
                    break;
                default:
                    break;
            }
        }
    }
}
