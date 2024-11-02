using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class User
    {
        private static int counter = 0;
        public int id;
        public string name;
        public string login;
        public string password;
        public User() { id = 0; }
        public User(string name, string login, string password)
        {
            id = ++counter;
            this.name = name;
            this.login = login;
            this.password = password;
            DataUser.AddUser(this);
        }
        public User(int id, string name, string login, string password)
        {
            this.id = id;
            counter = id;
            this.name = name;
            this.login = login;
            this.password = password;
            DataUser.AddUser(this);
        }

    }
}
