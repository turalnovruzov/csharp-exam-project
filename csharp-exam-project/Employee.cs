namespace csharp_exam_project
{
    class Employee : AbstractUser
    {
        public Employee() { }

        public Employee(string username, string email, string password) : base(username, email, password, UserType.Employee) { }
    }
}
