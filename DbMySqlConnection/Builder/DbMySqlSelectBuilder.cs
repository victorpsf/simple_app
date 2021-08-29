using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DbMySqlConnection.Data;

namespace DbMySqlConnection.Builder
{
    public class DbMySqlSelectBuilder : DbMySqlConnector
    {
        private string Table;
        private List<IDbMySqlSelect> SelectParameters = new List<IDbMySqlSelect>();
        private List<IDbMySqlSelectWhere> WhereParameters = new List<IDbMySqlSelectWhere>();
        private List<DbMySqlParameter> dbMySqlParameters = new List<DbMySqlParameter>();

        public DbMySqlSelectBuilder(string table) : base ()
        { this.Table = table; }

        public static DbMySqlSelectBuilder Instance (string table)
        {
            return new DbMySqlSelectBuilder(table);
        }

        public DbMySqlSelectBuilder Select(string column, string As = null)
        {
            this.SelectParameters.Add(new IDbMySqlSelect { Column = column, As = As });
            return this;
        }

        public DbMySqlSelectBuilder Where(IDbMySqlSelectWhere parameter)
        {
            parameter = parameter.ValidateComparison()
                                 .ValidateColumn()
                                 .ValidateProjection();

            this.WhereParameters.Add(parameter);
            this.dbMySqlParameters.Add(new DbMySqlParameter(parameter.GetProjection(), parameter.GetValue()));
            return this;
        }

        public string BuildQuery()
        {
            string query = "SELECT {0} FROM {1} ";
            string SelectClousure = "";
            string WhereClousure = "";

            if (this.SelectParameters.Count == 0)
                SelectClousure = "*";
            else
                for (int x = 0; x < this.SelectParameters.Count; x++)
                    SelectClousure += (x == 0) ?
                        String.Format(" {0} ", SelectParameters[x].GetQuery()) :
                        String.Format(", {0} ", SelectParameters[x].GetQuery());

            for (int x = 0; x < this.WhereParameters.Count; x++)
                WhereClousure +=
                    (x == 0) ?
                        String.Format(" {0} ", this.WhereParameters[x].GetQuery()) :
                        String.Format("AND {0} ", this.WhereParameters[x].GetQuery());

            query = String.Format(query, SelectClousure, DbMySqlUtilBuilder.FormatColumnString(this.Table));

            if (WhereClousure != "")
                query = String.Format("{0} WHERE ({1})", query, WhereClousure);

            return String.Format("{0};", query);
        }
    }
}
