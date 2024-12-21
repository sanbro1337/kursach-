using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class MainProgram
    {
        public static void InMainProgram()
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
            string[] text1 = { "Добавить себе задачу", "Добавить общую задачу", "Добавить задачу другому пользователю", "Посмотреть свои задачи", "Посмотреть задачи других пользователей", "Посмотреть общие задачи"};
            Gui.PrintChoice(text1, title);
            choice = Console.ReadLine();
            choice = ChoiceCheck.CheckCorrectChoice(choice, 0, 7);
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
                case("3"):
                        {
                            Console.WriteLine("Введите id пользователя");
                            int idUser = int.Parse(Console.ReadLine());
                            while (!DataUser.CheckAvailabilityUser(idUser))
                            {
                                Console.WriteLine("Введите id пользователя");
                                idUser = int.Parse(Console.ReadLine());
                            }
                            DataNotes.AddOtherUserNotes(idUser, person.id);
                            break;
                        }
                case ("4"):
                        {
                            Console.Clear();
                            DataUser.GetNoteUser(person.id);
                            string titleChange = "Выбирите действие:";
                            string[] textChange = { "Изменить", "Удалить зачачу","Пометить как выполненую", "Закрыть" };
                            Gui.PrintChoice(textChange, titleChange);
                            string choiceChange = Console.ReadLine();
                            choiceChange = ChoiceCheck.CheckCorrectChoice(choiceChange, 0, 5);
                            switch (choiceChange)
                            {
                                case ("1"):
                                    {
                                        Console.WriteLine("Введите id задачи которую хотите изменить");
                                        int idNote = int.Parse(Console.ReadLine());
                                        while (!DataNotes.ChangeNotes(idNote))
                                        {
                                            DataUser.GetNoteUser(person.id);
                                            Console.WriteLine("Введите id задачи которую хотите изменить");
                                            idNote = int.Parse(Console.ReadLine());
                                        }
                                        break;
                                    }
                                case("2"):
                                    {
                                        Console.WriteLine("Введите id задачи которую хотите удалить");
                                        int idNote = int.Parse(Console.ReadLine());
                                        DataNotes.RemoveNote(idNote);
                                        break;
                                    }
                                case ("3"):
                                    {
                                        Console.WriteLine("Введите id задачи которую хотите пометить, как выполненную");
                                        int idNote = int.Parse(Console.ReadLine());
                                        DataNotes.CompletedNote(idNote);
                                        break;
                                    }
                                case ("4"):
                                    {
                                        break;
                                    }
                            }
                            break;
                        }
                case ("5"):
                        {
                            Console.Clear();
                            DataNotes.ShowNoteAllUsers(person);
                            Console.ReadKey();
                            break;
                        }
                case ("6"):
                        {
                            Console.Clear();
                            DataNotes.ShowGeneralNotes();
                            Console.ReadKey();
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
