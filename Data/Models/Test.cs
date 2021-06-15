using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTests
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Level { get; set; }
        public bool IsCompleted { get; set; }
        public double Time { get; set; }
        public List<Question> Questions { get; set; }
    }
}
