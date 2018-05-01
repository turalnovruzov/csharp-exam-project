using System;
using System.Collections.Generic;
using System.Data;
using ConsoleTableExt;
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
                        RecommendedJobs();
                        break;
                    case "3":
                        View.Clear();
                        Search();
                        break;
                    case "4":
                        View.Clear();
                        ShowCV();
                        break;
                    case "5":
                        View.Clear();
                        AllJobs();
                        break;
                    case "6":
                        View.Clear();
                        return;
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
                        CV.WorkExperience = WorkExperience.LessThanOneYear;
                        break;
                    case "2":
                        CV.WorkExperience = WorkExperience.OneToFourYears;
                        break;
                    case "3":
                        CV.WorkExperience = WorkExperience.FourToEightYears;
                        break;
                    case "4":
                        CV.WorkExperience = WorkExperience.MoreThanEightYears;
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

        private void Search()
        {
            List<JobPost> jobs = new List<JobPost>();
            string input;
            bool @break;
            while (true)
            {
                jobs.Clear();
                View.WriteLine("1. Heading");
                View.WriteLine("2. Company name");
                View.WriteLine("3. Category");
                View.WriteLine("4. City");
                View.WriteLine("5. Salary");
                View.WriteLine("6. Age");
                View.WriteLine("7. Study degree");
                View.WriteLine("8. Work experience");
                View.WriteLine("Write e to exit");
                View.WriteLine();
                View.Write("> ");

                input = Console.ReadLine().Trim();

                switch (input)
                {
                    case "1":
                        View.Clear();
                        View.WriteLine("Heading");
                        View.WriteLine();
                        View.Write("> ");

                        input = Console.ReadLine();

                        foreach (var job in DBUserUtils.GetJobPosts())
                        {
                            if (job.Heading == input)
                            {
                                jobs.Add(job);
                            }
                        }

                        View.Clear();
                        ShowJobs(jobs);
                        break;
                    case "2":
                        View.Clear();
                        View.WriteLine("Company name");
                        View.WriteLine();
                        View.Write("> ");

                        input = Console.ReadLine();

                        foreach (var job in DBUserUtils.GetJobPosts())
                        {
                            if (job.CompanyName == input)
                            {
                                jobs.Add(job);
                            }
                        }

                        View.Clear();
                        ShowJobs(jobs);
                        break;
                    case "3":
                        View.Clear();
                        JobCategory category;

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
                                category = (JobCategory)n;
                                break;
                            }
                            catch (Exception)
                            {
                                View.WriteErrorAndClear("Invalid option.");
                            } 
                        }

                        foreach (var job in DBUserUtils.GetJobPosts())
                        {
                            if (job.Category == category)
                            {
                                jobs.Add(job);
                            }
                        }

                        View.Clear();
                        ShowJobs(jobs);
                        break;
                    case "4":
                        View.Clear();
                        View.WriteLine("City");
                        View.WriteLine();
                        View.Write("> ");

                        input = Console.ReadLine();

                        foreach (var job in DBUserUtils.GetJobPosts())
                        {
                            if (job.City == input)
                            {
                                jobs.Add(job);
                            }
                        }

                        View.Clear();
                        ShowJobs(jobs);
                        break;
                    case "5":
                        uint salary;

                        while (true)
                        {
                            View.WriteLine("Salary");
                            View.WriteLine();
                            View.Write("> ");

                            input = Console.ReadLine();

                            try
                            {
                                salary = uint.Parse(input);
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

                        foreach (var job in DBUserUtils.GetJobPosts())
                        {
                            if (job.Salary == salary)
                            {
                                jobs.Add(job);
                            }
                        }

                        View.Clear();
                        ShowJobs(jobs);
                        break;
                    case "6":
                        uint age;

                        while (true)
                        {
                            View.WriteLine("Age");
                            View.WriteLine();
                            View.Write("> ");

                            input = Console.ReadLine();

                            try
                            {
                                age = uint.Parse(input);
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

                        foreach (var job in DBUserUtils.GetJobPosts())
                        {
                            if (job.Age == age)
                            {
                                jobs.Add(job);
                            }
                        }

                        View.Clear();
                        ShowJobs(jobs);
                        break;
                    case "7":
                        StudyDegree? studyDegree = StudyDegree.Graduate; //random declaration

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
                                    studyDegree = StudyDegree.Undergraduate;
                                    break;
                                case "2":
                                    studyDegree = StudyDegree.Graduate;
                                    break;
                                case "3":
                                    studyDegree = StudyDegree.Postgraduate;
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

                        foreach (var job in DBUserUtils.GetJobPosts())
                        {
                            if (job.StudyDegree == studyDegree)
                            {
                                jobs.Add(job);
                            }
                        }

                        View.Clear();
                        ShowJobs(jobs);
                        break;
                    case "8":
                        WorkExperience workExperience = WorkExperience.FourToEightYears; //random declaration

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
                                    workExperience = WorkExperience.LessThanOneYear;
                                    break;
                                case "2":
                                    workExperience = WorkExperience.OneToFourYears;
                                    break;
                                case "3":
                                    workExperience = WorkExperience.FourToEightYears;
                                    break;
                                case "4":
                                    workExperience = WorkExperience.MoreThanEightYears;
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

                        foreach (var job in DBUserUtils.GetJobPosts())
                        {
                            if (job.WorkExperience == workExperience)
                            {
                                jobs.Add(job);
                            }
                        }

                        View.Clear();
                        ShowJobs(jobs);
                        break;
                    case "e":
                        View.Clear();
                        return;
                    default:
                        View.WriteErrorAndClear("Invalid option");
                        break;
                }
            }
        }

        private void RecommendedJobs()
        {
            ShowJobs(DBUserUtils.GetRecommendedJobs(user.CV));
        }

        private void AllJobs()
        {
            ShowJobs(DBUserUtils.GetJobPosts());
        }

        private void ShowJobs(List<JobPost> jobs)
        {
            if (jobs == null || jobs.Count == 0)
            {
                View.WriteLineAndWait("No jobs");
                View.Clear();
                return;
            }
            string input;
            DataTable data = new DataTable();

            data.Columns.Add("N");
            data.Columns.Add("Heading");

            while (true)
            {
                data.Rows.Clear();

                for (int i = 1; i <= jobs.Count; i++)
                {
                    data.Rows.Add(i, jobs[i - 1].Heading);
                }

                ConsoleTableBuilder.From(data).WithFormat(ConsoleTableBuilderFormat.MarkDown).ExportAndWriteLine();

                View.WriteLine();
                View.WriteLine("Choose a job by the N to see details or write e to exit.");
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
                    if (n < 0 || n >= jobs.Count)
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

                while (true)
                {
                    View.WriteLine(jobs[n].ToString());
                    View.WriteLine();
                    View.WriteLine("Apply? (y/n)");
                    View.WriteLine();
                    View.Write("> ");

                    input = Console.ReadLine().Trim();

                    if (input == "yes" || input == "y")
                    {
                        View.Clear();
                        bool b = true;
                        foreach (var cv in jobs[n].Appliers)
                        {
                            if (cv.Equals(user.CV))
                            {
                                b = false;
                            }
                        }
                        if (b)
                        {
                            jobs[n].Appliers.Add(user.CV);
                            Database.GetInstance().Save();
                        }
                        break;
                    }
                    else if (input == "no" || input == "n")
                    {
                        View.Clear();
                        break;
                    }
                    else
                    {
                        View.WriteErrorAndClear("Invalid option.");
                    }
                }
            }
        }
    }
}
