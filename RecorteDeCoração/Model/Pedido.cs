using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorteDeCoração.Model
{
    class Pedido
    {
        private long id;
        private Cliente cliente;
        private DateTime data_entrega;
        private DateTime data_pedido;
        private DateTime criado_em;
        private int status_pedido;
        private ProdutoPedido[] produto_pedido;

        public Pedido() {

        }

        public Pedido(long id) : this() {
            this.id = id;
        }

        public Pedido(long id, Cliente cliente, DateTime data_entrega, DateTime data_pedido, int status_pedido) : this(id) {
            this.cliente = cliente;
            this.data_entrega = data_entrega;
            this.data_pedido = data_pedido;
            this.status_pedido = status_pedido;
        }

        public Pedido(long id, Cliente cliente, DateTime data_entrega, DateTime data_pedido, int status_pedido, DateTime criado_em) : this(id, cliente, data_entrega, data_pedido, status_pedido) {
            this.criado_em = criado_em;
        }

        public Pedido(Cliente cliente, DateTime data_entrega, DateTime data_pedido, int status_pedido) {
            this.cliente = cliente;
            this.data_entrega = data_entrega;
            this.data_pedido = data_pedido;
            this.status_pedido = status_pedido;
        }

        public Pedido(Cliente cliente, DateTime data_entrega, DateTime data_pedido, int status_pedido, ProdutoPedido[] produtoPedidos): this(cliente, data_entrega, data_pedido, status_pedido) {
            this.produto_pedido = produtoPedidos;
        }

        public decimal ValorTotalPedido()
        {
            if (this.produto_pedido == null) return 0;
            decimal ValorTotal = 0;

            foreach(ProdutoPedido produtoPedido in this.produto_pedido) {
                ValorTotal += produtoPedido.ValorPedidoProduto(true);
            }

            return ValorTotal;
        }

        public long Id
        {
            get { return this.id; }
        }

        public Cliente Cliente
        {
            get { return this.cliente; }
            set { this.cliente = value; }
        }

        public DateTime Data_Entrega
        {
            get { return this.data_entrega; }
            set { this.data_entrega = value; }
        }

        public DateTime Data_Pedido
        {
            get { return this.data_pedido; }
            set { this.data_pedido = value; }
        }

        public DateTime Criado_Em {
            get { return this.criado_em; }
            set { this.criado_em = value; }
        }

        public int Status_Pedido
        {
            get { return this.status_pedido; }
            set { this.status_pedido = value; }
        }

        public ProdutoPedido[] Produto_Pedido
        {
            get { return this.produto_pedido; }
            set { this.produto_pedido = value; }
        }
    }
}
