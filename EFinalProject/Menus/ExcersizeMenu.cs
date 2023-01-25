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
    public class ExcersizeMenu
    {
        public void ExMenu()
        {
            Console.WriteLine("1. Получить список книг определенного жанра и вышедших между определенными годами\n" +
                              "2. Получить количество книг определенного автора в библиотеке\n" +
                              "3. Получить количество книг определенного жанра в библиотеке\n" +
                              "4. Получить булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке\n" +
                              "5. Получить булевый флаг о том, есть ли определенная книга на руках у пользователя\n" +
                              "6. Получить количество книг на руках у пользователя\n" +
                              "7. Получить последнюю вышедшую книги\n" +
                              "8. Получить список всех книг, отсортированный в алфавитном порядке по названию\n" +
                              "9. Получить список всех книг, отсортированный в порядке убывания года их выхода\n" +
                              "10. Вернуться в главное меню\n");
            int Choise = int.Parse(Console.ReadLine());

            Menu menu = new Menu();
            ExcersizesRepository excersizes = new ExcersizesRepository();

            switch (Choise)
            {
                case 1:
                    {
                        excersizes.FirstExcesrsize();
                        break;
                    }
                case 2:
                    {
                        excersizes.SecondExcersize();
                        break;
                    }
                case 3:
                    {
                        excersizes.ThirdExcesize();
                        break;
                    }
                case 4:
                    {
                        excersizes.FourthExcersize();
                        break;

                    }
                case 5:
                    {
                        excersizes.FithExcersize();
                        break;
                    }
                case 6:
                    {
                        excersizes.SixthExcersize();
                        break;
                    }
                case 7:
                    {
                        excersizes.SeventhExcersize();
                        break;
                    }
                case 8:
                    {
                        excersizes.EigthExcersize();
                        break;
                    }
                case 9:
                    {
                        excersizes.NinthExcersize();
                        break;
                    }
                case 10:
                    {
                        menu.MainMenu();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Такого пункта меню нет");
                        ExMenu();
                        break;
                    }
            }
        }
    }
}
