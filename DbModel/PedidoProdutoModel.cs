using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel
{
    public class PedidoProdutoModel
    {
        public int Id
        { get; set; }

        public int Quantidade
        { get; set; }

        public decimal ValorTotal
        { get; set; }

        public ProdutoModel Produto
        { get; set; }

        public PedidoModel Pedido
        { get; set; }

        public DateTime? CriadoEm
        { get; set; }

        public DateTime? AtualizadoEm
        { get; set; }

        public DateTime? DeletadoEm
        { get; set; }
    }
}
