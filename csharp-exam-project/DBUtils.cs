using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_exam_project
{
    static class DBUtils
    {
        public static AbstractUser LogInCheck(string username, string password)
        {
            Database db = Database.GetInstance();

            foreach (var user in db.Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return user;
                }
            }

            return null;
        }
    }
}
