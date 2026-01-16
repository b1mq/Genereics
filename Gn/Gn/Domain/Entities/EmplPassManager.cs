using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gn.Domain.Entities
{
class EmployeePasswordManager
    {
        private Dictionary<string, string> employees = new Dictionary<string, string>();

        public bool AddEmployee(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Логин и пароль не могут быть пустыми!");
                return false;
            }

            if (employees.ContainsKey(login))
            {
                Console.WriteLine($"Сотрудник с логином '{login}' уже существует!");
                return false;
            }

            employees.Add(login, password);
            Console.WriteLine($"Сотрудник {login} успешно добавлен.");
            return true;
        }

        public bool RemoveEmployee(string login)
        {
            if (employees.Remove(login))
            {
                Console.WriteLine($"Сотрудник {login} удалён.");
                return true;
            }

            Console.WriteLine($"Сотрудник с логином '{login}' не найден.");
            return false;
        }

        public bool ChangePassword(string login, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                Console.WriteLine("Новый пароль не может быть пустым!");
                return false;
            }

            if (employees.ContainsKey(login))
            {
                employees[login] = newPassword;
                Console.WriteLine($"Пароль для {login} успешно изменён.");
                return true;
            }

            Console.WriteLine($"Сотрудник с логином '{login}' не найден.");
            return false;
        }

        public string GetPassword(string login)
        {
            if (employees.TryGetValue(login, out string password))
            {
                return password;
            }

            Console.WriteLine($"Сотрудник с логином '{login}' не найден.");
            return null;
        }

        public void ShowAllEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("Список сотрудников пуст.");
                return;
            }

            Console.WriteLine("\nСписок сотрудников:");
            foreach (var kvp in employees)
            {
                Console.WriteLine($"Логин: {kvp.Key,-15} | Пароль: {kvp.Value}");
            }
        }
    }
}
