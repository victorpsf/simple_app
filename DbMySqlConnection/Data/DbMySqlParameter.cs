using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace DbMySqlConnection.Data
{
    public class DbMySqlParameter
    {
        private MySqlParameter parameter;

        public DbMySqlParameter() 
        { this.parameter = new MySqlParameter(); }

        public DbMySqlParameter(string column)
        { this.parameter = new MySqlParameter(column, null); }

        public DbMySqlParameter(string column, object value)
        { this.parameter = new MySqlParameter(column, value); }
        
        public DbMySqlParameter AddColumn(string column)
        {
            this.parameter.ParameterName = column;
            return this;
        }

        public DbMySqlParameter AddValue(string column)
        {
            this.parameter.Value = column;
            return this;
        }

        public MySqlParameter Get()
        {
            return this.parameter;
        }
    }
}
