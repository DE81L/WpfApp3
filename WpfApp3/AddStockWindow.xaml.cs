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
    /// Логика взаимодействия для AddStockWindow.xaml
    /// </summary>
    public partial class AddStockWindow : Window
    {
        private DataService _dataService;

        public AddStockWindow(DataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var stock = new Stock
            {
                PharmacyId = int.Parse(PharmacyIdTextBox.Text),
                DrugId = int.Parse(DrugIdTextBox.Text),
                ReleaseDate = DateTime.Parse(ReleaseDateTextBox.Text),
                Quantity = int.Parse(QuantityTextBox.Text),
                Price = decimal.Parse(PriceTextBox.Text)
            };

            _dataService.AddStock(stock);
            this.Close();
        }
    }

}
