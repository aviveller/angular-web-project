using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestPro.Models
{
    public class AuthService
    {
        public static Users GetLoginUser(string username, string password)
        {
            using (var db = new testdbEntities())
            {
                var user = db.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
                return user;

            }
        }
    }
}