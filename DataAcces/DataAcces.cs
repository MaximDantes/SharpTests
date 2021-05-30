using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTests
{
    static class DataAcces
    {
        static MySqlDataBase db = new MySqlDataBase();

 
        public static void GetTests()
        {
            string query = "SELECT * FROM `tests`";
            DataTable table = db.ExecuteQuery(query);

            foreach (DataRow item in table.Rows)
            {
                Data.Tests.Add(new Test()
                {
                    Id = (int)item.ItemArray[0],
                    Level = (int)item.ItemArray[1],
                    Title = (string)item.ItemArray[2],
                    IsCompleted = Convert.ToBoolean(item.ItemArray[3]),
                    Questions = new List<Question>()
                });
            }
        }
        public static void GetTests(int level)
        {
            Data.LevlelTests.Clear();
            foreach (Test item in Data.Tests)
            {
                if (item.Level == level)
                    Data.LevlelTests.Add(item);
            }
        }
        public static void GetQuestions(int testId)
        {
            string query = $"SELECT * FROM `questions` WHERE `test_id` = {testId}";
            DataTable table = db.ExecuteQuery(query);

            Test test = new Test();
            foreach (Test item in Data.Tests)
            {
                if (item.Id == testId)
                    test = item;
            }

            foreach (DataRow item in table.Rows)
            {
                Question question = new Question()
                {
                    Id = (int)item.ItemArray[0],
                    Test = test,
                    Type = (string)item.ItemArray[2],
                    Text = (string)item.ItemArray[3],
                    Answers = new Dictionary<string, bool>()
                };
                question.Answers.Add((string)item.ItemArray[4], true);
                try
                {
                    question.Answers.Add((string)item.ItemArray[5], true);
                    question.Answers.Add((string)item.ItemArray[6], true);
                }
                catch { }
                question.Answers.Add((string)item.ItemArray[7], false);
                try
                {
                    question.Answers.Add((string)item.ItemArray[8], false);
                    question.Answers.Add((string)item.ItemArray[9], false);
                }
                catch { }
                test.Questions.Add(question);
            }

            Data.Questions = test.Questions;
        }
    }
}
