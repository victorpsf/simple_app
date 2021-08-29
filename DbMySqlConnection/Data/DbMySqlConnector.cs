using System;
using System.Data;

using MySql.Data.MySqlClient;

namespace DbMySqlConnection.Data
{
    public class DbMySqlConnector
    {
        private string ConnectionString;
        private MySqlConnection Connection;

        public DbMySqlConnector()
        {
            this.Connection = new MySqlConnection(this.ConnectionString);
        }

        public DbMySqlConnector(string ConnectionString) : this ()
        {
            this.ConnectionString = ConnectionString;
        }

        public void OpenConnection()
        {
            if (this.Connection.State != ConnectionState.Closed) return;
            this.Connection.Open();
        }

        public void CloseConnection()
        {
            if (this.Connection.State != ConnectionState.Open) return;
            this.Connection.Close();
        }

        private MySqlCommand PrepareCommand (string query, params DbMySqlParameter[] parameters)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(query, this.Connection);

            foreach (DbMySqlParameter parameter in parameters)
            {
                if (parameter == null) continue;
                mySqlCommand.Parameters.Add(parameter.Get());
            }

            return mySqlCommand;
        }

        public void ExecuteNonQuery (string query, params DbMySqlParameter[] parameters)
        {
            this.PrepareCommand(query, parameters).ExecuteNonQuery();
        }

        public MySqlDataReader ExecuteReader (string query, params DbMySqlParameter[] parameters)
        {
            return this.PrepareCommand(query, parameters).ExecuteReader();
        }

        public long ExecuteScalar (string query, params DbMySqlParameter[] parameters)
        {
            object scalar = this.PrepareCommand(query, parameters).ExecuteScalar();

            if (DbMySqlDataType.Instance(scalar).DbNull())
                return 0;
            else
                return Convert.ToInt64(scalar);
        }
    }
}
