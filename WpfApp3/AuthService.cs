using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class AuthService
    {
        private List<User> Users { get; set; } = new List<User>
    {
        new User { Username = "Главврач", Password = "password", Role = UserRole.Главврач },
        new User { Username = "Пациент", Password = "password", Role = UserRole.Пациент },
        new User { Username = "Иванов", Password = "password", Role = UserRole.Аптекарь },
        new User { Username = "Петров", Password = "password", Role = UserRole.Аптекарь },
        new User { Username = "Сидоров", Password = "password", Role = UserRole.Аптекарь },
        new User { Username = "1", Password = "1", Role = UserRole.Главврач }
    };

        public User Authenticate(string username, string password)
        {
            return Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
