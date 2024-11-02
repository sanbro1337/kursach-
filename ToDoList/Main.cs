using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class MainProgramm
    {
        public static void InMainProgramm()
        {
            User person = new User();
            DataUser.ReadFileUsers("DataUser.csv");
            string title = "Выбирите действие:";
            string[] text = { "Вход", "Регистрация" };
            Gui.PrintChoice(text, title);
            string choice = Console.ReadLine();
            choice = ChoiceCheck.CheckCorrectChoice(choice, 0, 3);
            switch (choice)
            {
                case ("1"):
                    {
                        person = Initialization.LogIn();
                        break;
                    }
                case ("2"):
                    {
                        person = Initialization.Registration();
                        break;
                    }
            }
            while (true)
            {
            
            title = "Выбирите действие:";
            string[] text1 = { "Добавить задачу", "Посмотреть задачи" };
            Gui.PrintChoice(text1, title);
            choice = Console.ReadLine();
            choice = ChoiceCheck.CheckCorrectChoice(choice, 0, 3);
            switch (choice)
            {
                case ("1"):
                    {
                        DataNotes.AddNotes(person);
                        break;
                    }
                case ("2"):
                    {
                            DataNotes.ShowNotes();
                        break;
                    }
            }
            }
            DataUser.SaveFileUser();
        }
    }
}
