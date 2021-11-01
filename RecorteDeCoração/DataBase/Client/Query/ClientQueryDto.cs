using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using RecorteDeCoração.Connection;
using RecorteDeCoração.ModelDto;
using System.Data;

namespace RecorteDeCoração.DataBase.Client.Query
{
    public class ClientQueryDto: DbConnection
    {
        public List<PersonDto> GetPerson()
        {
            List<PersonDto> persons = new List<PersonDto>();
            this.Open();

            MySqlCommand cmd = new MySqlCommand(ClientQuerySql.GetAllPersons, this.clientConnection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                persons.Add(
                    new PersonDto
                    {
                        PersonId = this.ReadInt(reader, "PERSONID"),
                        Name = this.ReadString(reader, "NAME"),
                        Cpf = this.ReadString(reader, "Cpf"),
                        Rg = this.ReadString(reader, "RG"),
                        BirthDate = this.ReadDateTime(reader, "BIRTHDATE"),
                        Cep = this.ReadString(reader, "CEP"),
                        Street = this.ReadString(reader, "STREET"),
                        Complement = this.ReadString(reader, "COMPLEMENT"),
                        OtherLocation = this.ReadString(reader, "OTHERLOCATION"),
                        Email = this.ReadString(reader, "EMAIL"),
                        Phone = this.ReadString(reader, "PHONE"),
                        OtherContact = this.ReadString(reader, "OTHERCONTACT"),
                        PersonType = (PersonTypes) this.ReadInt(reader, "PERSONTYPE")
                    }
                );
            }

            this.Close();

            return persons;
        }
    }
}
