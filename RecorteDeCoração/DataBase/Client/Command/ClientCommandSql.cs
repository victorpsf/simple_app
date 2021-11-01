using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorteDeCoração.DataBase.Client.Command
{
    public class ClientCommandSql
    {
        public const string SaveClient = @"
INSERT INTO PERSON
       (`PERSONTYPE`, `NAME`, `CPF`, `RG`, `BIRTHDATE`, `CEP`, `STREET`, `COMPLEMENT`, `OTHERLOCATION`, `EMAIL`, `PHONE`, `OTHERCONTACT`)
VALUES (@PERSONTYPE, @NAME, @CPF, @RG, @BIRTHDATE, @CEP, @STREET, @COMPLEMENT, @OTHERLOCATION, @EMAIL, @PHONE, @OTHERCONTACT)
";
    }
}
