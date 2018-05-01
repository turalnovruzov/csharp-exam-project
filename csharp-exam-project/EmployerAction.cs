using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTableExt;

namespace csharp_exam_project
{
    class EmployerAction
    {
        private Employer user;

        public void Initialize(Employer user)
        {
            this.user = user;
            MainMenu();
        }

        private void MainMenu()
        {
            string input;

            while (true)
            {
                View.WriteLine("1. Add job post");
                View.WriteLine("2. See appliers to your job posts");
                View.WriteLine("3. Log out");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine().Trim();

                switch (input)
                {
                    case "1":
                        View.Clear();
                        AddJobPost();
                        break;
                    case "2":
                        View.Clear();
                        Appliers();
                        break;
                    case "3":
                        View.Clear();
                        return;
                    default:
                        View.WriteErrorAndClear("Invalid Option.");
                        break;
                }
            }
        }

        private void AddJobPost()
        {
            string input;
            bool @break;
            JobPost job = new JobPost();

            #region Heading
            while (true)
            {
                View.WriteLine("Heading");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine();

                try
                {
                    job.Heading = input;
                    break;
                }
                catch (Exception ex)
                {
                    View.WriteErrorAndClear(ex.Message);
                }
            }
            #endregion
            View.Clear();
            #region Company Name
            while (true)
            {
                View.WriteLine("Company Name");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine();

                try
                {
                    job.CompanyName = input;
                    break;
                }
                catch (Exception ex)
                {
                    View.WriteErrorAndClear(ex.Message);
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
                job.Category = (JobCategory)n;
                break;
            }
            #endregion
            View.Clear();
            #region Description
            while (true)
            {
                View.WriteLine("Description");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine();

                try
                {
                    job.Description = input;
                    break;
                }
                catch (Exception ex)
                {
                    View.WriteErrorAndClear(ex.Message);
                }
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
                    job.City = input;
                    break;
                }
                catch (Exception ex)
                {
                    View.WriteErrorAndClear(ex.Message);
                }
            }
            #endregion
            View.Clear();
            #region Salary
            while (true)
            {
                View.WriteLine("Salary");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine();

                try
                {
                    job.Salary = uint.Parse(input);
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
            #region Age
            while (true)
            {
                View.WriteLine("Age");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine();

                try
                {
                    job.Age = uint.Parse(input);
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
                        job.StudyDegree = StudyDegree.Undergraduate;
                        break;
                    case "2":
                        job.StudyDegree = StudyDegree.Graduate;
                        break;
                    case "3":
                        job.StudyDegree = StudyDegree.Postgraduate;
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
            #region Phone number
            while (true)
            {
                View.WriteLine("Your phone number (+994501234567)");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine().Trim();

                try
                {
                    job.PhoneNumber = input;
                    break;
                }
                catch (Exception ex)
                {
                    View.WriteErrorAndClear(ex.Message);
                }
            }
            #endregion
            View.Clear();
            #region Work Experience
            while (true)
            {
                @break = true;
                View.WriteLine("Work experience");
                View.WriteLine();
                View.WriteLine("1. Less than 1 year");
                View.WriteLine("2. 1 to 3 years");
                View.WriteLine("3. 4 to 8 years");
                View.WriteLine("4. More than 8 years");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine().Trim();

                switch (input)
                {
                    case "1":
                        job.WorkExperience = WorkExperience.LessThanOneYear;
                        break;
                    case "2":
                        job.WorkExperience = WorkExperience.OneToFourYears;
                        break;
                    case "3":
                        job.WorkExperience = WorkExperience.FourToEightYears;
                        break;
                    case "4":
                        job.WorkExperience = WorkExperience.MoreThanEightYears;
                        break;
                    default:
                        @break = false;
                        View.WriteError("Invalid option.");
                        break;
                }

                if (@break)
                {
                    break;
                }
            }
            #endregion
            View.Clear();
            #region Summary
            while (true)
            {
                View.WriteLine(job.ToString());
                View.WriteLine();
                View.WriteLine("Are you sure to add this job post to your accaunt? (y/n)");
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

            user.JobPosts.Add(job);
            Database.GetInstance().Save();
        }

        private void Appliers()
        {
            string input;
            DataTable data = new DataTable();
            List<CVPost> cvs = new List<CVPost>();

            data.Columns.Add("N");
            data.Columns.Add("Name");
            data.Columns.Add("Surname");

            while (true)
            {
                cvs.Clear();
                data.Rows.Clear();

                int i = 0;
                foreach (var job in user.JobPosts)
                {
                    foreach (var cv in job.Appliers)
                    {
                        i++;
                        data.Rows.Add(i, cv.Name, cv.Surname);
                        cvs.Add(cv);
                    }
                }

                ConsoleTableBuilder.From(data).WithFormat(ConsoleTableBuilderFormat.MarkDown).ExportAndWriteLine();

                View.WriteLine();
                View.WriteLine("Choose a CV by the N to see details or write e to exit.");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine().Trim();
                int n = 0;

                if (input == "e")
                {
                    View.Clear();
                    return;
                }

                //checking if input is a number
                try
                {
                    int.TryParse(input, out n);
                    n--;
                    if (n < 0 || n >= cvs.Count)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    View.WriteErrorAndClear("Invalid option.");
                    continue;
                }

                View.Clear();
                View.WriteLineAndWait(cvs[n].ToString());
                View.Clear();
            }
        }
    }
}
