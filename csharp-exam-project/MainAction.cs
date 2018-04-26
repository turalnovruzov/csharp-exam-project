using System;
using System.Collections.Generic;

namespace csharp_exam_project
{
    class MainAction
    {
        public void Initialize()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            string input;
            bool exit = false;

            while (true)
            {
                View.WriteLine("1. Sign in");
                View.WriteLine("2. Sign up");
                View.WriteLine("3. Exit");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine().Trim();

                switch (input)
                {
                    case "1":
                        View.Clear();
                        SignIn();
                        break;
                    case "2":
                        View.Clear();
                        SignUpAsEmployer();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        View.WriteError("Invalid option.");
                        break;
                }

                if (exit)
                {
                    break;
                }
            }
        }

        private void SignIn()
        {
            string username, password;

            while (true)
            {
                View.Write("Username: ");
                username = Console.ReadLine();

                View.Write("Password: ");
                password = Console.ReadLine();

                AbstractUser user = DBUtils.LogInCheck(username, password);

                if (user == null)
                {
                    View.WriteError("Username or password incorrect.");
                    break;
                }
                else if (user.Type == UserType.Employee)
                {

                }
                else
                {

                }
            }
        }

        private void SignUpAsEmployer()
        {
            List<int> list = new List<int>();

            string input;
            bool @break = true;
            AbstractUser user = null;

            #region Status

            while (true)
            {
                View.WriteLine("Do you want to hire people or get a job? (hire/get)");
                @break = true;

                View.Write("> ");

                input = Console.ReadLine().Trim();

                if (input == "hire" || input == "h")
                {
                    user = new Employer();
                }
                else if (input == "get" || input == "g")
                {
                    user = new Employee();
                }
                else
                {
                    @break = false;
                    View.WriteError("Oh I don't have any other options, sorry. Choose hire or get.");
                }

                if (@break)
                {
                    break;
                }
            }
            #endregion
            View.Clear();
            #region Username

            while (true)
            {
                View.WriteLine("Enter a username that is at least 5 characters");
                View.Write("> ");

                input = Console.ReadLine().Trim();

                try
                {
                    user.Username = input;
                    break;
                }
                catch (Exception ex)
                {
                    View.WriteError(ex.Message);
                }
            }
            #endregion
            View.Clear();
            #region Email

            while (true)
            {
                View.WriteLine("Enter a valid email address (it's better to enter your own email address)");
                View.Write("> ");

                input = Console.ReadLine().Trim();

                try
                {
                    user.Email = input;
                    break;
                }
                catch (Exception ex)
                {
                    View.WriteError(ex.Message);
                }
            }
            #endregion
            View.Clear();
            #region Password

            while (true)
            {
                View.WriteLine("Enter a password that is between 5 and 15 characters and contains at least one uppercase letter, one lowercase letter, one digit, one non-alphabetic symbol");
                View.Write("> ");

                input = Console.ReadLine().Trim();

                try
                {
                    user.Password = input;
                }
                catch (Exception ex)
                {
                    View.WriteError(ex.Message);
                    continue;
                }

                View.WriteLine();

                View.WriteLine("Repeat your password");
                View.Write("> ");

                input = Console.ReadLine().Trim();

                if (input == user.Password)
                {
                    break;
                }
                else
                {
                    View.WriteError("That does not match your password.");
                }
            }
            #endregion
            View.Clear();
        }
    }
}
