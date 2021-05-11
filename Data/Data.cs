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

        public static Question CurrentQuestion { get; set; }

        public static List<Test> Tests { get; set; }

        static Data()
        {
            Tests = new List<Test>();
        }
    }
}
