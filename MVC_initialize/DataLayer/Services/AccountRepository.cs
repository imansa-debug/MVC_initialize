using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;

namespace DataLayer.Services
{
    public class AccountRepository : IAccountRepository
    {
        private DbProvider db;

        public AccountRepository(DbProvider _context)
        {
            db = _context;
        }

        public void addUser(Users user)
        {
            db.Users.Add(user);
           
        }

        public Users getUserByActivationCode(string activationCode)
        {
            return db.Users.SingleOrDefault(u => u.ActiveCode == activationCode);
        }

        public Users getUserByEmail(string email)
        {
            return db.Users.SingleOrDefault(u => u.Email == email);
        }

        public Users getUserByEmailAndHashedPassword(string email, string hashedPassword)
        {
            return db.Users.SingleOrDefault(u => u.Email == email && u.Password==hashedPassword);
        }

        public Users getUserUserName(string username)
        {
            return db.Users.Single(u => u.UserName == username);
        }

        public bool isExistEmail(string email)
        {
            return db.Users.Any(u => u.Email == email.Trim().ToLower());
        }

        public bool isExitUserName(string userName)
        {
            return db.Users.Any(u => u.UserName == userName.Trim().ToLower());
        }
    }
}
