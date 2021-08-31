using System;
using System.Data;

using MySql.Data.MySqlClient;

namespace DbMySqlConnection.Data
{
    public class DbMySqlConnector
    {
        protected string ConnectionString;
        protected MySqlConnection Connection;

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
            if (this.Connection.State == ConnectionState.Open) return;
            this.Connection.Open();
        }

        public void CloseConnection()
        {
            if (this.Connection.State == ConnectionState.Closed) return;
            this.Connection.Close();
        }
    }
}
