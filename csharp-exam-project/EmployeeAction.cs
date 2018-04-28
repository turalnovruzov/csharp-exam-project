using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_exam_project
{
    class EmployeeAction
    {
        public void Initialize()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            string input;

            while (true)
            {
                View.WriteLine("1. Add CV");
                View.WriteLine("2. See recommended job posts");
                View.WriteLine("3. Search job posts");
                View.WriteLine("4. Show CV");
                View.WriteLine("5. Show all job posts");
                View.WriteLine("6. Log out");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine().Trim();

                switch (input)
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                    case "5":

                        break;
                    case "6":

                        break;
                    default:
                        break;
                }
            }
        }

        
    }
}
