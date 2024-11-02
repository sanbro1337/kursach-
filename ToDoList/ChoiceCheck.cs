using System;
using System.Collections.Generic;
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
            while (!CheckBelong(choice, start, end))
            {
                Console.WriteLine("Некорректный выбор действия!\nПопробуйте снова");  
                choice = Console.ReadLine();
            }
            return choice;
        }
        public static string CheckNullField(string field)
        {
            while (string.IsNullOrEmpty(field) || string.IsNullOrWhiteSpace(field))
            {
                Console.WriteLine("Некорректное содержание!\nПопробуйте снова");
                field = Console.ReadLine();
            }
            return field;
        }
    }
}
