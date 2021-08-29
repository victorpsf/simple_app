using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel
{
    public class ClienteModel
    {
        public int Id
        { get; set; }

        public PessoaModel Pessoa
        { get; set; }

        public EnderecoModel Endereco
        { get; set; }

        public ContatoModel Contato
        { get; set; }

        public DateTime? CriadoEm
        { get; set; }

        public DateTime? AtualizadoEm
        { get; set; }

        public DateTime? DeletadoEm
        { get; set; }
    }
}
