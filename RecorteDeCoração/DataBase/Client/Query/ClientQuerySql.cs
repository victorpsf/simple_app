using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorteDeCoração.DataBase.Client.Query
{
    public class ClientQuerySql
    {
        public const string GetAllPersons = @"
SELECT
    *
FROM
    `PERSON`
";
    }
}
