using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DbMySqlConnection.Constants;

namespace DbMySqlConnection.Data
{
    class DbMySqlDataType
    {
        public object Data 
        { get; set; }

        public DbMySqlDataType() 
        { }

        public DbMySqlDataType(object Data) : this () 
        { this.Data = Data; }

        public static DbMySqlDataType Instance(object Data)
        { return new DbMySqlDataType { Data = Data }; }

        public bool DbNull ()
        {
            return DBNull.Value.Equals(this.Data) == true;
        }

        public DbMySqlDataReaderType GetDataType()
        {
            if (this.Data == null) 
                return DbMySqlDataReaderType.Nullable;

            try
            { return this.VerifyDataType(this.Data.GetType()); } 
            catch (Exception error) 
            {  }
            return this.GetDataTypeArray();
        }

        public DbMySqlDataReaderType GetDataTypeArray()
        {
            if (this.Data == null) 
                return DbMySqlDataReaderType.Nullable;
            return 
                this.VerifyDataType(this.Data.GetType().GetElementType());
        }

        private DbMySqlDataReaderType VerifyDataType(Type type)
        {
            switch(Type.GetTypeCode(type))
            {
                case TypeCode.String:   return DbMySqlDataReaderType.String;
                case TypeCode.Char:     return DbMySqlDataReaderType.Char;
                case TypeCode.DateTime: return DbMySqlDataReaderType.DateTime;
                case TypeCode.Boolean:  return DbMySqlDataReaderType.Boolean;
                case TypeCode.Decimal:  return DbMySqlDataReaderType.Decimal;
                case TypeCode.Int64:    return DbMySqlDataReaderType.Long;
                case TypeCode.Int32:    return DbMySqlDataReaderType.Int;
                default:                throw new Exception("Unsuported Value");
            }
        }
    }
}
