using System.IO;
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

        private string fileName = "Users.json";

        public List<AbstractUser> Users { get; set; }

        private Database()
        {
            Users = new List<AbstractUser>();
            Read();
        }

        public void Read()
        {
            if (File.Exists(fileName))
            {
                using (StreamReader file = new StreamReader(fileName))
                {
                    Users = JsonConvert.DeserializeObject<List<AbstractUser>>(file.ReadToEnd());
                }
            }
        }

        public void Save()
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                file.Write(JsonConvert.SerializeObject(Users, Formatting.Indented));
            }
        }
    }
}
