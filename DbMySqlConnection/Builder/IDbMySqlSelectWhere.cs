using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace DbMySqlConnection.Builder
{
    public class IDbMySqlSelectWhere
    {
        public string column 
        { get; set; }
        public string projection
        { get; set; }
        public string comparison
        { get; set; } = "=";
        public object value
        { get; set; } = null;

        public IDbMySqlSelectWhere ValidateComparison()
        {
            switch (this.comparison)
            {
                case "=":  case "!=": case ">=":
                case "<=": case ">":  case "<":
                case "is": case "is not":
                    break;
                default:
                    throw new Exception("IDbMySqlSelectWhere error: Invalid comparison");
            }

            return this;
        }

        public IDbMySqlSelectWhere ValidateProjection()
        {
            if (Regex.Match(this.projection, @"\@[a-zA-Z]+$").Success == false)
                this.projection = String.Format("@{0}", this.projection);

            return this;
        }

        public IDbMySqlSelectWhere ValidateColumn()
        {
            this.column = DbMySqlUtilBuilder.FormatColumnString(this.column);

            return this;
        }

        public string GetQuery()
        {
            return String.Format("{0} {1} {2}", this.column, this.comparison, this.projection);
        }

        public string GetProjection()
        {
            return this.projection;
        }

        public object GetValue ()
        {
            return this.value;
        }
    }
}
