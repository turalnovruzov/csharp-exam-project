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
                        SignUp();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        View.WriteErrorAndClear("Invalid option.");
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

                AbstractUser user = DBUserUtils.LogInCheck(username, password);

                if (user == null)
                {
                    View.WriteErrorAndClear("Username or password incorrect.");
                    break;
                }
                else if (user.Type == UserType.Employee)
                {
                    View.Clear();
                    new EmployeeAction().Initialize(user as Employee);
                }
                else
                {

                }
            }
        }

        private void SignUp()
        {
            string input;
            bool @break = true;
            AbstractUser user = null;

            #region Status

            while (true)
            {
                View.WriteLine("Do you want to hire people or get a job? (hire/get)");
                @break = true;
                
                View.WriteLine();
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
                    View.WriteErrorAndClear("Oh I don't have any other options, sorry. Choose hire or get.");
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
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine().Trim();

                try
                {
                    user.Username = input;

                    if (DBUserUtils.UsernameCheck(input) != null)
                    {
                        throw new Exception("This username is already taken.");
                    }
                    break;
                }
                catch (Exception ex)
                {
                    View.WriteErrorAndClear(ex.Message);
                }
            }
            #endregion
            View.Clear();
            #region Email

            while (true)
            {
                View.WriteLine("Enter a valid email address (it's better to enter your own email address)");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine().Trim();

                try
                {
                    user.EmailAddress = input;

                    if (DBUserUtils.EmailAddressCheck(input) != null)
                    {
                        throw new Exception("This email address is already taken.");
                    }
                    break;
                }
                catch (Exception ex)
                {
                    View.WriteErrorAndClear(ex.Message);
                }
            }
            #endregion
            View.Clear();
            #region Password

            while (true)
            {
                View.WriteLine("Enter a password that is between 5 and 15 characters and contains at least one uppercase letter, one lowercase letter, one digit, one non-alphabetic symbol");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine().Trim();

                try
                {
                    user.Password = input;
                }
                catch (Exception ex)
                {
                    View.WriteErrorAndClear(ex.Message);
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
                    View.WriteErrorAndClear("That does not match your password.");
                }
            }
            #endregion
            View.Clear();
            #region PIN verification
            while (true)
            {
                string pin = PinGenerator.NewPin();

                View.WriteLine("Rewrite the symbols.");
                View.WriteLine(pin);
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine().Trim();

                if (input == pin)
                {
                    break;
                }
                else
                {
                    View.WriteErrorAndClear("Not correct. Try again.");
                }
            }
            #endregion
            View.Clear();
            #region Summary
            while (true)
            {
                View.WriteLine(user.ToString());
                View.WriteLine("Sign up? (y/n)");
                View.WriteLine();
                View.Write("> ");

                @break = true;
                input = Console.ReadLine().Trim().ToLower();

                switch (input)
                {
                    case "y":
                    case "yes":
                        View.WriteSuccess("You have been successfully registered");
                        break;
                    case "n":
                    case "no":
                        View.WriteLineAndWait("You have not been registered.");
                        View.Clear();
                        return;
                    default:
                        View.WriteErrorAndClear("You need to choose either yes(y) or no(n).");
                        @break = false;
                        break;
                }

                if (@break)
                {
                    break;
                }
            }
            #endregion
            View.Clear();

            Database db = Database.GetInstance();

            if (user.Type == UserType.Employee)
            {
                db.Employees.Add(user as Employee);
                db.Save();
            }
            else
            {
                db.Employers.Add(user as Employer);
                db.Save();
            }
        }
    }
}
