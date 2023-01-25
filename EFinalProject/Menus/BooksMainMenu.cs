using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EFinalProject.AppContext;
using EFinalProject.Models;
using EFinalProject.Repositories;

namespace EFinalProject.Menus
{
    public class BooksMainMenu
    {
        public void BooksMenu()
        {
            Console.WriteLine("Выберите из списка меню: \n" +
                              "1. Показать все книги \n" +
                              "2. Поиск книги по Id \n" +
                              "3. Добавить новую книгу\n" +
                              "4. Удалить книгу\n" +
                              "5. Обновить дату написания книги\n" +
                              "6. Добавить нового автора\n" +
                              "7. Добавить новый жанр\n" +
                              "8. Выйти в главное меню\n");
            int BookChoise = int.Parse(Console.ReadLine());
            BookRepository book = new BookRepository();
            Menu menu = new Menu();

            switch (BookChoise)
            {
                case 1:
                    {
                        book.ShowBooks();
                        break;

                    }
                case 2:
                    {
                        Console.WriteLine("Введите Id книги");
                        int BookId = int.Parse(Console.ReadLine());

                        book.ShowBookById(BookId);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Введите название книги:");
                        string BookName = Console.ReadLine();

                        Console.WriteLine("Введите год ее написания:");
                        int Date = int.Parse(Console.ReadLine());

                        book.AddBook(BookName, Date);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Введите Id книги");
                        int BookId = int.Parse(Console.ReadLine());

                        book.DeleteBookById(BookId);
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Введите Id книги");
                        int BookId = int.Parse(Console.ReadLine());

                        Console.WriteLine("Введите новый год написания книги");
                        int NewDate = int.Parse(Console.ReadLine());

                        book.UpdateBookCreatedDate(BookId, NewDate);
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Введите имя автора");
                        string AuthorName = Console.ReadLine();
                        book.AddAuthor(AuthorName);
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("Введите название жанра");
                        string GenerName = Console.ReadLine();
                        book.AddGener(GenerName);
                        break;
                    }
                case 8:
                    {
                        menu.MainMenu();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Такого пункта меню нет!");
                        BooksMenu();
                        break;
                    }
            }
        }
    }
}
