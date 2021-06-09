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
            Data.Tests.Clear();

            string query = "SELECT * FROM `tests`";
            DataTable table = db.ExecuteQuery(query);

            foreach (DataRow item in table.Rows)
            {
                Test test = new Test()
                {
                    Id = (int)item.ItemArray[0],
                    Level = (int)item.ItemArray[1],
                    Title = (string)item.ItemArray[2],
                    Questions = new List<Question>()
                };

                query = $"SELECT* FROM `user_test` WHERE `user_id` = {Data.CurrentUser.Id} AND `test_id` = {(int)item.ItemArray[0]}";
                DataTable completedTabel = db.ExecuteQuery(query);
                if (completedTabel.Rows.Count > 0)
                    test.IsCompleted = true;
                else
                    test.IsCompleted = false;

                Data.Tests.Add(test);
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

        public static int CalcCompletedTestsCount(int level)
        {
            int count = 0;
            foreach (Test item in Data.Tests)
            {
                if (item.Level == level && item.IsCompleted)
                    count++;
            }
            return count;
        }
        public static int CalcTestsCount(int level)
        {
            int count = 0;
            foreach (Test item in Data.Tests)
            {
                if (item.Level == level)
                    count++;
            }
            return count;
        }

        public static bool SignUp(string login, string password)
        {
            string query = $"INSERT INTO `users`(`login`, `password`) VALUES ('{login}', '{password}')";
            if (db.ExecuteNonQuery(query))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool SignIn(string login, string password)
        {
            string query = $"SELECT `user_id`, `login` FROM `users` WHERE `password` = '{password}' AND `login` = '{login}'";
            DataTable table = db.ExecuteQuery(query);

            if (table.Rows.Count == 0)
                return false;

            Data.CurrentUser = new User()
            {
                Id = (int)table.Rows[0].ItemArray[0],
                Login = (string)table.Rows[0].ItemArray[1]
            };
            return true;
        }

        public static void CompleteTest(int testId, double time)
        {
            string query = $"INSERT INTO `user_test`(`test_id`, `user_id`, `time`) VALUES ({testId},{Data.CurrentUser.Id},{time})";

            db.ExecuteNonQuery(query);
        }
    }
}
