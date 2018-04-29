using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_exam_project
{
    static class DBUserUtils
    {
        /// <summary>
        /// Checks for a user in database with the same username and password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>If finds returns the user, null otherwise</returns>
        public static AbstractUser LogInCheck(string username, string password)
        {
            Database db = Database.GetInstance();

            if (db.Users != null)
            {
                foreach (var user in db.Users)
                {
                    if (user.Username == username && user.Password == password)
                    {
                        return user;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Checks for a user in database with the same username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>If finds returns the user, null otherwise</returns>
        public static AbstractUser UsernameCheck(string username)
        {
            Database db = Database.GetInstance();

            if (db.Users != null)
            {
                foreach (var user in db.Users)
                {
                    if (user.Username == username)
                    {
                        return user;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Checks for a user in database with the same email address.
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns>If finds returns the user, null otherwise</returns>
        public static AbstractUser EmailAddressCheck(string emailAddress)
        {
            Database db = Database.GetInstance();

            if (db.Users != null)
            {
                foreach (var user in db.Users)
                {
                    if (user.EmailAddress == emailAddress)
                    {
                        return user;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Checks all the job posts with Employee.CompareToJob
        /// </summary>
        /// <param name="employee"></param>
        /// <return>Returns a list of recommended JobPosts</returns>
        public static List<JobPost> GetRecommendedJobs(Employee employee)
        {
            Database db = Database.GetInstance();
            List<JobPost> list = new List<JobPost>();

            foreach (var user in db.Employers)
            {
                foreach (var job in user.JobPosts)
                {
                    if (employee.CV.CompareToJob(job))
                    {
                        list.Add(job);
                    }
                }
            }

            return list;
        }

        public static List<JobPost> GetJobPosts()
        {
            List<JobPost> list = new List<JobPost>();
            Database db = Database.GetInstance();

            foreach (var user in db.Employers)
            {
                list.AddRange(user.JobPosts);
            }

            return list;
        }
    }
}
