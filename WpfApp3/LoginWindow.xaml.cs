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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private AuthService _authService;
        public User LoggedInUser { get; private set; }

        public LoginWindow(AuthService authService)
        {
            _authService = authService;
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var user = _authService.Authenticate(UsernameTextBox.Text, PasswordBox.Password);
            if (user != null)
            {
                LoggedInUser = user;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }
    }
}
