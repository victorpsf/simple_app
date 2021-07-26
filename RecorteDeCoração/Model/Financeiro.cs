using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorteDeCoração.Model
{
    class Financeiro
    {
        private int id;
        private decimal valor;
        private int status;
        private Pedido pedido;
        private Arquivo arquivo;

        public Financeiro()
        {

        }

        public Financeiro(decimal valor, int status) : this()
        {
            this.valor = valor;
            this.status = status;
        }

        public Financeiro(decimal valor, string status): this(valor, StatusFinanceiro.GetId(status))
        {

        }

        public Financeiro(decimal valor, int status, Pedido pedido, Arquivo arquivo): this(valor, status)
        {
            this.pedido = pedido;
            this.arquivo = arquivo;
        }

        public Financeiro(decimal valor, string status, Pedido pedido, Arquivo arquivo) : this(valor, StatusFinanceiro.GetId(status))
        {
            this.pedido = pedido;
            this.arquivo = arquivo;
        }

        public Financeiro(int id, decimal valor, int status, Pedido pedido, Arquivo arquivo): this(valor, status, pedido, arquivo)
        {
            this.id = id;
        }

        public int Id
        {
            get { return this.id; }
        }

        public decimal Valor
        {
            get { return this.valor; }
            set { this.valor = value; }
        }

        public int Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public Pedido Pedido
        {
            get { return this.pedido; }
            set { this.pedido = value; }
        }

        public Arquivo Arquivo
        {
            get { return this.arquivo; }
            set { this.arquivo = value; }
        }
    }
}
