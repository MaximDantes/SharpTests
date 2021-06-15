using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTests
{
    public class Question
    {
        public int Id { get; set; }
        public Test Test { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public Dictionary<string, bool> Answers { get; set; }
    }
}
