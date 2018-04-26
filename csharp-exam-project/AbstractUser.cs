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

        public Guid Id { get; private set; }
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
            Id = Guid.NewGuid();
        }

        public AbstractUser(string username, string email, string password, UserType type) : this()
        {
            Username = username;
            Email = email;
            Password = password;
            Type = type;
        }
    }
}
