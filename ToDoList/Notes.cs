using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Notes
    {
        private static int counter = 0;
        public int idNote;
        public string nameNotes;
        public StringBuilder textNotes = new StringBuilder();
        public bool status;
        public string nameUser;
        public int deadline;
        public int userId; // Чья задача
        public int userCustomerId;// Кто назначил
        public DateTime dateCreate;
        
        // конструктор для инициализации новых заметок
        public Notes(string nameNotes, StringBuilder textNotes, string nameUser, int deadline, int userId, int userCustomerId)
        {
            idNote = ++counter;
            this.nameNotes = nameNotes;
            this.textNotes = textNotes;
            this.nameUser = nameUser;
            this.deadline = deadline;
            status = false;
            this.userId = userId;
            this.dateCreate = DateTime.Now;
            this.userCustomerId = userCustomerId;
        }
        // конструктор для загрузки заметок из файла
        public Notes(int idNote, string nameNotes, StringBuilder textNotes, string nameUser, int deadline, int userId, DateTime dateCreate, bool status, int userCustomerId)
        {
            counter = idNote; 
            this.idNote = idNote;
            this.nameNotes = nameNotes;
            this.textNotes = textNotes;
            this.nameUser = nameUser;
            this.status = status;
            this.userId = userId;
            this.deadline = deadline;
            //this.deadline = deadline - (int)((DateTime.Now - dateCreate).TotalDays);
            this.dateCreate = dateCreate;
            this.userCustomerId = userCustomerId;
        }
        public void ShowNote() 
        {
            ColorConsole color = new ColorConsole();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine($"Id задачи: {idNote}\nНазвание задачи: {nameNotes}\nСодержание задачи:\n");
            Gui.PrintTextNote(textNotes);
            if (status) 
            {
                Console.WriteLine($"Статус: {color.GREEN} задача выполнена  {color.NORMAL}");
            }
            else
            {
                if (deadline - (int)((DateTime.Now - dateCreate).TotalDays) > 0)
                {
                    Console.WriteLine($"Осталось дней: {deadline - (int)((DateTime.Now - dateCreate).TotalDays)}");
                }
                else
                {
                    Console.WriteLine($"Осталось дней: {color.RED} {deadline - (int)((DateTime.Now - dateCreate).TotalDays)} {color.NORMAL}");
                }
            }
            Console.WriteLine($"Кто назначил: Id - {userCustomerId} Ник - {DataUser.GetName(userCustomerId)}\n");
            Console.WriteLine("------------------------------------------------------------------------------------------");
        }
        
    }
}
