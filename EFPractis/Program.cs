using EFPractis.Models;
using EFPractis.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EFPractis {

    internal class Program {
        static UserRepository repository;
        static void Main (string[] args) {
            //Получать список книг определенного жанра и вышедших между определенными годами.
            using(var db = new AppContext()) {
                var bookQuery = db.Books.Where(x => x.Year > 1969 && x.Year < 1971 && x.Author == "Толстой").ToList();
                foreach(var book in bookQuery) {
                    Console.WriteLine(book.Name);
                }
            }
            //Получать количество книг определенного автора в библиотеке.
            using(var db = new AppContext()) {
                var bookQuery = db.Books.Where(x => x.Author == "Лермонтов").ToList().Count();
            }
            //Получать количество книг определенного жанра в библиотеке.
            using(var db = new AppContext()) {
                var bookQuery = db.Books.Where(x => x.Genre == "Приключение").ToList().Count();
            }
            //Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
            using(var db = new AppContext()) {
                var bookQuery = db.Books.ToList();
                foreach(var book in bookQuery) {
                    if(book.Author.Contains("Лермонтов") && book.Name.Contains("Капитанская дочка")) {
                        Console.WriteLine($"В бибилиотеки есть книга с название {book.Name} и автором {book.Author}");
                    }
                }
            }
            //Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
            using(var db = new AppContext()) {
                var userQuery = db.Users.Where(x=>x.BookId==1);
                bool users;
                foreach(var item in userQuery) {
                    if(item.BookId!= null)
                        users = true;
                    else
                        users = false;
                }
            }
            //Получать количество книг на руках у пользователя.
            using(var db = new AppContext()) {
                var userBookCount = db.Users.Where(x => x.Name == "Bob"&& x.BookId!=null).Count();
                Console.WriteLine($"У пользователя на руках {userBookCount}");
            }
            //Получение последней вышедшей книги.
            using(var db = new AppContext()) {
                int max = 0;
                var LastBook = db.Books.ToList();
                foreach(var book in LastBook) {
                    if(book.Year > max) {
                        max = book.Year;
                    }
                }
                Console.WriteLine("Last book", max);
            }

            //Получение списка всех книг, отсортированного в алфавитном порядке по названию.
            using(var db = new AppContext()) {
                var booksOrderby = db.Books.OrderBy(x=>x.Name);
                foreach(var item in booksOrderby) {
                    Console.WriteLine(item.Name);
                }
            }

            //Получение списка всех книг, отсортированного в порядке убывания года их выхода.
            using(var db = new AppContext()) {
                var bookOrderByYear = db.Books.OrderByDescending(x=>x.Year);
                foreach(var item in bookOrderByYear) {
                    Console.WriteLine(item.Year);
                }
            }
        }
    }
}