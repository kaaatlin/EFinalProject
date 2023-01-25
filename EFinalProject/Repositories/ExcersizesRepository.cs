using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFinalProject.AppContext;
using EFinalProject.Menus;
using EFinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EFinalProject.Repositories
{
    public class ExcersizesRepository
    {
        ExcersizeMenu excersize = new ExcersizeMenu();

        // Получать список книг определенного жанра и вышедших между определенными годами
        public void FirstExcesrsize()
        {
            using (var db = new AppContext.AppContext())
            {
                Console.WriteLine("Введите Id жанра");
                var geners = db.Geners.ToList();
                foreach (var gener in geners)
                {
                    Console.WriteLine(gener.Id + "\t" + gener.Name);
                }

                int generId = int.Parse(Console.ReadLine());

                var takeGener = db.Books.Where(g => g.GenerId == generId).ToList();

                Console.WriteLine("Введите первую дату");
                int FirstDate = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите вторую дату");
                int SecondDate = int.Parse(Console.ReadLine());

                var books = takeGener.Where(u => u.CreatedDate >= FirstDate && u.CreatedDate <= SecondDate).ToList();

                if (books.Count != 0)
                {
                    foreach (var book in books)
                    {
                        Console.WriteLine(book.Id + "\t" + book.Name);
                    }
                }
                else Console.WriteLine("Таких книг нет");
                excersize.ExMenu();
            }
        }

        //Получить количество книг определенного автора в библиотеке
        public void SecondExcersize()
        {
            using (var db = new AppContext.AppContext())
            {
                Console.WriteLine("Введите Id автора");

                var authors = db.Authors.ToList();
                foreach (var aurhor in authors)
                {
                    Console.WriteLine(aurhor.Id + "\t" + aurhor.Name);
                }

                int AuthorId = int.Parse(Console.ReadLine());

                var booksCount = db.Books.Where(a => a.AuthorId == AuthorId).ToList();
                if (booksCount.Count != 0)
                {
                    Console.WriteLine("Количество книг этого автора = " + booksCount.Count);
                }
                else Console.WriteLine("Книг у этого автора нет");
                excersize.ExMenu();
            }
        }

        // Получить количество книг определенного жанра в библиотеке
        public void ThirdExcesize()
        {
            using (var db = new AppContext.AppContext())
            {
                Console.WriteLine("Введите Id жанра");
                var geners = db.Geners.ToList();
                foreach (var gener in geners)
                {
                    Console.WriteLine(gener.Id + "\t" + gener.Name);
                }

                int generId = int.Parse(Console.ReadLine());

                var takeGener = db.Books.Where(g => g.GenerId == generId).ToList();

                if (takeGener.Count != 0)
                {
                    Console.WriteLine("Количество книг этого жанра = " + takeGener.Count);
                }
                else Console.WriteLine("Книг этого жанра нет");
                excersize.ExMenu();
            }
        }

        // Получить булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке
        public void FourthExcersize()
        {
            using(var db = new AppContext.AppContext())
            {
                Console.WriteLine("Введите название книги");
                string BookName = Console.ReadLine();
                Console.WriteLine("Введите название автора");
                string AuthorName = Console.ReadLine();

                bool result = (from b in db.Books
                             join a in db.Authors on b.AuthorId equals a.Id into j1
                             where b.Name == BookName
                             from j2 in j1
                             where j2.Name == AuthorName
                             select j2).IsNullOrEmpty();

                Console.WriteLine(!result);
                excersize.ExMenu();

            }
        }

        // Получить булевый флаг о том, есть ли определенная книга на руках у пользователя
        public void FithExcersize()
        {
            using (var db = new AppContext.AppContext())
            {
                Console.WriteLine("Введите Id пользователя");
                int UserId = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите Id книги");
                int BookId = int.Parse(Console.ReadLine());

                var user = db.Users.Where(u => u.Id == UserId).Include(u => u.Books).FirstOrDefault();

                bool result = user.Books.Where(b => b.Id == BookId).IsNullOrEmpty();
                Console.WriteLine(!result);
                excersize.ExMenu();
            }
        }

        // Получить количество книг на руках у пользователя
        public void SixthExcersize()
        {
            using (var db = new AppContext.AppContext())
            {
                Console.WriteLine("Введите Id пользователя");
                int UserId = int.Parse(Console.ReadLine());

                var user = db.Users.Where(u => u.Id == UserId).Include(u => u.Books).FirstOrDefault();
                if (user != null)
                {
                    var userBooks = user.Books.ToList();
                    Console.WriteLine("Количество книг у пользователя = " + userBooks.Count);
                }
                else Console.WriteLine("ПОльзователя с таким Id нет");
                excersize.ExMenu();
            }
        }

        // Получить последнюю вышедшей книги
        public void SeventhExcersize()
        {
            using(var db = new AppContext.AppContext())
            {
                var result = (from b in db.Books
                             orderby b.CreatedDate
                             select b).Last();
                Console.WriteLine("Последняя вышедшая книга в " + result.CreatedDate + " году");
                excersize.ExMenu();
            }
        }

        // Получить список всех книг, отсортированный в алфавитном порядке по названию
        public void EigthExcersize()
        {
            using(var db = new AppContext.AppContext())
            {
                var result = (from b in db.Books
                              orderby b.Name
                              select b).ToList();
                Console.WriteLine("Отсортированные книги по названию");
                foreach (var r in result)
                {
                    Console.WriteLine(r.Name);
                }
                excersize.ExMenu();

            }
        }

        // Получить список всех книг, отсортированный в порядке убывания года их выхода

        public void NinthExcersize()
        {
            using(var db = new AppContext.AppContext())
            {
                var result = (from b in db.Books
                              orderby b.CreatedDate descending
                              select b).ToList();
                Console.WriteLine("Список всех книг, отсортированный в порядке убывания года их выхода");
                foreach(var r in result)
                {
                    Console.WriteLine(r.Name + "\t" + r.CreatedDate);
                }
                excersize.ExMenu();
            }
        }
    }
}
