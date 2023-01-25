using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFinalProject.AppContext;
using EFinalProject.Models;
using EFinalProject.Repositories;

namespace EFinalProject.Menus
{
    public class Menu
    {
        public void MainMenu()
        {
            Console.WriteLine("Выберите из списка меню: \n" +
                                "1. Работа с пользователями \n" +
                                "2. Работа с книгами \n" +
                                "3. Работа по третьей части\n" +
                                "4. Завершить работу\n");
            int ChooseObjecct = int.Parse(Console.ReadLine());

            UserMainMenu user = new UserMainMenu();
            BooksMainMenu books = new BooksMainMenu();
            ExcersizeMenu excersize = new ExcersizeMenu();

            switch (ChooseObjecct)
            {
                case 1:
                    { 
                        user.UserMenu();
                        break;
                    }
                case 2:
                    {
                        books.BooksMenu();
                        break;
                    }
                case 3:
                    {
                        excersize.ExMenu();
                        break;
                    }
                case 4:
                    {
                        System.Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Такого пункта меню нет!");
                        MainMenu();
                        break;
                    }
            }
        }
    }
}
