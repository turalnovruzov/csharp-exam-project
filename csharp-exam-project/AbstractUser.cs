using System;
using System.Text.RegularExpressions;

namespace csharp_exam_project
{
    /// <summary>
    /// Absract class for Employer and Employee classes
    /// </summary>
    abstract class AbstractUser
    {
        private string username;
        private string email;
        private string password;
        private UserType type;

        public string Username
        {
            get => username;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else if (value.Length < 5)
                {
                    throw new Exception("Username must be at least 5 symbols.");
                }
                else
                {
                    username = value;
                }
            }
        }
        public string Email
        {
            get => email;
            set
            {
                Regex regex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else if (!regex.IsMatch(value))
                {
                    throw new Exception("Invald email address.");
                }
                else
                {
                    email = value;
                }
            }
        }
        public string Password
        {
            get => password;
            set
            {
                Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*(_|[^\w])).{5,15}$");
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else if (!regex.IsMatch(value))
                {
                    throw new Exception("Password must contain at least one uppercase letter, one lowercase letter, one digit, one symbol, and length must be between 5 and 15.");
                }
                else
                {
                    password = value;
                }
            }
        }
        public UserType Type { get => type; set => type = value; }
    }
}
