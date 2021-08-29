using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel
{
    class PessoaModel
    {
        public int Id
        { get; set; }

        public string Nome
        { get; set; }

        public int Cpf
        { get; set; }

        public int? Rg
        { get; set; }

        public DateTime DataNascimento
        { get; set; }

        public DateTime? CriadoEm
        { get; set; }

        public DateTime? AtualizadoEm
        { get; set; }

        public DateTime? DeletadoEm
        { get; set; }
    }
}
