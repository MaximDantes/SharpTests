using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTests
{
    static class DataAcces
    {
        static MySqlDataBase db = new MySqlDataBase();

        public static bool AddUser(string nickname, string login, string password)
        {
            string query = $"INSERT INTO `users`(`nickname`, `login`, `password`) " +
                $"VALUES ('{nickname}', '{login}', '{password}')";
            return db.ExecuteNonQuery(query);
        }
    }
}
