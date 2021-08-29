using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMySqlConnection.Builder
{
    class IDbMySqlSelect
    {
        public string Column
        { get; set; }

        public string As 
        { get; set; }

        public string GetQuery()
        {
            string resultString = DbMySqlUtilBuilder.FormatColumnString(this.Column);

            if (this.As != null)
                resultString = String.Format("{0} as {1}", resultString, DbMySqlUtilBuilder.FormatColumnString(this.As));
            return resultString;
        }
    }
}
