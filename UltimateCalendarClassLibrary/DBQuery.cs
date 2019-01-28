using MySql.Data.MySqlClient;

namespace UltimateCalendarClassLibrary
{
    abstract class DBQuery
    {
        protected MySqlConnection connection = null;
        protected MySqlCommand command = null;
        string connectionString;


        public DBQuery(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private void Open()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
            command = new MySqlCommand();
            command.Connection = connection;
        }

        public void Execute()
        {
            Open();

            ExecuteCommand();

            Close();
        }

        private void Close()
        {
            connection.Dispose();
        }

        public abstract void ExecuteCommand();
    }
}
