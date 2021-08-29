using System;

using MySql.Data.MySqlClient;
using DbMySqlConnection.Constants;

namespace DbMySqlConnection.Data
{
    public class DbMySqlParameter
    {
        private string Column;
        private object Data;
        private MySqlParameter parameter;
        
        public DbMySqlParameter(string column, object data)
        {
            this.Column = column;
            this.Data = data;

            this.parameter = new MySqlParameter(parameterName: this.Column, value: data);
        }

        public MySqlParameter Get()
        {
            this.SetDataType();
            this.parameter.Value = this.Data;

            return this.parameter;
        }

        public void SetDataType ()
        {
            switch(DbMySqlDataType.Instance(this.Data).GetDataType())
            {
                case DbMySqlDataReaderType.String:   this.parameter.MySqlDbType = MySqlDbType.VarChar; break;
                case DbMySqlDataReaderType.Char:     this.parameter.MySqlDbType = MySqlDbType.VarChar; break;
                case DbMySqlDataReaderType.DateTime: this.parameter.MySqlDbType = MySqlDbType.DateTime; break;
                case DbMySqlDataReaderType.Boolean:  this.parameter.MySqlDbType = MySqlDbType.Bit;  break;
                case DbMySqlDataReaderType.Decimal:  this.parameter.MySqlDbType = MySqlDbType.Decimal; break;
                case DbMySqlDataReaderType.Long:     this.parameter.MySqlDbType = MySqlDbType.Int64; break;
                case DbMySqlDataReaderType.Int:      this.parameter.MySqlDbType = MySqlDbType.Int32;  break;
            }
        }
    }
}
