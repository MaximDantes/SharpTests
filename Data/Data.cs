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
        public static List<Question> Questions { get; set; }

        static Data()
        {
            Tests = new List<Test>();
            Questions = new List<Question>();

            Questions.Add(new Question()
            {
                Text = "question 1",
                Answers = new Dictionary<string, bool>()
            });
            Questions[0].Answers.Add("correct1", true);
            Questions[0].Answers.Add("incorrect1_1", false);
            Questions[0].Answers.Add("incorrect1.2", false);

            Questions.Add(new Question()
            {
                Text = "question 2",
                Answers = new Dictionary<string, bool>()
            });
            Questions[1].Answers.Add("correct2", true);
            Questions[1].Answers.Add("incorrect2.1", false);

            Questions.Add(new Question()
            {
                Text = "question 3",
                Answers = new Dictionary<string, bool>()
            });
            Questions[2].Answers.Add("incorrect3.3", false);
            Questions[2].Answers.Add("correct3.1", true);
            Questions[2].Answers.Add("correct3.2", true);
            Questions[2].Answers.Add("incorrect3.2", false);
        }
    }
}
