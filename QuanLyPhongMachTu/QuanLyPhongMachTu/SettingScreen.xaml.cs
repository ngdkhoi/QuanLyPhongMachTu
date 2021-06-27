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
    /// Interaction logic for SettingScreen.xaml
    /// </summary>
    public partial class SettingScreen : UserControl
    {
        public SettingScreen()
        {
            InitializeComponent();
        }

        private void ListMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;

            switch (index)
            {
                case 0:
                    GridChildren.Children.Clear();
                    GridChildren.Children.Add(new MedicineReportScreen());
                    break;
                case 1:
                    GridChildren.Children.Clear();
                    GridChildren.Children.Add(new SettingRuleScreen());
                    break;
                default:
                    break;
            }
        }
    }
}
