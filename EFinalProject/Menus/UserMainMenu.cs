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
    public class UserMainMenu
    {
        public void UserMenu()
        {
            Console.WriteLine("Выберите из списка меню: \n" +
                               "1. Показать всех пользователей \n" +
                               "2. Поиск пользователя по Id \n" +
                               "3. Добавить нового пользователя\n" +
                               "4. Удалить пользователя\n" +
                               "5. Обновить имя пользователя\n" +
                               "6. Показать какие книги на руках у пользователя\n" +
                               "7. Добавить пользователю книгу\n" +
                               "8. Забрать у пользователя книгу по Id\n" +
                               "9. Выйти в главное меню\n");
            int UserChoise = int.Parse(Console.ReadLine());
            UserRepository user = new UserRepository();
            Menu menu = new Menu();
            switch (UserChoise)
            {
                case 1:
                    {
                        user.ShowUsers();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Введите Id пользователя");
                        int UserId = int.Parse(Console.ReadLine());
                        user.ShowUserById(UserId);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Введите имя пользователя");
                        string UserName = Console.ReadLine();
                        Console.WriteLine("Введите почту");
                        string UserEmail = Console.ReadLine();
                        user.AddNewUser(UserName, UserEmail);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Введите Id пользователя для его удаления");
                        int UserId = int.Parse(Console.ReadLine());
                        user.DeleteUserById(UserId);
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Введите Id пользователя");
                        int UserId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите имя пользователя");
                        string UserName = Console.ReadLine();
                        user.UpdateUserName(UserId, UserName);
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Введите Id пользователя");
                        int UserId = int.Parse(Console.ReadLine());
                        user.ShowUserBooks(UserId);
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("Введите Id пользователя");
                        int UserId = int.Parse(Console.ReadLine());
                        user.TakeBook(UserId);
                        break;
                    }
                case 8:
                    {
                        Console.WriteLine("Введите Id пользователя");
                        int UserId = int.Parse(Console.ReadLine());
                        user.DeleteBookFromUser(UserId);
                        break;
                    }
                case 9:
                    {
                        menu.MainMenu();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Такого пункта меню нет!");
                        UserMenu();
                        break;
                    }
            }
        }
    }
}
