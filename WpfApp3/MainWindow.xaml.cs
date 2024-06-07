using System;
using System.Linq;
using System.Windows;
using WpfApp3.Models;
using WpfApp3.Services;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        private readonly DataService _dataService;

        public MainWindow()
        {
            InitializeComponent();
            _dataService = new DataService();
            RefreshDataGrids();
        }

        private void RefreshDataGrids()
        {
            PharmacyDataGrid.ItemsSource = _dataService.Pharmacies.ToList();
            DrugDataGrid.ItemsSource = _dataService.Drugs.ToList();
            StockDataGrid.ItemsSource = _dataService.Stock.ToList();
        }

        private void AddPharmacy_Click(object sender, RoutedEventArgs e)
        {
            var addPharmacyWindow = new AddPharmacyWindow();
            if (addPharmacyWindow.ShowDialog() == true)
            {
                _dataService.AddPharmacy(addPharmacyWindow.Pharmacy);
                RefreshDataGrids();
            }
        }

        private void AddDrug_Click(object sender, RoutedEventArgs e)
        {
            var addDrugWindow = new AddDrugWindow();
            if (addDrugWindow.ShowDialog() == true)
            {
                _dataService.AddDrug(addDrugWindow.Drug);
                RefreshDataGrids();
            }
        }

        private void AddStock_Click(object sender, RoutedEventArgs e)
        {
            var addStockWindow = new AddStockWindow();
            if (addStockWindow.ShowDialog() == true)
            {
                _dataService.AddStock(addStockWindow.Stock);
                RefreshDataGrids();
            }
        }

        private void LoadAntibioticsData_Click(object sender, RoutedEventArgs e)
        {
            AntibioticsDataGrid.ItemsSource = _dataService.Find24HourAntibiotics();
        }

        private void AnalyzeDrugPrices_Click(object sender, RoutedEventArgs e)
        {
            DrugPricesDataGrid.ItemsSource = _dataService.AnalyzeDrugPrices();
        }
    }
}
