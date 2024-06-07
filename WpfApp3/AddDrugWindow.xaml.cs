using System;
using System.Windows;
using WpfApp3.Models;

namespace WpfApp3
{
    public partial class AddDrugWindow : Window
    {
        // Свойство для хранения нового объекта Drug
        public Drug Drug { get; private set; }

        // Конструктор
        public AddDrugWindow()
        {
            InitializeComponent();
        }

        // Обработчик события нажатия кнопки "Добавить"
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Создание нового объекта Drug с данными из текстовых полей
                Drug = new Drug
                {
                    Name = NameTextBox.Text,
                    Group = GroupTextBox.Text,
                    Dosage = DosageTextBox.Text,
                    ShelfLife = int.Parse(ShelfLifeTextBox.Text)
                };

                // Проверка корректности введенных данных о лекарстве
                Drug.Validate();

                // Установка DialogResult в true для указания успешного добавления
                DialogResult = true;
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке, если происходит исключение при создании или проверке лекарства
                MessageBox.Show($"Error: {ex.Message}", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}