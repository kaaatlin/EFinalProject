using EFinalProject.AppContext;
using EFinalProject.Models;
using EFinalProject.Menus;

namespace EFinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.MainMenu();
        }
    }
}
//using (var db = new AppContext.AppContext())
//{
//    var user1 = new User { Name = "Катя", Email = "k@mail.ru" };
//    var user2 = new User { Name = "Саша", Email = "s@gmail.com" };
//    var user3 = new User { Name = "Маша", Email = "m@outlook.com" };
//    var user4 = new User { Name = "Ваня", Email = "v@mail.ru" };

//    var author1 = new Author { Name = "Пушкин" };
//    var author2 = new Author { Name = "Лермонтов" };
//    db.Authors.AddRange(author1, author2);
//    db.SaveChanges();

//    var gener1 = new Gener { Name = "Повесть" };
//    var gener2 = new Gener { Name = "Роман" };
//    var gener3 = new Gener { Name = "Поэма" };
//    db.Geners.AddRange(gener1, gener2);
//    db.SaveChanges();

//    var book1 = new Book { Name = "Руслан и Людмила", CreatedDate = 1818 };
//    var book2 = new Book { Name = "Пиковая дама", CreatedDate = 1833 };
//    var book3 = new Book { Name = "Герой нашего времени", CreatedDate = 1840 };
//    var book4 = new Book { Name = "Мцыри", CreatedDate = 1840 };

//    book1.Author = author1;
//    book2.Author = author1;
//    book3.Author = author2;
//    book4.Author = author2;

//    book1.Gener = gener2;
//    book2.Gener = gener2;
//    book3.Gener = gener2;
//    book4.Gener = gener3;

//    book1.Users.AddRange(new[] {user1, user3, user4});
//    book2.Users.AddRange(new[] { user1, user3 });
//    book3.Users.AddRange(new[] {user1, user4});
//    book4.Users.AddRange(new[] {user3, user4});


//    db.Books.AddRange(book1, book2, book3, book4);
//    db.Users.AddRange(user1, user2, user3, user4);
//    db.SaveChanges();
//}