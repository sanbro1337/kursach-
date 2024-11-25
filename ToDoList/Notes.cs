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
        public int userId;
        public DateTime dateCreate;
        
        // конструктор для инициализации новых заметок
        public Notes(string nameNotes, StringBuilder textNotes, string nameUser, int deadline, int userId)
        {
            idNote = ++counter;
            this.nameNotes = nameNotes;
            this.textNotes = textNotes;
            this.nameUser = nameUser;
            this.deadline = deadline;
            status = false;
            this.userId = userId;
            this.dateCreate = DateTime.Now;
        }
        // конструктор для загрузки заметок из файла
        public Notes(int idNote, string nameNotes, StringBuilder textNotes, string nameUser, int deadline, int userId, DateTime dateCreate)
        {
            counter = idNote; 
            this.idNote = idNote;
            this.nameNotes = nameNotes;
            this.textNotes = textNotes;
            this.nameUser = nameUser;
            status = false;
            this.userId = userId;
            this.deadline = deadline - (int)((DateTime.Now - dateCreate).TotalDays);
            this.dateCreate = dateCreate;
        }
        public void ShowNote() 
        {
            ColorConsole color = new ColorConsole();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine($"Id задачи: {idNote}\nНазвание задачи: {nameNotes}\nСодержание задачи:\n");
            Gui.PrintTextNote(textNotes);
            if (deadline > 0)
            {
                Console.WriteLine($"Осталось дней: {deadline}");
            }
            else
            {
                Console.WriteLine($"Осталось дней: {color.RED} {deadline} {color.NORMAL}");
            }
            Console.WriteLine($"Кто назначил: {nameUser}\n");
            Console.WriteLine("------------------------------------------------------------------------------------------");
        }
        
    }
}
