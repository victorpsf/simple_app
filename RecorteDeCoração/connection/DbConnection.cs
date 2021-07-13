using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace RecorteDeCoração.connection
{
    class DbConnection
    {
        private string connectionString = "server=[dns|ip];" +
             "user id=[user];password=[password];database=[database]";
        private MySqlConnection clientConnection;

        public MySqlConnection ClienteConnection
        {
            get { return this.clientConnection; }
        }

        public DbConnection()
        {
            this.clientConnection = new MySqlConnection(this.connectionString);
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
