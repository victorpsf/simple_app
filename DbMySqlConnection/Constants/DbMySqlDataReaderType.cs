using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMySqlConnection.Constants
{
    public enum DbMySqlDataReaderType
    {
        Nullable = 0,
        Int = 1,
        Long = 2,
        String = 3,
        Decimal = 4,
        DateTime = 5,
        Char = 6,
        Boolean = 7
    }
}
