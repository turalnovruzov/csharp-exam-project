using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace csharp_exam_project
{
    static class Database
    {
        private static string fileName = "Users.json";

        public static List<AbstractUser> Users { get; set; }

        static Database()
        {
            Read();
        }

        public static void Read()
        {
            if (File.Exists(fileName))
            {
                using (StreamReader file = new StreamReader(fileName))
                {
                    Users = JsonConvert.DeserializeObject<List<AbstractUser>>(file.ReadToEnd());
                }
            }
        }

        public static void Save()
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                file.Write(JsonConvert.SerializeObject(Users, Formatting.Indented));
            }
        }
    }
}
