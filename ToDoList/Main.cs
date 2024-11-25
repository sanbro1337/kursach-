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
            DataUser.ReadFileUsers();
            DataNotes.ReadNotes();
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
            Console.Clear();
            while (true)
            {
            
            title = "Выбирите действие:";
            string[] text1 = { "Добавить себе задачу", "Добавить общую задачу", "Посмотреть свои задачи", "Посмотреть задачи других пользователей", "Посмотреть общие задачи"};
            Gui.PrintChoice(text1, title);
            choice = Console.ReadLine();
            choice = ChoiceCheck.CheckCorrectChoice(choice, 0, 6);
            switch (choice)
            {
                case ("1"):
                        {
                            Console.Clear();
                            DataNotes.AddNotes(person);
                            break;
                        }
                case ("2"):
                        {
                            Console.Clear();
                            DataNotes.AddGeneralNotes(person);
                            break;
                        }
                case ("3"):
                        {
                            Console.Clear();
                            DataUser.GetNoteUser(person.id);
                            string titleChange = "Выбирите действие:";
                            string[] textChange = { "Изменить", "Удалить зачачу", "Закрыть" };
                            Gui.PrintChoice(textChange, titleChange);
                            string choiceChange = Console.ReadLine();
                            choiceChange = ChoiceCheck.CheckCorrectChoice(choiceChange, 0, 3);
                            if (choiceChange == "1")
                            {
                                Console.WriteLine("Введите id задачи которую хотите изменить");
                                int idNote = int.Parse(Console.ReadLine());
                                while (!DataNotes.ChangeNotes(idNote))
                                {
                                    DataUser.GetNoteUser(person.id);
                                    Console.WriteLine("Введите id задачи которую хотите изменить");
                                    idNote = int.Parse(Console.ReadLine());
                                }
                                
                            }
                            else if(choiceChange == "2")
                            {
                                Console.WriteLine("Введите id задачи которую хотите изменить");
                                int idNote = int.Parse(Console.ReadLine());
                                DataNotes.RemoveNote(idNote);
                            }
                            break;
                        }
                case ("4"):
                        {
                            Console.Clear();
                            DataNotes.ShowNoteAllUsers(person);
                            break;
                        }
                case ("5"):
                        {
                            Console.Clear();
                            DataNotes.ShowGeneralNotes();
                            break;
                        }
            }
                Console.Clear();
                DataUser.SaveFileUser();
                DataNotes.SaveNotesFiles();
            }
        }
    }
}
