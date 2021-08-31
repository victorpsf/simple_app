using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace DbMySqlConnection.Data
{
    class MySqlExecuter : DbMySqlConnector
    {

        public MySqlExecuter (string ConnectionString) : base (ConnectionString)
        { }

        private MySqlCommand PrepareCommand(string query, params DbMySqlParameter[] parameters)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(query, this.Connection);

            foreach (DbMySqlParameter parameter in parameters)
            {
                if (parameter == null) continue;
                mySqlCommand.Parameters.Add(parameter.Get());
            }

            return mySqlCommand;
        }

        public void ExecuteNonQuery(string query, params DbMySqlParameter[] parameters)
        {
            this.PrepareCommand(query, parameters).ExecuteNonQuery();
        }

        public MySqlDataReader ExecuteReader(string query, params DbMySqlParameter[] parameters)
        {
            return this.PrepareCommand(query, parameters).ExecuteReader();
        }

        public long ExecuteScalar(string query, params DbMySqlParameter[] parameters)
        {
            object scalar = this.PrepareCommand(query, parameters).ExecuteScalar();

            if (DBNull.Value.Equals(scalar) || scalar == null)
                throw new Exception("Insert error");
            return Convert.ToInt64(scalar);
        }
    }
}
