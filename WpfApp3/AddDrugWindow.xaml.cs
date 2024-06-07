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
    /// Логика взаимодействия для AddDrugWindow.xaml
    /// </summary>
    public partial class AddDrugWindow : Window
    {
        private DataService _dataService;

        public AddDrugWindow(DataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var drug = new Drug
            {
                Name = NameTextBox.Text,
                Group = GroupTextBox.Text,
                Dosage = DosageTextBox.Text,
                ShelfLife = int.Parse(ShelfLifeTextBox.Text)
            };

            _dataService.AddDrug(drug);
            this.Close();
        }
    }

}
