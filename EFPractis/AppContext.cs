using EFPractis.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFPractis.Models;


namespace EFPractis {
    internal class AppContext : DbContext {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public AppContext () {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-KKSOPNQ\MSSQLDIPL;Database=DBEF;TrustServerCertificate=True;Trusted_Connection=True;");
        }
    }
}
