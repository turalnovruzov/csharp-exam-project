using System.Text;

namespace csharp_exam_project
{
    class Employee : AbstractUser
    {
        public CVPost CV { get; set; }

        public Employee() { }

        public Employee(string username, string emailAddress, string password) : base(username, emailAddress, password, UserType.Employee) { }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Username:\t{Username}");
            str.AppendLine($"Email address:\t{EmailAddress}");
            str.AppendLine("Employee");

            return str.ToString();
        }
    }
}
