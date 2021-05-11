using System.Data;
using MySqlConnector;

namespace SharpTests
{
    class MySqlDataBase
    {
        MySqlDataAdapter adapter;
        DataTable table;
        MySqlCommand command;
        MySqlDataReader reader;

        public MySqlConnection Connection { get; set; }

        public MySqlDataBase()
        {
            Connection = new MySqlConnection("server=127.0.0.1;port=3306;username=root;password=root;database=sharp_tests;");
        }
        public MySqlDataBase(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Open()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
        }
        public void Close()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
        }

        public DataTable ExecuteQuery(string query)
        {
            adapter = new MySqlDataAdapter();
            command = new MySqlCommand(query, Connection);
            table = new DataTable();

            this.Open();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            this.Close();

            return table;
        }
        public bool ExecuteNonQuery(string query)
        {
            command = new MySqlCommand(query, Connection);
            int result;

            this.Open();

            try
            {
                result = command.ExecuteNonQuery();
                if (result >= 1)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                this.Close();
            }
        }
        public MySqlDataReader ExecuteReader(string query)
        {
            this.Open();

            this.command = new MySqlCommand(query, Connection);
            reader = command.ExecuteReader();

            this.Close();

            return reader;
        }

        ~MySqlDataBase()
        {
            this.Close();
        }
    }
}
