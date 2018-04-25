using System;

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
                ColorConsole.WriteLine("1. Sign in");
                ColorConsole.WriteLine("2. Sign up");
                ColorConsole.WriteLine("3. Exit");
                ColorConsole.WriteLine();
                ColorConsole.Write("> ");

                input = Console.ReadLine().Trim();

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
                        ColorConsole.WriteError("Invalid option.");
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
                ColorConsole.Write("Username: ");
                username = Console.ReadLine();

                ColorConsole.Write("Password: ");
                password = Console.ReadLine();


            }
        }

        private void SignUp()
        {

        }
    }
}
