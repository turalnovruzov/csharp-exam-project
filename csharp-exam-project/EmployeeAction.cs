using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_exam_project
{
    class EmployeeAction
    {
        private Employee user;

        public void Initialize(Employee user)
        {
            this.user = user;
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
                        View.Clear();
                        AddCV();
                        break;
                    case "2":
                        View.Clear();
                        break;
                    case "3":

                        break;
                    case "4":
                        View.Clear();
                        ShowCV();
                        break;
                    case "5":

                        break;
                    case "6":

                        break;
                    default:
                        View.WriteErrorAndClear("Invalid Option.");
                        break;
                }
            }
        }

        private void AddCV()
        {
            string input;
            bool @break;
            CVPost CV = new CVPost();

            #region Name
            while (true)
            {
                View.WriteLine("Name");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine();

                try
                {
                    CV.Name = input;
                    break;
                }
                catch (Exception ex)
                {
                    View.WriteErrorAndClear(ex.Message);
                }
            }
            #endregion
            View.Clear();
            #region Surname
            while (true)
            {
                View.WriteLine("Surname");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine();

                try
                {
                    CV.Surname = input;
                    break;
                }
                catch (Exception ex)
                {
                    View.WriteErrorAndClear(ex.Message);
                }
            }
            #endregion
            View.Clear();
            #region Gender
            while (true)
            {
                View.WriteLine("Are you a male(m) or a female(f)?");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine();

                if (input == "male" || input == "m")
                {
                    CV.Gender = Gender.Male;
                    break;
                }
                else if (input == "female" || input == "f")
                {
                    CV.Gender = Gender.Female;
                }
                else
                {
                    View.WriteErrorAndClear("Invalid Option");
                }
            }
            #endregion
            View.Clear();
            #region Age
            while (true)
            {
                View.WriteLine("Age");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine();

                try
                {
                    CV.Age = uint.Parse(input);
                    break;
                }
                catch (FormatException)
                {
                    View.WriteErrorAndClear("That is not a number.");
                }
                catch (OverflowException)
                {
                    View.WriteErrorAndClear("Your age is either too big or less than zero.");
                }
                catch (Exception ex)
                {
                    View.WriteErrorAndClear(ex.Message);
                }
            }
            #endregion
            View.Clear();
            #region Study Degree
            while (true)
            {
                @break = true;
                View.WriteLine("Choose your study degree.");
                View.WriteLine("1. Undergraduate");
                View.WriteLine("2. Graduate");
                View.WriteLine("3. Postgraduate");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CV.StudyDegree = StudyDegree.Undergraduate;
                        break;
                    case "2":
                        CV.StudyDegree = StudyDegree.Graduate;
                        break;
                    case "3":
                        CV.StudyDegree = StudyDegree.Postgraduate;
                        break;
                    default:
                        @break = false;
                        View.WriteErrorAndClear("Invalid option.");
                        break;
                }

                if (@break)
                {
                    break;
                }
            }
            #endregion
            View.Clear();
            #region Job Category
            while (true)
            {
                View.WriteLine("Choose one of the job categories");

                // Getting names of Job Categories and displaying them
                string[] names = Enum.GetNames(typeof(JobCategory));
                for (int i = 1; i <= names.Length; i++)
                {
                    View.WriteLine($"{i}. {names[i - 1]}");
                }

                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine();
                int n = 0;

                //checking if input is a number
                try
                {
                    int.TryParse(input, out n);
                    n--;
                    if (n < 0 || n >= names.Length)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    View.WriteErrorAndClear("Invalid option.");
                    continue;
                }

                // Declaring the job category
                CV.Category = (JobCategory)n;
                break;
            }
            #endregion
            View.Clear();
            #region City
            while (true)
            {
                View.WriteLine("City");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine();

                try
                {
                    CV.City = input;
                    break;
                }
                catch (Exception ex)
                {
                    View.WriteErrorAndClear(ex.Message);
                }
            }
            #endregion
            View.Clear();
            #region Minimum Salary
            while (true)
            {
                View.WriteLine("Minimum salary you want");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine();

                try
                {
                    CV.MinimumSalary = uint.Parse(input);
                    break;
                }
                catch (FormatException)
                {
                    View.WriteErrorAndClear("That is not a number.");
                }
                catch (OverflowException)
                {
                    View.WriteErrorAndClear("That is either too big or less than zero.");
                }
                catch (Exception ex)
                {
                    View.WriteErrorAndClear(ex.Message);
                }
            }
            #endregion
            View.Clear();
            #region Phone number
            while (true)
            {
                View.WriteLine("Your phone number (+994501234567)");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine().Trim();

                try
                {
                    CV.PhoneNumber = input;
                    break;
                }
                catch (Exception ex)
                {
                    View.WriteErrorAndClear(ex.Message);
                }
            }
            #endregion
            View.Clear();
            #region Summary
            while (true)
            {
                View.WriteLine(CV.ToString());
                View.WriteLine();
                View.WriteLine("Are you sure to add this CV to your accaunt? (y/n)");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine().Trim();

                if (input == "yes" || input == "y")
                {
                    break;
                }
                else if (input == "no" || input == "n")
                {
                    View.Clear();
                    return;
                }
                else
                {
                    View.WriteErrorAndClear("Invalid option.");
                }
            }
            #endregion
            View.Clear();

            user.CV = CV;
            Database.GetInstance().Save();
        }

        private void ShowCV()
        {
            View.WriteLineAndWait(user.CV.ToString());
            View.Clear();
        }

        private void RecommendedJobs()
        {
            
        }

        private void ShowJobs(List<JobPost> job)
        {
            
        }
    }
}
