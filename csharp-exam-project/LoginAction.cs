using System;
using System.Collections.Generic;

namespace csharp_exam_project
{
    class LoginAction
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

                if (input == "1" || input == "2" || input == "3")
                {
                    View.Clear();
                }

                switch (input)
                {
                    case "1":
                        SignIn();
                        break;
                    case "2":
                        SignUp();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        View.WriteError("Invalid option.", 2);
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

        private void SignUp()
        {
            List<int> list = new List<int>();

            string input;
            AbstractUser user;

            View.WriteLine("Do you want to hire people or get a job? (hire/get)");
            View.Write("> ");

            while (true)
            {
                input = Console.ReadLine().Trim();

                if (input == "hire" || input == "h")
                {

                }
            }
        }
    }
}
