using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace csharp_exam_project
{
    class CVPost
    {
        private string name;
        private string surname;
        private string locationCity;
        private string phoneNumber;

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
        public uint Age { get; set; }
        public StudyDegree StudyDegree { get; set; }
        public WorkExperience WorkExperience { get; set; }
        public JobCategory Category { get; set; }
        public string LocationCity
        {
            get => locationCity;
            set
            {
                if (value.Length > 0 && value.All(char.IsLetter))
                {
                    locationCity = value;
                }
                else
                {
                    throw new Exception("Invalid city name.");
                }
            }
        }
        public uint MinimumSalary { get; set; }
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
            if (Category == job.Category && MinimumSalary <= job.Salary && LocationCity == job.LocationCity && WorkExperience == job.WorkExperience && Age == job.Age && StudyDegree == job.StudyDegree)
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
            str.AppendLine($"Study degree {nameof(StudyDegree)}");

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

            str.AppendLine($"Category: {nameof(Category)}");
            str.AppendLine($"City: {LocationCity}");
            str.AppendLine($"Minimum salary: {MinimumSalary}");
            str.AppendLine($"Phone number: {PhoneNumber}");

            return str.ToString();
        }
    }
}
