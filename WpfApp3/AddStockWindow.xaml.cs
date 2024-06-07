using System;
using System.Windows;
using WpfApp3.Models;

namespace WpfApp3
{
    public partial class AddStockWindow : Window
    {
        public Stock Stock { get; private set; }

        public AddStockWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Stock = new Stock
                {
                    PharmacyId = int.Parse(PharmacyIdTextBox.Text),
                    DrugId = int.Parse(DrugIdTextBox.Text),
                    ReleaseDate = DateTime.Parse(ReleaseDateTextBox.Text),
                    Quantity = int.Parse(QuantityTextBox.Text),
                    Price = decimal.Parse(PriceTextBox.Text)
                };
                Stock.Validate();
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
