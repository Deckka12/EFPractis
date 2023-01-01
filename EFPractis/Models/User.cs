using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EFPractis.Models {
    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int BookId { get; set; }
        // Навигационное свойство
        public Book Book { get; set; }
    }
}
