using System;
using System.Windows;
using WpfApp3.Models;

namespace WpfApp3
{
    public partial class AddDrugWindow : Window
    {
        public Drug Drug { get; private set; }

        public AddDrugWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Drug = new Drug
                {
                    Name = NameTextBox.Text,
                    Group = GroupTextBox.Text,
                    Dosage = DosageTextBox.Text,
                    ShelfLife = int.Parse(ShelfLifeTextBox.Text)
                };
                Drug.Validate();
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
