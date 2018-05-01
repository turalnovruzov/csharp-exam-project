using System.Collections.Generic;
using System.Text;

namespace csharp_exam_project
{
    class Employer : AbstractUser
    {
        public List<JobPost> JobPosts { get; set; }

        public Employer() : base(UserType.Employer)
        {
            JobPosts = new List<JobPost>();
        }

        public Employer(string username, string emailAddress, string password) : base(username, emailAddress, password, UserType.Employer)
        {
            JobPosts = new List<JobPost>();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Username:\t{Username}");
            str.AppendLine($"Email address:\t{EmailAddress}");
            str.AppendLine("Employer");

            return str.ToString();
        }
    }
}
