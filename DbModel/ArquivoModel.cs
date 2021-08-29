using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel
{
    class ArquivoModel
    {
        public int Id
        { get; set; }

        public string Nome
        { get; set; }

        public string Extensao
        { get; set; }

        public long Tamanho
        { get; set; }

        public byte[] Binario
        { get; set; }

        public DateTime? CriadoEm
        { get; set; }
    }
}
