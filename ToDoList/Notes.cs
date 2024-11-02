using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Notes
    {
        public string nameNotes;
        public StringBuilder textNotes = new StringBuilder();
        public bool status;
        public string nameUser;
        public int deadline;

        public Notes(string nameNotes, StringBuilder textNotes, string nameUser, int deadline)
        {
            this.nameNotes = nameNotes;
            this.textNotes = textNotes;
            this.nameUser = nameUser;
            this.deadline = deadline;
            status = false;
        }
        public void ShowNote() 
        {
            Console.WriteLine($"Название задачи {nameNotes}\nСодержание задачи:\n");
            Gui.PrintTextNote(textNotes);
            Console.WriteLine($"Кто назначил: {nameUser}");
        }
        
    }
}
