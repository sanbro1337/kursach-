using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class DataUser
    {
        public static List<User> Users = new();
        public static void AddUser(User user)
        {
            Users.Add(user);
        }
        public static bool CheckRepeatLogin(string newLogin)
        {
            foreach (var user in Users)
            {
                if (user.login == newLogin)
                {
                    return true;
                }
            }
            return false;
        }
        public static User CheckTrueLoginAndPassword(string newLogin, string password)
        {
            foreach (var user in Users)
            {
                if (user.login == newLogin && user.password == password)
                {
                    return user;
                }
            }
            var usernull = new User();
            return usernull;
        }
        public static void ReadFileUsers()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string path = Path.Combine(projectDir, @"DataUser.csv");
            using (StreamReader UserList = new StreamReader(path, Encoding.GetEncoding(1251)))
            {
                string UserInformation;
                while ((UserInformation = UserList.ReadLine()) != null)
                {
                    string[] lines = UserInformation.Split(";");
                    int id = int.Parse(lines[0]);
                    string name = lines[1];
                    string login = lines[2];
                    string password = lines[3];
                    User newUser = new User(id, name, login, password);
                }
            }
        }
        public static void SaveFileUser()
        {
            var fullData = new StringBuilder();
            string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string path = Path.Combine(projectDir, @"DataUser.csv");
            foreach (var user in Users)
            {
                string separator = ";";
                string[] newLine = { user.id.ToString(), user.name, user.login, user.password };
                string line = string.Join(separator, newLine);
                fullData.AppendLine(line);
            }
            try
            {
                using (StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding(1251)))
                {
                    writer.Write(fullData.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи файла: {ex.Message}");
            }
        }
        public static string GetName(int id)
        {
            foreach (var user in Users)
            {
                if (user.id == id)
                {
                    return user.name;
                }
            }
            return "Ошибка";
        }
        public static void GetNoteUser(int id)
        {
            foreach (var user in Users)
            {
                if (user.id == id)
                {
                    Console.WriteLine($"Задачи пользователя: {user.name}\n");
                    user.ShowNotes();
                }
            }
        }
        public static bool CheckAvailabilityUser(int id)
        {
            ColorConsole color = new ColorConsole();
            foreach (var user in Users)
            {
                if (user.id == id)
                {
                    return true;
                }
            }
            Console.WriteLine($"{color.YELLOW}Пользователя с таким id не существует!!!{color.NORMAL}");
            return false;
        }
    }
}
