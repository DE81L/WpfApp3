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
        private User _currentUser;

        public MainWindow()
        {
            InitializeComponent();
            _dataService = new DataService();

            // Окно авторизации
            var authService = new AuthService();
            var loginWindow = new LoginWindow(authService);
            if (loginWindow.ShowDialog() == true)
            {
                _currentUser = loginWindow.LoggedInUser;
                LoadData();
            }
            else
            {
                Close();
            }
        }

        private void LoadData()
        {
            PharmacyDataGrid.ItemsSource = _dataService.Pharmacies;
            DrugDataGrid.ItemsSource = _dataService.Drugs;
            StockDataGrid.ItemsSource = _dataService.Stock;
        }

        private void AddPharmacy_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddPharmacyWindow();
            if (window.ShowDialog() == true)
            {
                _dataService.AddPharmacy(window.Pharmacy);
            }
        }

        private void EditPharmacy_Click(object sender, RoutedEventArgs e)
        {
            if (PharmacyDataGrid.SelectedItem is Pharmacy selectedPharmacy)
            {
                var window = new AddPharmacyWindow
                {
                    Pharmacy = selectedPharmacy
                };
                if (window.ShowDialog() == true)
                {
                    var index = _dataService.Pharmacies.IndexOf(selectedPharmacy);
                    _dataService.Pharmacies[index] = window.Pharmacy;
                    _dataService.SaveData();
                }
            }
        }

        private void DeletePharmacy_Click(object sender, RoutedEventArgs e)
        {
            if (PharmacyDataGrid.SelectedItem is Pharmacy selectedPharmacy)
            {
                _dataService.Pharmacies.Remove(selectedPharmacy);
                _dataService.SaveData();
            }
        }

        private void AddDrug_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddDrugWindow();
            if (window.ShowDialog() == true)
            {
                _dataService.AddDrug(window.Drug);
            }
        }

        private void EditDrug_Click(object sender, RoutedEventArgs e)
        {
            if (DrugDataGrid.SelectedItem is Drug selectedDrug)
            {
                var window = new AddDrugWindow
                {
                    Drug = selectedDrug
                };
                if (window.ShowDialog() == true)
                {
                    var index = _dataService.Drugs.IndexOf(selectedDrug);
                    _dataService.Drugs[index] = window.Drug;
                    _dataService.SaveData();
                }
            }
        }

        private void DeleteDrug_Click(object sender, RoutedEventArgs e)
        {
            if (DrugDataGrid.SelectedItem is Drug selectedDrug)
            {
                _dataService.Drugs.Remove(selectedDrug);
                _dataService.SaveData();
            }
        }

        private void AddStock_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddStockWindow();
            if (window.ShowDialog() == true)
            {
                _dataService.AddStock(window.Stock);
            }
        }

        private void EditStock_Click(object sender, RoutedEventArgs e)
        {
            if (StockDataGrid.SelectedItem is Stock selectedStock)
            {
                var window = new AddStockWindow
                {
                    Stock = selectedStock
                };
                if (window.ShowDialog() == true)
                {
                    var index = _dataService.Stock.IndexOf(selectedStock);
                    _dataService.Stock[index] = window.Stock;
                    _dataService.SaveData();
                }
            }
        }

        private void DeleteStock_Click(object sender, RoutedEventArgs e)
        {
            if (StockDataGrid.SelectedItem is Stock selectedStock)
            {
                _dataService.Stock.Remove(selectedStock);
                _dataService.SaveData();
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
