using System;
using System.Windows;
using WpfApp3.Models;

namespace WpfApp3
{
    public partial class AddPharmacyWindow : Window
    {
        // Свойство для хранения нового объекта Pharmacy
        public Pharmacy Pharmacy { get; set; }

        // Конструктор
        public AddPharmacyWindow()
        {
            InitializeComponent();
            Pharmacy = new Pharmacy();
            DataContext = Pharmacy;
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
                // Создание нового объекта Pharmacy с данными из текстовых полей
                Pharmacy = new Pharmacy
                {
                    Name = NameTextBox.Text,
                    Address = AddressTextBox.Text,
                    StartHour = int.Parse(StartHourTextBox.Text),
                    EndHour = int.Parse(EndHourTextBox.Text)
                };

                // Проверка корректности введенных данных о аптеке
                Pharmacy.Validate();

                // Установка DialogResult в true для указания успешного добавления
                DialogResult = true;
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке, если происходит исключение при создании или проверке аптеки
                MessageBox.Show($"Error: {ex.Message}", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}