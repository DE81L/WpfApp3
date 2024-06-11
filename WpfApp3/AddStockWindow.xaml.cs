using System;
using System.Windows;
using WpfApp3.Models;

namespace WpfApp3
{
    public partial class AddStockWindow : Window
    {
        // Свойство для хранения нового объекта Stock
        public Stock Stock { get; set; }

        public AddStockWindow()
        {
            InitializeComponent();
            Stock = new Stock();
            DataContext = Stock;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        // Обработчик события нажатия кнопки "Добавить"
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Создание нового объекта Stock с данными из текстовых полей
                Stock = new Stock
                {
                    PharmacyId = int.Parse(PharmacyIdTextBox.Text),
                    DrugId = int.Parse(DrugIdTextBox.Text),
                    ReleaseDate = DateTime.Parse(ReleaseDateTextBox.Text),
                    Quantity = int.Parse(QuantityTextBox.Text),
                    Price = decimal.Parse(PriceTextBox.Text)
                };

                // Проверка корректности введенных данных о запасах
                Stock.Validate();

                // Установка DialogResult в true для указания успешного добавления
                DialogResult = true;
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке, если происходит исключение при создании или проверке запасов
                MessageBox.Show($"Error: {ex.Message}", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}