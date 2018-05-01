using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace csharp_exam_project
{
    class JobPost
    {
        private string phoneNumber;
        private string header;
        private string companyName;
        private string city;
        private uint salary;
        private uint age;

        public string Heading
        {
            get => header;
            set
            {
                if (value.Length > 0)
                {
                    header = value;
                }
                else
                {
                    throw new Exception("Invalid heading.");
                }
            }
        }
        public string CompanyName
        {
            get => companyName;
            set
            {
                if (value.Length > 0)
                {
                    companyName = value;
                }
                else
                {
                    throw new Exception("Invalid company name.");
                }
            }
        }
        public JobCategory Category { get; set; }
        public string Description { get; set; }
        public string City
        {
            get => city;
            set
            {
                if (value.Length > 0)
                {
                    city = value;
                }
                else
                {
                    throw new Exception("Invalid city name.");
                }
            }
        }
        public uint Salary
        {
            get => salary;
            set
            {
                if (value > 0)
                {
                    salary = value;
                }
                else
                {
                    throw new Exception("Salary must be more than 0.");
                }
            }
        }
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

        public List<CVPost> Appliers { get; set; }

        public JobPost()
        {
            Appliers = new List<CVPost>();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Heading: {Heading}");
            str.AppendLine($"Company name: {CompanyName}");
            str.AppendLine($"Category: {Enum.GetName(typeof(JobCategory), Category)}");
            str.AppendLine($"Description: {Description}");
            str.AppendLine($"City: {City}");
            str.AppendLine($"Salary: {Salary}");
            str.AppendLine($"Age: {Age}");
            str.AppendLine($"Study degree: {StudyDegree}");

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
                    str.AppendLine();
                    break;
            }

            str.Append($"Phone number: {PhoneNumber}");

            return str.ToString();
        }
    }
}
