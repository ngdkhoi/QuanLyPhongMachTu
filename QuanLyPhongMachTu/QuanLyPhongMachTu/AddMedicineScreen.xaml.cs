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
    /// Interaction logic for AddMedicineScreen.xaml
    /// </summary>
    public partial class AddMedicineScreen : UserControl
    {
        public AddMedicineViewModel VM { get; set; }
        public AddMedicineScreen()
        {
            InitializeComponent();
            this.DataContext = VM = new AddMedicineViewModel();
        }
    }
}
