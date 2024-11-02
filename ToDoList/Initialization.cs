using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Initialization
    {
        public static User Registration()
        {
            Console.WriteLine("Введите ваше имя");
            string name = Console.ReadLine();
            name = ChoiceCheck.CheckNullField(name);

            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();
            login = ChoiceCheck.CheckNullField(login);
            while(DataUser.CheckRepeatLogin(login))
            {
                Console.WriteLine("Пользователь с данным логином уже существует введите другой!");
                login = Console.ReadLine();
                login = ChoiceCheck.CheckNullField(login);
            }

            Console.WriteLine("Введите пароль");
            string password = Console.ReadLine();
            password = ChoiceCheck.CheckNullField(password);
            Console.WriteLine("Повторите пароль");

            string repeatpassword = Console.ReadLine();
            repeatpassword = ChoiceCheck.CheckNullField(repeatpassword);

            while (repeatpassword != password)
            {
                Console.WriteLine("Пароли не совпадают\nПопробуйте снова");

                Console.WriteLine("Введите пароль");
                password = Console.ReadLine();
                password = ChoiceCheck.CheckNullField(password);

                Console.WriteLine("Повторите пароль");
                repeatpassword = Console.ReadLine();
                repeatpassword = ChoiceCheck.CheckNullField(repeatpassword);
            }

            User NewUser = new User(name, login, password);
            return NewUser;
        }
        public static User LogIn()
        {
            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();
            login = ChoiceCheck.CheckNullField(login);
            

            Console.WriteLine("Введите пароль");
            string password = Console.ReadLine();
            password = ChoiceCheck.CheckNullField(password);
            while (DataUser.CheckTrueLoginAndPassword(login, password).id == 0)
            {
                Console.WriteLine("Неверный логи или пароль!");

                Console.WriteLine("Введите логин");
                login = Console.ReadLine();
                login = ChoiceCheck.CheckNullField(login);

                Console.WriteLine("Введите пароль");
                password = Console.ReadLine();
                password = ChoiceCheck.CheckNullField(password);
            }
            return DataUser.CheckTrueLoginAndPassword(login, password);
        }
    }
}
