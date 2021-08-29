using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel
{
    class GaleriaProdutoModel
    {
        public int Id
        { get; set; }

        public ProdutoModel Produto
        { get; set; }

        public ArquivoModel Arquivo
        { get; set; }

        public DateTime? CriadoEm
        { get; set; }

        public DateTime? AtualizadoEm
        { get; set; }

        public DateTime? DeletadoEm
        { get; set; }
    }
}
