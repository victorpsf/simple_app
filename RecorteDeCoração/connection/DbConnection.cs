using MySql.Data.MySqlClient;


namespace RecorteDeCoração.connection
{
    class DbConnection
    {
        private MySqlConnection clientConnection;

        public MySqlConnection ClienteConnection
        {
            get { return this.clientConnection; }
        }

        public DbConnection()
        {
            this.clientConnection = new MySqlConnection(Configuration.ReadFile().ConnectionString());
        }

        public void Open()
        {
            this.clientConnection.Open();
        }

        public void Close()
        {
            this.clientConnection.Close();
        }

        private MySqlCommand PrepareCommand(string sql, MySqlParameter[] parameters)
        {
            MySqlCommand command = new MySqlCommand(sql, this.clientConnection);

            if (parameters != null)
            {
                foreach (MySqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        public MySqlCommand ExecuteNonQuery(string sql, params MySqlParameter[] parameters)
        {
            MySqlCommand command = PrepareCommand(sql, parameters); ;
            command.ExecuteNonQuery();
            return command;
        }

        public MySqlDataReader ExecuteReader(string sql, params MySqlParameter[] parameters)
        {
            MySqlCommand command = PrepareCommand(sql, parameters); ;
            return command.ExecuteReader();
        }
    }
}
