﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow _Instance;

        public MainWindow()
        {
            InitializeComponent();
            _Instance = this;
            ListViewMenu.SelectedIndex = 0;
        }


        //public MainWindow()
        //{
        //    InitializeComponent();
        //    ListViewMenu.SelectedIndex = 0;
        //}

        private int _selectedIndex = 0;

        public static MainWindow Instance 
        { 
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MainWindow();
                }

                return _Instance;
            }
            set =>  _Instance = value; 
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
                    var diagnosisScreen = DiagnosisScreen.Instance();
                    if (diagnosisScreen != null)
                    {
                        GridPriciple.Children.Clear();
                        GridPriciple.Children.Add(diagnosisScreen);
                    }
                    else
                    {
                        ListViewMenu.SelectedIndex = _selectedIndex;
                        return;
                    }
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
            _selectedIndex = index;
        }
    }
}
