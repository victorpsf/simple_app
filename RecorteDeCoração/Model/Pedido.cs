using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorteDeCoração.Model
{
    class Pedido
    {
        private int id;
        private Cliente cliente;
        private DateTime data_entrega;
        private DateTime data_pedido;
        private int status_pedido;
        private ProdutoPedido[] produto_pedido;
        private Financeiro[] valor_pago;

        public Pedido()
        {

        }

        public Pedido(Cliente cliente, DateTime data_entrega, DateTime data_pedido, int status_pedido) :this()
        {
            this.cliente = cliente;
            this.data_entrega = data_entrega;
            this.data_pedido = data_pedido;
            this.status_pedido = status_pedido;
        }

        public Pedido(Cliente cliente, DateTime data_entrega, DateTime data_pedido, string status_pedido_label) : this(cliente, data_entrega, data_pedido, StatusPedido.GetId(status_pedido_label))
        {

        }

        public Pedido(Cliente cliente, DateTime data_entrega, DateTime data_pedido, int status_pedido, ProdutoPedido[] produto_pedido, Financeiro[] valor_pago): this(cliente, data_entrega, data_pedido, status_pedido)
        {
            this.produto_pedido = produto_pedido;
            this.valor_pago = valor_pago;
        }

        public Pedido(Cliente cliente, DateTime data_entrega, DateTime data_pedido, string status_pedido_label, ProdutoPedido[] produto_pedido, Financeiro[] valor_pago) : this(cliente, data_entrega, data_pedido, StatusPedido.GetId(status_pedido_label), produto_pedido, valor_pago)
        {

        }



        public Pedido(int id, Cliente cliente, DateTime data_entrega, DateTime data_pedido, int status_pedido, ProdutoPedido[] produto_pedido, Financeiro[] valor_pago) : this(cliente, data_entrega, data_pedido, status_pedido, produto_pedido, valor_pago)
        {
            this.id = id;
        }

        public Pedido(int id, Cliente cliente, DateTime data_entrega, DateTime data_pedido, int status_pedido)
        {
            this.id = id;
            this.cliente = cliente;
            this.data_entrega = data_entrega;
            this.data_pedido = data_pedido;
            this.status_pedido = status_pedido;
        }

        public int Id
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

        public Financeiro[] Valor_Pago
        {
            get { return this.valor_pago; }
            set { this.valor_pago = value; }
        }
    }
}
