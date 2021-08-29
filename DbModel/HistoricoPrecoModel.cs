using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel
{
    class HistoricoPrecoModel
    {
        public int Id
        { get; set; }

        public decimal Valor
        { get; set; }

        public ProdutoModel Produto
        { get; set; }

        public DateTime? CriadoEm
        { get; set; }

        public DateTime? DeletadoEm
        { get; set; }
    }
}
