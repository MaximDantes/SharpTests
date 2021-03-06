using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

                if (test.IsCompleted)
                {
                    query = $"SELECT `time` FROM `user_test` WHERE `user_id` = {Data.CurrentUser.Id} AND `test_id` = {(int)item.ItemArray[0]}";
                    DataTable timeTable = db.ExecuteQuery(query);
                    test.Time = (double)timeTable.Rows[0].ItemArray[0];
                }

                Data.Tests.Add(test);
            }
        }
        public static void GetTestsWithQuestions()
        {
            GetTests();

            List<Test> removeList = new List<Test>();

            foreach (Test item in Data.Tests)
            {
                GetQuestions(item.Id);

                if (item.Questions.Count == 0)
                {
                    removeList.Add(item);
                }
                else
                {
                    if (item.Level != 5)
                    {
                        for (int i = 0; i < item.Questions.Count; i++)
                        {
                            if (item.Questions[i].Answers.Count == 0)
                                removeList.Add(item);
                        }
                    }
                }
            }

            foreach (Test item in removeList)
            {
                Data.Tests.Remove(item);
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
            test.Questions.Clear();

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

                try { question.Answers.Add((string)item.ItemArray[4], true); } catch { }
                try { question.Answers.Add((string)item.ItemArray[5], true); } catch { }
                try { question.Answers.Add((string)item.ItemArray[6], true); } catch { }
                try { question.Answers.Add((string)item.ItemArray[7], false); } catch { }
                try { question.Answers.Add((string)item.ItemArray[8], false); } catch { }
                try { question.Answers.Add((string)item.ItemArray[9], false); } catch { }

                test.Questions.Add(question);
            }

            Data.Questions = test.Questions;
        }
        public static void GetUsers()
        {
            string query = $"SELECT `user_id`, `login` FROM `users`";
            DataTable table = db.ExecuteQuery(query);

            foreach (DataRow item in table.Rows)
            {
                User user = new User
                {
                    Id = (int)item.ItemArray[0],
                    Login = (string)item.ItemArray[1]
                };

                query = $"SELECT COUNT(*) FROM `user_test` WHERE `user_id` = {item.ItemArray[0]}";
                DataTable count = db.ExecuteQuery(query);
                user.TestsCount = Convert.ToInt32(count.Rows[0].ItemArray[0]);

                query = $"SELECT AVG(time) FROM `user_test` WHERE `user_id` = {item.ItemArray[0]}";
                DataTable time = db.ExecuteQuery(query);
                string resul = Convert.ToString(time.Rows[0].ItemArray[0]);
                if (String.IsNullOrEmpty(resul))
                    user.AvgTime = 0;
                else
                    user.AvgTime = Convert.ToDouble(resul);

                Data.Users.Add(user);
            }
        }

        public static List<Test> GetCompletedTests(int userId)
        {
            List<Test> arr = new List<Test>();

            string query = $"SELECT tests.test_id, tests.level, tests.title, user_test.time FROM `user_test` " +
                $"INNER JOIN `tests` ON `user_test`.`test_id` = `tests`.`test_id` WHERE `user_id` = {userId}";
            DataTable table = db.ExecuteQuery(query);
            foreach (DataRow item in table.Rows)
            {
                arr.Add(new Test
                {
                    Id = (int)item.ItemArray[0],
                    Level = (int)item.ItemArray[1],
                    Title = (string)item.ItemArray[2],
                    Time = (double)item.ItemArray[3]
                });
            }

            return arr;
        }

        public static void AddTest(string title, int level)
        {
            string query = $"INSERT INTO `tests`(`level`, `title`) VALUES ({level}, '{title}')";
            db.ExecuteQuery(query);
            GetTests();
        }
        public static void AddQuestion(int testId, string text)
        {
            string query = $"INSERT INTO `questions`(`test_id`, `type`, `text`) VALUES ({testId}, 'test', '{text}')";
            db.ExecuteNonQuery(query);
            GetQuestions(testId);
        }
        public static void AddAnswer(Question question, string text, bool isCorrect)
        {
            int correctCount = 0;
            int incorrectCount = 0;
            for (int i = 0; i < question.Answers.Count; i++)
            {
                if (question.Answers.ElementAt(i).Value)
                    correctCount++;
                else
                    incorrectCount++;
            }
            string query;

            if (isCorrect)
                query = $"UPDATE `questions` SET `correct_answer_{correctCount + 1}` = '{text}' WHERE `question_id` = {question.Id}";
            else
                query = $"UPDATE `questions` SET `incorrect_answer_{incorrectCount + 1}` = '{text}' WHERE `question_id` = {question.Id}";

            db.ExecuteNonQuery(query);

            GetQuestions(question.Test.Id);
        }

        public static void DeleteTest(int testId)
        {
            string query = $"DELETE FROM `tests` WHERE `test_id` = {testId}";
            db.ExecuteNonQuery(query);
            GetTests();
        }
        public static void DeleteQuestion(int questionId, int testId)
        {
            string query = $"DELETE FROM `questions` WHERE `question_id` = {questionId}";
            db.ExecuteNonQuery(query);
            GetQuestions(testId);
        }
        public static void DeleteAnswer(Question question, string text, bool isCorrect)
        {
            int correctCount = 0;
            int incorrectCount = 0;
            for (int i = 0; i < question.Answers.Count; i++)
            {
                if (question.Answers.ElementAt(i).Value)
                {
                    correctCount++;
                    if (question.Answers.ElementAt(i).Value == isCorrect && question.Answers.ElementAt(i).Key == text)
                        break;
                }
                else
                {
                    incorrectCount++;
                    if (question.Answers.ElementAt(i).Value == isCorrect && question.Answers.ElementAt(i).Key == text)
                        break;
                }
            }
            string query;

            if (isCorrect)
                query = $"UPDATE `questions` SET `correct_answer_{correctCount}`= NULL WHERE `question_id` = {question.Id}";
            else
                query = $"UPDATE `questions` SET `incorrect_answer_{incorrectCount}`= NULL WHERE `question_id` = {question.Id}";

            db.ExecuteNonQuery(query);

            GetQuestions(question.Test.Id);
        }

        public static void EditTest(int testId, string title, int level)
        {
            string query = $"UPDATE `tests` SET `level`={level},`title`='{title}' WHERE `test_id` = {testId}";
            db.ExecuteNonQuery(query);
            GetTests();
        }
        public static void EditQuestion(int questionId, int testId, string text)
        {
            string query = $"UPDATE `questions` SET`text` = '{text}' WHERE `question_id` = {questionId}";
            db.ExecuteNonQuery(query);
            GetQuestions(testId);
        }
        public static bool EditUser(int userId, string login, string password)
        {
            string query = $"UPDATE `users` SET `login`='{login}',`password`='{password}' WHERE `user_id` = {userId}";
            bool result = db.ExecuteNonQuery(query);
            SignIn(login, password);
            return result;
        }
        public static void EditAdmin(string login, string password)
        {
            string query = $"UPDATE `admin` SET `login`='{login}',`password`='{password}'";
            db.ExecuteQuery(query);
        }
        public static void EditAnswer(Question question, string text, bool isCorrect)
        {
            //TODO
            int correctCount = 0;
            int incorrectCount = 0;
            for (int i = 0; i < question.Answers.Count; i++)
            {
                if (question.Answers.ElementAt(i).Value)
                {
                    correctCount++;
                    if (question.Answers.ElementAt(i).Value == isCorrect && question.Answers.ElementAt(i).Key == text)
                        break;
                }
                else
                {
                    incorrectCount++;
                    if (question.Answers.ElementAt(i).Value == isCorrect && question.Answers.ElementAt(i).Key == text)
                        break;
                }
            }
            string query;

            if (isCorrect)
                query = $"UPDATE `questions` SET `correct_answer_{correctCount}`= '{text}' WHERE `question_id` = {question.Id}";
            else
                query = $"UPDATE `questions` SET `incorrect_answer_{incorrectCount}`= '{text} WHERE `question_id` = {question.Id}";

            db.ExecuteNonQuery(query);

            GetQuestions(question.Test.Id);
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
                SignIn(login, password);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string SignIn(string login, string password)
        {
            string query = $"SELECT `admin_id`, `login` FROM `admin` WHERE `login` = '{login}' AND `password` = '{password}'";
            DataTable table = db.ExecuteQuery(query);
            if (table.Rows.Count > 0)
            {
                Data.CurrentUser = new User()
                {
                    Id = 0,
                    Login = (string)table.Rows[0].ItemArray[1]
                };
                return "admin";
            }

            query = $"SELECT `user_id`, `login` FROM `users` WHERE `password` = '{password}' AND `login` = '{login}'";
            table = db.ExecuteQuery(query);
            if (table.Rows.Count > 0)
            {
                Data.CurrentUser = new User()
                {
                    Id = (int)table.Rows[0].ItemArray[0],
                    Login = (string)table.Rows[0].ItemArray[1]
                };
                return "user";
            }

            return null;
        }

        public static void CompleteTest(int testId, double time)
        {
            string query = $"SELECT `time` FROM `user_test` WHERE `test_id` = {testId}";
            DataTable table = db.ExecuteQuery(query);


            if (table.Rows.Count == 0)
            {
                query = $"INSERT INTO `user_test`(`test_id`, `user_id`, `time`) VALUES ({testId}, {Data.CurrentUser.Id}, {time.ToString(CultureInfo.InvariantCulture)})";
                db.ExecuteNonQuery(query);
            }
            else
            {
                double previousTime = (double)table.Rows[0].ItemArray[0];

                if (time < previousTime)
                {
                    query = $"UPDATE `user_test` SET `time`= {time.ToString(CultureInfo.InvariantCulture)} WHERE `test_id` = {testId}";
                    db.ExecuteNonQuery(query);
                }
            }
        }
        public static void MixAnswers(int testId)
        {
            Test test = Data.Tests.First(x => x.Id == testId);

            foreach (Question question in test.Questions)
            {
                int[] indexes = new int[question.Answers.Count];
                for (int i = 0; i < indexes.Length; i++)
                {
                    indexes[i] = i;
                }

                Random rand = new Random();
                for (int i = indexes.Length - 1; i >= 1; i--)
                {
                    int j = rand.Next(i + 1);

                    int tmp = indexes[j];
                    indexes[j] = indexes[i];
                    indexes[i] = tmp;
                }

                Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
                for (int i = 0; i < indexes.Length; i++)
                {
                    dictionary.Add(question.Answers.ElementAt(indexes[i]).Key, question.Answers.ElementAt(indexes[i]).Value);
                }

                question.Answers = dictionary;
            }
        }
    }
}
