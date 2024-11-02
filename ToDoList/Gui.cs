using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Gui
    {
        public static void PrintChoice(string[] choice, string title)
        {
            Console.WriteLine(title);
            for (int i = 0; i < choice.Length; i++)
            {
                Console.WriteLine($"{i+1} {choice[i]}");
            }
        }
        public static void PrintTextNote(StringBuilder Text)
        {
            foreach(string text in Text.ToString().Split('\n'))
            {
                Console.WriteLine(text);
            }
        }
    }
}
