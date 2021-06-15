using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTests
{
    static class Data
    {
        public static User CurrentUser { get; set; }
        public static List<Test> Tests { get; set; }
        public static List<Test> LevlelTests { get; set; }
        public static List<Question> Questions { get; set; }
        public static List<User> Users { get; set; }

        static Data()
        {
            Tests = new List<Test>();
            LevlelTests = new List<Test>();
            Questions = new List<Question>();
            Users = new List<User>();
        }
    }
}
