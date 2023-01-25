using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFinalProject.AppContext;
using EFinalProject.Menus;
using EFinalProject.Models;

namespace EFinalProject.Repositories
{
    public class BookRepository
    {
        BooksMainMenu menu = new BooksMainMenu();
        public void ShowBookById(int id)
        {
            using(var db = new AppContext.AppContext())
            {
                var book = db.Books.Where(b => b.Id == id).FirstOrDefault();
                if (book != null)
                {
                    Console.WriteLine("Id" + "\t" + "Name" + "\t" + "\t" + "\t" + "AuthorId" + "\t" + "\t" + "GenerId");
                    Console.WriteLine(book.Id + "\t" + book.Name + "\t" + book.CreatedDate + "\t" + book.AuthorId + "\t" + book.GenerId);
                }
                else Console.WriteLine("Книги с таким Id не найдено");
                menu.BooksMenu();
            }
        }

        public void ShowBooks()
        {
            using(var db = new AppContext.AppContext())
            {
                var books = db.Books.ToList();
                Console.WriteLine("Id" + "\t" + "Name" + "\t" + "AuthorId" + "\t" + "GenerId");
                foreach(var book in books)
                {
                    Console.WriteLine(book.Id + "\t" + book.Name + "\t" + book.CreatedDate + "\t" + book.AuthorId + "\t" + book.GenerId);
                }
                menu.BooksMenu();
            }
        }

        public void AddBook(string BookName, int Date)
        {
            using(var db = new AppContext.AppContext())
            {
                Console.WriteLine("Для удобства добавления просмотрите список авторов и жанров");

                var authors = db.Authors.ToList();
                Console.WriteLine("Список авторов:");
                foreach(var author in authors)
                {
                    Console.WriteLine(author.Id + "\t" + author.Name);
                }

                Console.WriteLine("Введите Id автора:");
                int AuthorId = int.Parse(Console.ReadLine());

                var geners = db.Geners.ToList();
                Console.WriteLine("Список жанров");
                foreach(var gener in geners)
                {
                    Console.WriteLine(gener.Id + "\t" + gener.Name);
                }

                Console.WriteLine("Введите Id жанра:");
                int GenerId = int.Parse(Console.ReadLine());

                db.Books.Add(new Book { Name = BookName, CreatedDate = Date, AuthorId = AuthorId, GenerId = GenerId });
                db.SaveChanges();
                ShowBooks();
            }
        }

        public void DeleteBookById(int id)
        {
            using(var db = new AppContext.AppContext())
            {
                var book = db.Books.Where(b => b.Id == id).FirstOrDefault();
                if (book != null)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
                else Console.WriteLine("Книга с таким Id не найдена");
                ShowBooks();
            }
        }

        public void UpdateBookCreatedDate(int id, int Date)
        {
            using(var db = new AppContext.AppContext())
            {
                var book = db.Books.Where(b => b.Id == id).FirstOrDefault();
                if (book != null)
                {
                    book.CreatedDate = Date;
                    db.SaveChanges();
                }
                else Console.WriteLine("Книга с таким Id не найдена");
                ShowBooks();
            }
        }

        public void AddAuthor(string name)
        {
            using (var db = new AppContext.AppContext())
            {
                db.Authors.Add(new Author { Name = name });
                db.SaveChanges();
                var authors = db.Authors.ToList();
                foreach (var author in authors)
                {
                    Console.WriteLine(author.Id + "\t" + author.Name);
                }
                menu.BooksMenu();
            }
        }
        public void AddGener(string name)
        {
            using (var db = new AppContext.AppContext())
            {
                db.Geners.Add(new Gener { Name = name });
                db.SaveChanges();
                var generes = db.Geners.ToList();
                foreach (var gene in generes)
                {
                    Console.WriteLine(gene.Id + "\t" + gene.Name);
                }
                menu.BooksMenu();
            }
        }
    }
}
