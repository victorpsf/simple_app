using MySql.Data.MySqlClient;

namespace RecorteDeCoração.Connection
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
            if (this.clientConnection.State == System.Data.ConnectionState.Open)
                this.clientConnection.Close();
        }

        public MySqlCommand PrepareCommand(string sql, MySqlParameter[] parameters = null)
        {
            MySqlCommand command = new MySqlCommand(sql, this.clientConnection);

            if (parameters != null)
            {
                foreach (MySqlParameter parameter in parameters)
                {
                    if (parameter == null) continue;
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        public MySqlCommand ExecuteNonQuery(string sql, params MySqlParameter[] parameters)
        {
            MySqlCommand command = this.PrepareCommand(sql, parameters); ;
            command.ExecuteNonQuery();
            return command;
        }

        public MySqlDataReader ExecuteReader(string sql, params MySqlParameter[] parameters)
        {
            MySqlCommand command = this.PrepareCommand(sql, parameters); ;
            return command.ExecuteReader();
        }

        public long ExecuteScalar(string sql, params MySqlParameter[] parameters) {
            MySqlCommand command = this.PrepareCommand(sql, parameters);

            command.ExecuteScalar();
            return command.LastInsertedId;
        }
    }
}
