using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class DataNotes
    {
        public static List<Notes> ListNotes = new();
        public static void AddNotes(User person)
        {
            Console.WriteLine("Добавьте название");
            string name = Console.ReadLine();
            ChoiceCheck.CheckNullField(name);
            Console.WriteLine("Введите задачу");
            StringBuilder textNotes = new StringBuilder();
            string line = Console.ReadLine();
            while (line != @"\!")
            {
                textNotes.AppendLine(line);
                line = Console.ReadLine();
            }
            Console.WriteLine("Введите дедлайн");
            int deadline = int.Parse(Console.ReadLine());
            Notes newNote = new Notes(name, textNotes, person.name, deadline);
            ListNotes.Add(newNote);
        }
        public static void ShowNotes()
        {
            foreach (Notes notes in ListNotes)
            {
                notes.ShowNote();
            }
        }

    }
}
