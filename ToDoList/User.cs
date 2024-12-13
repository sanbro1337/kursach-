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
        public List<Notes> myNotes;
        public User() { id = 0; }
        public User(string name, string login, string password)
        {
            id = ++counter;
            this.name = name;
            this.login = login;
            this.password = password;
            DataUser.AddUser(this);
        }
        //Конструктор для загрузки пользователей из файла
        public User(int id, string name, string login, string password)
        {
            this.id = id;
            counter = id;
            this.name = name;
            this.login = login;
            this.password = password;
            DataUser.AddUser(this);
        }
        public void ShowNotes()
        {
            myNotes = DataNotes.SearchUserNote(this);
            if (myNotes != null)
            {
                foreach (Notes note in myNotes)
                {
                    note.ShowNote();
                }
            }
            else { Console.WriteLine("Пока у вас нет задач"); }
            
        }


    }
}
