using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFPractis.Models;

namespace EFPractis.Repositories {
    public class UserRepository {
        private User user;
        public UserRepository () {
            user = new User();
        }
        public List<User> FindAllUser () {
            List<User> users;
            using(var db = new AppContext()) {
                users = db.Users.ToList();
            }
            return users;
        }
        public List<User> FindUserById (int Id) {
            List<User> users;
            using(var db = new AppContext()) {
                users = db.Users.Where(x => x.Id == Id).ToList();
            }
            return users;
        }
        public void AddUser (string name, string email) {
            using(var db = new AppContext()) {
                var user1 = new User { Name = name,  Email = email };
                db.Users.Add(user1);
                db.SaveChanges();
            }
        }
        public void RemoveUser (string email) {
            using(var db = new AppContext()) {
                var users = db.Users.FirstOrDefault(x => x.Email == email);
                db.Remove(users);
                db.SaveChanges();
            }
        }
        public void UpdateUserName (int ID, string name) {
            using(var db = new AppContext()) {
                var users = db.Users.FirstOrDefault(x =>x.Id==ID);
                users.Name = name;
                db.SaveChanges();

            }
        }
    }
}
