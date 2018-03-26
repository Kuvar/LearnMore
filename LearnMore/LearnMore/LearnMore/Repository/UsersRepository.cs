using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;

namespace LearnMore.Repository
{
    public class UsersRepository
    {
        JustBlogEntities objDB = new JustBlogEntities();

        public User Logon(string email, string password)
        {
            return objDB.Users
                .FirstOrDefault(c => c.Email == email && c.Password == password);
        }
    }
}
