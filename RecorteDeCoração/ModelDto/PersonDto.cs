using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorteDeCoração.ModelDto
{
    // TABLE NAME 'PERSON'
    public class PersonDto
    {
        public int PersonId { get; set; }
        public PersonTypes PersonType { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cep { get; set; }
        public string Street { get; set; }
        public string Complement { get; set; }
        public string OtherLocation { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string OtherContact { get; set; }
    }
}
