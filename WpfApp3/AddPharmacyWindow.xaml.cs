using System;
using System.Windows;
using WpfApp3.Models;

namespace WpfApp3
{
    public partial class AddPharmacyWindow : Window
    {
        public Pharmacy Pharmacy { get; private set; }

        public AddPharmacyWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pharmacy = new Pharmacy
                {
                    Name = NameTextBox.Text,
                    Address = AddressTextBox.Text,
                    StartHour = int.Parse(StartHourTextBox.Text),
                    EndHour = int.Parse(EndHourTextBox.Text)
                };
                Pharmacy.Validate();
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
