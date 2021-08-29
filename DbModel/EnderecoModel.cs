using System;

namespace DbModel
{
    public class EnderecoModel
    {
        public int Id
        { get; set; }

        public int Cep
        { get; set; }

        public string Rua
        { get; set; }

        public string Complemento
        { get; set; }

        public string Outros
        { get; set; }

        public DateTime? CriadoEm
        { get; set; }

        public DateTime? AtualizadoEm
        { get; set; }

        public DateTime? DeletadoEm
        { get; set; }
    }
}
