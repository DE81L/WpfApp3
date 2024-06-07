using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp3.Models;
using WpfApp3.Services;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для AddPharmacyWindow.xaml
    /// </summary>
    public partial class AddPharmacyWindow : Window
    {
        private DataService _dataService;

        public AddPharmacyWindow(DataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var pharmacy = new Pharmacy
            {
                Name = NameTextBox.Text,
                Address = AddressTextBox.Text,
                StartHour = int.Parse(StartHourTextBox.Text),
                EndHour = int.Parse(EndHourTextBox.Text)
            };

            _dataService.AddPharmacy(pharmacy);
            this.Close();
        }
    }

}
