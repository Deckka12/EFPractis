using EFPractis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace EFPractis.Repositories {
    public class BookRepository {
        private Book book;
        public BookRepository () {
            book = new Book();
        }
        public List<Book> FindAllUser () {
            List<Book> books;
            using(var db = new AppContext()) {
                books = db.Books.ToList();
            }
            return books;
        }
        public List<Book> FindUserById (int Id) {
            List<Book> books;
            using(var db = new AppContext()) {
                books = db.Books.Where(x => x.Id == Id).ToList();
            }
            return books;
        }
        public void AddBook (string name, int year) {
            using(var db = new AppContext()) {
                var books = new Book { Name = name, Year = year };
                db.Books.Add(books);
                db.SaveChanges();
            }
        }
        public void RemoveBook (int year) {
            using(var db = new AppContext()) {
                var books = db.Books.FirstOrDefault(x => x.Year == year);
                db.Remove(books);
                db.SaveChanges();
            }
        }
        public void UpdateBook (int ID, string name) {
            using(var db = new AppContext()) {
                var books =  db.Books.FirstOrDefault(x=>x.Id == ID);
                books.Name = name;
                db.SaveChanges();
                
            }
        }
    }
}
