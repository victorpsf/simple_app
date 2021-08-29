using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel
{
    public class ProdutoModel
    {
        public int Id
        { get; set; }

        public string Nome
        { get; set; }

        public decimal Valor
        { get; set; }

        public DateTime? CriadoEm
        { get; set; }

        public DateTime? AtualizadoEm
        { get; set; }

        public DateTime? DeletadoEm
        { get; set; }
    }
}
