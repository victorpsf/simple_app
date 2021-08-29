using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMySqlConnection.Builder
{
    public class DbMySqlUtilBuilder
    {
        public static string FormatColumnString(string column)
        {
            List<string> convert = new List<string>(column.Split('.', '`'));
            int count = 0;
            string columnName = "";

            convert.ForEach((string value) =>
            {
                if (value == "") return;

                if (count == 0)
                    columnName = String.Format("`{0}`", value);
                else
                    columnName += String.Format(".`{0}`", value);
                count++;
            });

            return columnName;
        }
    }
}
