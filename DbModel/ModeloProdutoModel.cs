using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel
{
    public class ModeloProdutoModel
    {
        public int Id
        { get; set; }

        public ModeloModel Modelo
        { get; set; }

        public ProdutoModel Produto
        { get; set; }

        public DateTime? CriadoEm
        { get; set; }

        public DateTime? AtualizadoEm
        { get; set; }

        public DateTime? DeletadoEm
        { get; set; }
    }
}
