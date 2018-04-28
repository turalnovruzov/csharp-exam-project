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
        private string emailAddress;
        private string password;
        
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
                    throw new Exception("Username must be at least 5 characters.");
                }
                else
                {
                    username = value;
                }
            }
        }
        public string EmailAddress
        {
            get => emailAddress;
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
                    emailAddress = value;
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
                    throw new Exception("Password must be at between 5 and 15 characters and contain at least one uppercase letter, one lowercase letter, one digit, one non-alphabetic symbol.");
                }
                else
                {
                    password = value;
                }
            }
        }
        public UserType Type { get; private set; }

        public AbstractUser()
        {
        }

        public AbstractUser(string username, string email, string password, UserType type)
        {
            Username = username;
            EmailAddress = email;
            Password = password;
            Type = type;
        }
    }
}
