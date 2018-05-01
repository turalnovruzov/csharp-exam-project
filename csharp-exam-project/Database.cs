using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace csharp_exam_project
{
    // This is a singleton class
    class Database
    {
        #region SingletonRegion
        private static Database instance = null;

        public static Database GetInstance()
        {
            if (instance == null)
            {
                instance = new Database();
            }
            return instance;
        }
        #endregion

        private string employeeFileName = "Employees.json";
        private string employerFileName = "Employers.json";

        public List<Employer> Employers { get; set; }
        public List<Employee> Employees { get; set; }
        public List<AbstractUser> Users
        {
            get
            {
                List<AbstractUser> list = Employees.ToList<AbstractUser>();
                list.AddRange(Employers.ToList<AbstractUser>());
                return list;
            }
        }

        private Database()
        {
            Employers = new List<Employer>();
            Employees = new List<Employee>();
            Read();
        }

        public void Read()
        {
            if (File.Exists(employeeFileName))
            {
                using (StreamReader file = new StreamReader(employeeFileName))
                {
                    Employees = JsonConvert.DeserializeObject<List<Employee>>(file.ReadToEnd());
                }
            }

            if (File.Exists(employerFileName))
            {
                using (StreamReader file = new StreamReader(employerFileName))
                {
                    Employers = JsonConvert.DeserializeObject<List<Employer>>(file.ReadToEnd());
                }
            }
        }

        public void Save()
        {
            using (StreamWriter file = new StreamWriter(employeeFileName))
            {
                file.Write(JsonConvert.SerializeObject(Employees, Formatting.Indented));
            }
            using (StreamWriter file = new StreamWriter(employerFileName))
            {
                file.Write(JsonConvert.SerializeObject(Employers, Formatting.Indented));
            }
        }
    }
}
