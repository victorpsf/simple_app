using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorteDeCoração.Model
{
    class ProdutoPedido
    {
        private int id;
        private Produto produto;
        private Pedido pedido;
        private int quantidade;
        private decimal valor_total;
        private DateTime criado_em;

        public ProdutoPedido()
        {

        }

        public ProdutoPedido(Produto produto, int quantidade): this()
        {
            this.produto = produto;
            this.quantidade = quantidade;
        }

        public ProdutoPedido(Produto produto, Pedido pedido, int quantidade) : this(produto, quantidade)
        {
            this.pedido = pedido;
        }

        public ProdutoPedido(int id, Produto produto, Pedido pedido, int quantidade) : this(produto, pedido, quantidade)
        {
            this.id = id;
        }

        public ProdutoPedido(int id, Produto produto, Pedido pedido, int quantidade, decimal valor_total, DateTime criado_em) : this(id, produto, pedido, quantidade)
        {
            this.valor_total = valor_total;
            this.criado_em = criado_em;
        }

        public decimal ValorPedidoProduto()
        {
            if (this.produto == null)
            {
                return 0;
            }

            return this.quantidade * this.produto.Valor_Unitario;
        }

        public int Id
        {
            get { return this.id; }
        }

        public Produto Produto
        {
            get { return this.produto; }
            set { this.produto = value; }
        }

        public Pedido Pedido
        {
            get { return this.pedido; }
            set { this.pedido = value; }
        }

        public int Quantidade
        {
            get { return this.quantidade; }
            set { this.quantidade = value; }
        }

        public decimal Valor_Total
        {
            get { return this.valor_total; }
            set { this.valor_total = value; }
        }

        public DateTime Criado_Em
        {
            get { return this.criado_em; }
            set { this.criado_em = value; }
        }
    }
}
