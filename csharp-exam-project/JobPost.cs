using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace csharp_exam_project
{
    class JobPost
    {
        private string phoneNumber;
        private string heading;
        private string companyName;
        private string locationCity;

        public string Heading
        {
            get => heading;
            set
            {
                if (value.Length > 0)
                {
                    heading = value;
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
        public uint Salary { get; set; }
        public uint Age { get; set; }
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

    }
}
