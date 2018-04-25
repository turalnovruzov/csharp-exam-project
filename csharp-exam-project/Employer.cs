namespace csharp_exam_project
{
    class Employer : AbstractUser
    {
        public Employer() { }

        public Employer(string username, string email, string password) : base(username, email, password, UserType.Employer) { }
    }
}
