using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ToDoList
{
    public class ChoiceCheck
    {
        public static bool CheckBelong(string choice, int start, int end)
        {
            int number = 0;
            return !string.IsNullOrWhiteSpace(choice) && int.TryParse(choice, out number) && (number > start && number < end);
        }
        public static string CheckCorrectChoice(string choice, int start, int end)
        {
            ColorConsole color = new ColorConsole();
            while (!CheckBelong(choice, start, end))
            {
                Console.WriteLine($"{color.YELLOW}Некорректный выбор действия!\nПопробуйте снова{color.NORMAL}");
                choice = Console.ReadLine();
            }
            return choice;
        }
        public static string CheckNullField(string field)
        {
            ColorConsole color = new ColorConsole();
            while (string.IsNullOrEmpty(field) || string.IsNullOrWhiteSpace(field))
            {
                Console.WriteLine($"{color.YELLOW}Некорректное содержание!\nПопробуйте снова{color.NORMAL}");
                field = Console.ReadLine();
            }
            return field;
        }
    }
}
