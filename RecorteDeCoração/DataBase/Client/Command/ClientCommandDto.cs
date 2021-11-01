using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using RecorteDeCoração.Connection;
using RecorteDeCoração.ModelDto;
using System.Data;

namespace RecorteDeCoração.DataBase.Client.Command
{
    public class ClientCommandDto : DbConnection
    {
        public int Save(PersonDto person)
        {
            this.Open();

            MySqlCommand cmd = new MySqlCommand(ClientCommandSql.SaveClient, this.clientConnection);

            cmd.Parameters.AddWithValue("@PERSONTYPE", person.PersonType);
            cmd.Parameters["@PERSONTYPE"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@NAME", person.Name);
            cmd.Parameters["@NAME"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@CPF", person.Cpf);
            cmd.Parameters["@CPF"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@RG", person.Rg);
            cmd.Parameters["@RG"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@BIRTHDATE", person.BirthDate);
            cmd.Parameters["@BIRTHDATE"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@CEP", person.Cep);
            cmd.Parameters["@CEP"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@STREET", person.Street);
            cmd.Parameters["@STREET"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@COMPLEMENT", person.Complement);
            cmd.Parameters["@COMPLEMENT"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@OTHERLOCATION", person.OtherLocation);
            cmd.Parameters["@OTHERLOCATION"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@EMAIL", person.Email);
            cmd.Parameters["@EMAIL"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PHONE", person.Phone);
            cmd.Parameters["@PHONE"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@OTHERCONTACT", person.OtherContact);
            cmd.Parameters["@OTHERCONTACT"].Direction = ParameterDirection.Input;

            cmd.ExecuteNonQuery();

            this.Close();

            return Convert.ToInt32(cmd.LastInsertedId);
        }
    }
}
