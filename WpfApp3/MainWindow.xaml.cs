using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp3.Services;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataService _dataService;

        public MainWindow()
        {
            InitializeComponent();
            _dataService = new DataService();
            LoadData();
        }

        private void LoadData()
        {
            PharmacyDataGrid.ItemsSource = _dataService.Pharmacies;
            DrugDataGrid.ItemsSource = _dataService.Drugs;
            StockDataGrid.ItemsSource = _dataService.Stock;
        }

        private void AddPharmacy_Click(object sender, RoutedEventArgs e)
        {
            var addPharmacyWindow = new AddPharmacyWindow(_dataService);
            addPharmacyWindow.ShowDialog();
            LoadData();
        }

        private void AddDrug_Click(object sender, RoutedEventArgs e)
        {
            var addDrugWindow = new AddDrugWindow(_dataService);
            addDrugWindow.ShowDialog();
            LoadData();
        }

        private void AddStock_Click(object sender, RoutedEventArgs e)
        {
            var addStockWindow = new AddStockWindow(_dataService);
            addStockWindow.ShowDialog();
            LoadData();
        }
    }
}
