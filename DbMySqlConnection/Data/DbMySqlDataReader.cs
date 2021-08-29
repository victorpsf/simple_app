using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using DbMySqlConnection.Constants;

namespace DbMySqlConnection.Data
{
    public class DbMySqlDataReader
    {
        private MySqlDataReader reader;

        public DbMySqlDataReader(MySqlDataReader reader)
        {
            this.reader = reader;
        }

        private string GetMethodName(DbMySqlDataReaderType type)
        {
            switch(type)
            {
                case DbMySqlDataReaderType.Int:      return "GetInt32";
                case DbMySqlDataReaderType.Long:     return "GetInt64";
                case DbMySqlDataReaderType.Decimal:  return "GetDecimal";
                case DbMySqlDataReaderType.String:   return "GetString";
                case DbMySqlDataReaderType.DateTime: return "GetDateTime";
                default:
                    throw new Exception("Invalid Type Reader");
            }
        }

        private object GetDefaultValue(DbMySqlDataReaderType type)
        {
            switch(type)
            {
                case DbMySqlDataReaderType.Int:      return 0;
                case DbMySqlDataReaderType.Long:     return 0;
                case DbMySqlDataReaderType.Decimal:  return 0;
                case DbMySqlDataReaderType.String:   return "";
                case DbMySqlDataReaderType.DateTime: return null;
                default:
                    throw new Exception("Invalid Type Reader");
            }
        }

        private bool isNull(object value)
        {
            return DBNull.Value.Equals(value);
        }

        public bool Read()
        {
            return this.reader.Read();
        }

        public object GetData(string column, DbMySqlDataReaderType type)
        {
            if (this.isNull(this.reader[column]))
                return this.GetDefaultValue(type);

            string MethodName = this.GetMethodName(type);
            Type instance     = this.reader.GetType();
            MethodInfo method = instance.GetMethod(MethodName);
            
            return method.Invoke(this.reader, new object[] { column });
        }
    }
}
