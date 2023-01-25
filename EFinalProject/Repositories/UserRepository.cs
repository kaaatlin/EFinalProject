using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFinalProject.AppContext;
using EFinalProject.Models;
using Microsoft.EntityFrameworkCore;
using EFinalProject.Menus;

namespace EFinalProject.Repositories
{
    public class UserRepository
    {
        UserMainMenu mainMenu = new UserMainMenu();
        public void ShowUserById(int id)
        {
            using(var db = new AppContext.AppContext())
            {
                var user = db.Users.Where(x => x.Id == id).FirstOrDefault();
                if (user != null)
                {
                    Console.WriteLine(user.Id + "\t" + user.Name + "\t" + user.Email);
                }
                else Console.WriteLine("Пользователь с таким Id не найден!");
                mainMenu.UserMenu();
            }
        }

        public void ShowUsers()
        {
            using(var db = new AppContext.AppContext())
            {
                var users = db.Users.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine(user.Id + "\t" + user.Name + "\t" + user.Email);
                }
                mainMenu.UserMenu();
            }
        }

        public void AddNewUser(string UserName, string UserEmail)
        {
            using(var db = new AppContext.AppContext())
            {
                db.Users.Add(new User { Name = UserName, Email = UserEmail });
                db.SaveChanges();
                ShowUsers();
            }
        }

        public void DeleteUserById(int Id)
        {
            using(var db = new AppContext.AppContext())
            {
                var user = db.Users.Where(x => x.Id == Id).FirstOrDefault();
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                else Console.WriteLine("Пользователь не найден");
                ShowUsers();
            }
        }

        public void UpdateUserName(int Id, string UserName)
        {
            using(var db = new AppContext.AppContext())
            {
                var user = db.Users.Where(x => x.Id == Id).FirstOrDefault();
                user.Name = UserName;
                db.SaveChanges();
                ShowUsers();
            }
        }

        public void TakeBook(int UserId)
        {
            using(var db = new AppContext.AppContext())
            {
                Console.WriteLine("Список книг в библиотеке");
                var books = db.Books.ToList();
                foreach(var book in books)
                {
                    Console.WriteLine(book.Id + "\t" + book.Name);
                }

                Console.WriteLine("Введите Id книги, которую хотите взять:");
                int BookId = int.Parse(Console.ReadLine());

                var user = db.Users.Where(x => x.Id == UserId).FirstOrDefault();
                if (user != null)
                {
                    var bookToAdd = db.Books.Where(b => b.Id == BookId).FirstOrDefault();
                    if (bookToAdd != null)
                    {
                        user.Books.Add(bookToAdd);
                        db.SaveChanges();
                        Console.WriteLine("Книга отдана пользователю");
                    }
                    else Console.WriteLine("Книга с таким Id не найдена");
                }
                else Console.WriteLine("Пользователь с таким Id не найден");
                mainMenu.UserMenu();
            }
        }

        public void ShowUserBooks(int UserId)
        {
            using(var db = new AppContext.AppContext())
            {
                var userBooks = db.Users.Where(u => u.Id == UserId).Include(u => u.Books).ToList();
                if (userBooks != null)
                {
                    foreach (var user in userBooks)
                    {
                        foreach (var book in user.Books)
                        {
                            if (book != null)
                            Console.WriteLine(user.Name + "\t" + book.Name);
                            else Console.WriteLine("Книг у этого пользователя не найдено");
                        }
                    }
                }
                else Console.WriteLine("Книг у этого пользователя не найдено");
                mainMenu.UserMenu();

            }
        }

        public void DeleteBookFromUser(int UserId)
        {
            using(var db = new AppContext.AppContext())
            {
                var userBooks = db.Users.Where(u => u.Id == UserId).Include(u => u.Books).ToList();
                if (userBooks != null)
                {
                    foreach (var user in userBooks)
                    {
                        foreach (var book in user.Books)
                        {
                            Console.WriteLine(user.Name + "\t" + book.Id + "\t" + book.Name);
                        }
                    }
                }
                else Console.WriteLine("Книг у этого пользователя не найдено");

                Console.WriteLine("Введите Id книги");
                int BookId = int.Parse(Console.ReadLine());

                
                var userWithBook = db.Users.Where(u => u.Id == UserId).Include(u => u.Books).FirstOrDefault();
                var userBook = userWithBook.Books.FirstOrDefault(b => b.Id == BookId);
                if (userBook != null)
                {
                    Console.WriteLine("Удаляем эту книгу" + userBook.Name);
                    userWithBook.Books.Remove(userBook);
                    db.SaveChanges();
                }
                

                mainMenu.UserMenu();


            }
        }

    }
}
