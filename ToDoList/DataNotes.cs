using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ToDoList
{
    public class DataNotes
    {
        public static List<Notes> ListNotes = new();
        public static void AddNotes(User person)
        {
            Console.WriteLine("Создание новой задачи");
            Console.WriteLine("Добавьте название");
            string name = Console.ReadLine();
            ChoiceCheck.CheckNullField(name);
            Console.WriteLine(@"Введите задачу (чтобы завершить в новой строке введите комбинацию \!)");
            StringBuilder textNotes = new StringBuilder();
            string line = Console.ReadLine();
            while (line != @"\!")
            {
                textNotes.AppendLine(line);
                line = Console.ReadLine();
            }
            Console.WriteLine("Введите дедлайн");
            int deadline = int.Parse(ChoiceCheck.CheckNullField(Console.ReadLine()));
            Notes newNote = new Notes(name, textNotes, person.name, deadline, person.id, person.id);
            ListNotes.Add(newNote);
        }
        public static void AddOtherUserNotes(int UserId, int IdCustomer)
        {
            Console.WriteLine("Создание новой задачи");
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
            int deadline = int.Parse(ChoiceCheck.CheckNullField(Console.ReadLine()));
            Notes newNote = new Notes(name, textNotes, DataUser.GetName(UserId), deadline, UserId, IdCustomer);
            ListNotes.Add(newNote);
        }
        public static void AddGeneralNotes(User person)
        {
            Console.WriteLine("Создание общей задачи");
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
            int deadline = int.Parse(ChoiceCheck.CheckNullField(Console.ReadLine()));
            Notes newNote = new Notes(name, textNotes, "Общая задача", deadline, 0, person.id);
            ListNotes.Add(newNote);
        }
        public static void ReadNotes()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string path = Path.Combine(projectDir, @"DataNotes.csv");
            using (StreamReader NotesList = new StreamReader(path, Encoding.GetEncoding(1251)))
            {
                string NotesInformation;
             while ((NotesInformation = NotesList.ReadLine()) != null)
                {
                    string[] lines = NotesInformation.Split(";");
                    int idNote = int.Parse(lines[0]);
                    string nameNotes = lines[1];
                    bool status = false;
                    if (lines[2] == "True")
                    {
                        status = true;
                    }
                    string nameUser = lines[3];
                    int deadline = int.Parse(lines[4]);
                    StringBuilder textNote = new StringBuilder();
                    int userId = int.Parse(lines[5]);
                    int IdCustomer = int.Parse(lines[6]);
                    DateTime dateCreate = new DateTime(int.Parse(lines[9]), int.Parse(lines[8]), int.Parse(lines[7]));
                    for (int i = 10; i < lines.Length; i++)
                    {
                        textNote.AppendLine(lines[i]);
                    }
                    Notes newNote = new Notes(idNote, nameNotes, textNote, nameUser, deadline, userId, dateCreate, status, IdCustomer);
                    ListNotes.Add(newNote);
                }
            }
        }
        public static void SaveNotesFiles()
        {
            var fullData = new StringBuilder();
            string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string path = Path.Combine(projectDir, @"DataNotes.csv");
            foreach (var note in ListNotes)
            {
                string separator = ";";
                string textNote = "";
                foreach (string text in note.textNotes.ToString().Split('\r','\n'))
                {
                    if (!(string.IsNullOrEmpty(text)))
                    {
                        textNote += text + ";";
                    }
                }
                string[] dateCreate = note.dateCreate.ToString("d").Split(".");
                string[] newLine = { note.idNote.ToString(), note.nameNotes, note.status.ToString(), note.nameUser, note.deadline.ToString(), note.userId.ToString(), note.userCustomerId.ToString(),
                    dateCreate[0], dateCreate[1], dateCreate[2], textNote };
                string line = string.Join(separator, newLine);
                fullData.AppendLine(line);
            }
            try
            {
                using (StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding(1251)))
                {
                    writer.Write(fullData.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи файла: {ex.Message}");
            }
        }
        public static List<Notes> SearchUserNote(User user)
        {
            List<Notes> userNotes = new List<Notes>();
            foreach (var note in ListNotes)
            {
                if (note.userId == user.id)
                {
                    userNotes.Add(note);
                }
            }
            return userNotes;
        }
        public static void ShowNoteAllUsers(User user)
        {
            List<int> checkedUser = new();
            foreach (var note in ListNotes)
            {
                if (note.userId != user.id && !(checkedUser.Contains(note.userId)) && note.userId != 0)
                {
                    DataUser.GetNoteUser(note.userId);
                    checkedUser.Add(note.userId);
                }
            }
            if (checkedUser.Count == 0)
            {
                Console.WriteLine("У пользователей нет задач\n");
            }
        }
        public static void ShowGeneralNotes()
        {
            Console.WriteLine("Общие задачи:\n");
            foreach (var note in ListNotes)
            {
                if (note.userId == 0)
                {
                    note.ShowNote();
                }
            }
        }
        public static bool ChangeNotes(int idNote)
        {
            ColorConsole color = new ColorConsole();
            bool checkEntry = false;
            foreach (var note in ListNotes)
            {
                checkEntry = true;
                if (note.idNote == idNote)
                {
                    Console.WriteLine($"Текущее название: {note.nameNotes}");
                    Console.WriteLine("Введите новое или оставьте поле пустым(название не изменится)");
                    string newNameNotes = Console.ReadLine();
                    if (newNameNotes != null)
                    {
                        note.nameNotes = newNameNotes;
                    }
                    Console.WriteLine($"Текущее содержание задачи:");
                    Gui.PrintTextNote(note.textNotes);
                    string title = "Выбирите действие:";
                    string[] text = { "Оставить без изменений", "Изменить" };
                    Gui.PrintChoice(text, title);
                    string choice = Console.ReadLine();
                    choice = ChoiceCheck.CheckCorrectChoice(choice, 0, 3);
                    if (choice == "2")
                    {
                        Console.WriteLine("Введите задачу");
                        StringBuilder NewTextNotes = new StringBuilder();
                        string line = Console.ReadLine();
                        while (line != @"\!")
                        {
                            NewTextNotes.AppendLine(line);
                            line = Console.ReadLine();
                        }
                        note.textNotes = NewTextNotes;

                    }
                    Console.WriteLine($"Текущее дедлайн: {note.deadline}");
                    Console.WriteLine("Введите новое или оставьте поле пустым(дедлайн не изменится)");
                    string newdeadline = Console.ReadLine();
                    if( newdeadline != "" )
                    {
                        note.deadline = int.Parse( newdeadline );
                        note.dateCreate = DateTime.Now;
                    }
                    return true;
                }
            }
            return false;

        }
        public static void RemoveNote(int idNote)
        {
            ColorConsole color = new ColorConsole();
            foreach (var note in ListNotes)
            {
                if (note.idNote == idNote)
                {
                    ListNotes.Remove(note);
                    break;
                }
            }
            Console.WriteLine($"{color.YELLOW}Задачи с таким id не существует!!!{color.NORMAL}");
        }
        public static void CompletedNote(int idNote)
        {
            ColorConsole color = new ColorConsole();
            foreach (var note in ListNotes)
            {
                if (note.idNote == idNote)
                {
                    note.status = true;
                }
            }
            Console.WriteLine($"{color.YELLOW}Задачи с таким id не существует!!!{color.NORMAL}");
        }
    }
}
