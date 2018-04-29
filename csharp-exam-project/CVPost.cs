using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace csharp_exam_project
{
    class CVPost
    {
        private string name;
        private string surname;
        private string city;
        private string phoneNumber;
        private uint age;
        private uint minimumSalary;

        public string Name
        {
            get => name;
            set
            {
                if (value.All(char.IsLetter) && value.Length > 0)
                {
                    name = value;
                }
                else
                {
                    throw new Exception("Invali name.");
                }
            }
        }
        public string Surname
        {
            get => surname;
            set
            {
                if (value.All(char.IsLetter) && value.Length > 0)
                {
                    surname = value;
                }
                else
                {
                    throw new Exception("Invali surname.");
                }
            }
        }
        public Gender Gender { get; set; }
        public uint Age
        {
            get => age;
            set
            {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    throw new Exception("Age must be more than 0.");
                }
            }
        }
        public StudyDegree StudyDegree { get; set; }
        public WorkExperience WorkExperience { get; set; }
        public JobCategory Category { get; set; }
        public string City
        {
            get => city;
            set
            {
                if (value.Length > 0 && value.All(char.IsLetter))
                {
                    city = value;
                }
                else
                {
                    throw new Exception("Invalid city name.");
                }
            }
        }
        public uint MinimumSalary
        {
            get => minimumSalary;
            set
            {
                if (value > 0)
                {
                    minimumSalary = value;
                }
                else
                {
                    throw new Exception("Minumum salary must be more than 0.");
                }
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (new Regex(@"^(\+994)(50|51|55|70|75)(\d{7})$").IsMatch(value))
                {
                    phoneNumber = value;
                }
                else
                {
                    throw new Exception("Invalid phone number.");
                }
            }
        }

        public bool CompareToJob(JobPost job)
        {
            if (Category == job.Category && MinimumSalary <= job.Salary && City == job.City && WorkExperience == job.WorkExperience && Age == job.Age && StudyDegree == job.StudyDegree)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Name: {Name}");
            str.AppendLine($"Surname: {Surname}");
            str.AppendLine($"Gender: {Gender}");
            str.AppendLine($"Age: {Age}");
            str.AppendLine($"Study degree: {Enum.GetName(typeof(StudyDegree), StudyDegree)}");

            str.Append("Work Experience: ");
            switch (WorkExperience)
            {
                case WorkExperience.LessThanOneYear:
                    str.AppendLine("Less than 1 year.");
                    break;
                case WorkExperience.OneToFourYears:
                    str.AppendLine("1 to 3 years");
                    break;
                case WorkExperience.FourToEightYears:
                    str.AppendLine("4 to 8 years");
                    break;
                case WorkExperience.MoreThanEightYears:
                    str.AppendLine("More than 8 years");
                    break;
                default:
                    break;
            }

            str.AppendLine($"Category: {Enum.GetName(typeof(JobCategory), Category)}");
            str.AppendLine($"City: {City}");
            str.AppendLine($"Minimum salary: {MinimumSalary}");
            str.AppendLine($"Phone number: {PhoneNumber}");

            return str.ToString();
        }
    }
}
