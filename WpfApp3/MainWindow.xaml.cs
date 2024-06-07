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

        // Конструктор
        public MainWindow()
        {
            InitializeComponent();
            // Создание экземпляра DataService для доступа к данным
            _dataService = new DataService();
            // Обновление отображаемых данных в таблицах
            RefreshDataGrids();
        }

        // Метод для обновления данных в таблицах
        private void RefreshDataGrids()
        {
            // Загрузка данных аптек, лекарств и запасов в соответствующие таблицы
            PharmacyDataGrid.ItemsSource = _dataService.Pharmacies.ToList();
            DrugDataGrid.ItemsSource = _dataService.Drugs.ToList();
            StockDataGrid.ItemsSource = _dataService.Stock.ToList();
        }

        // Обработчик события нажатия кнопки "Добавить аптеку"
        private void AddPharmacy_Click(object sender, RoutedEventArgs e)
        {
            // Открытие окна добавления аптеки
            var addPharmacyWindow = new AddPharmacyWindow();
            // Если окно закрывается с результатом true (т.е. аптека успешно добавлена)
            if (addPharmacyWindow.ShowDialog() == true)
            {
                // Добавление аптеки в данные и обновление таблиц
                _dataService.AddPharmacy(addPharmacyWindow.Pharmacy);
                RefreshDataGrids();
            }
        }

        // Обработчик события нажатия кнопки "Добавить лекарство"
        private void AddDrug_Click(object sender, RoutedEventArgs e)
        {
            // Открытие окна добавления лекарства
            var addDrugWindow = new AddDrugWindow();
            // Если окно закрывается с результатом true (т.е. лекарство успешно добавлено)
            if (addDrugWindow.ShowDialog() == true)
            {
                // Добавление лекарства в данные и обновление таблиц
                _dataService.AddDrug(addDrugWindow.Drug);
                RefreshDataGrids();
            }
        }

        // Обработчик события нажатия кнопки "Добавить запасы"
        private void AddStock_Click(object sender, RoutedEventArgs e)
        {
            // Открытие окна добавления запасов
            var addStockWindow = new AddStockWindow();
            // Если окно закрывается с результатом true (т.е. запасы успешно добавлены)
            if (addStockWindow.ShowDialog() == true)
            {
                // Добавление запасов в данные и обновление таблиц
                _dataService.AddStock(addStockWindow.Stock);
                RefreshDataGrids();
            }
        }

        // Обработчик события нажатия кнопки "Загрузить данные об антибиотиках"
        private void LoadAntibioticsData_Click(object sender, RoutedEventArgs e)
        {
            // Загрузка и отображение данных об антибиотиках
            AntibioticsDataGrid.ItemsSource = _dataService.Find24HourAntibiotics();
        }

        // Обработчик события нажатия кнопки "Анализ цен на лекарства"
        private void AnalyzeDrugPrices_Click(object sender, RoutedEventArgs e)
        {
            // Анализ цен на лекарства и отображение результатов
            DrugPricesDataGrid.ItemsSource = _dataService.AnalyzeDrugPrices();
        }
    }
}