using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorteDeCoração.Model
{
    internal class Produto
    {
        private long id;
        private string nome;
        private decimal valor_unitario;

        private Arquivo imagem;

        public Produto()
        {

        }

        public Produto(string nome, decimal valor_unitario): this()
        {
            this.nome = nome;
            this.valor_unitario = valor_unitario;
        }

        public Produto(string nome, decimal valor_unitario, Arquivo imagem) : this(nome, valor_unitario)
        {
            this.imagem = imagem;
        }

        public Produto(long id, string nome, decimal valor_unitario): this(nome, valor_unitario)
        {
            this.id = id;
        }

        public Produto(long id, string nome, decimal valor_unitario, Arquivo imagem): this(id, nome, valor_unitario)
        {
            this.imagem = imagem;
        }

        public long Id
        {
            get { return this.id; } 
        }

        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public decimal Valor_Unitario
        {
            get { return this.valor_unitario; }
            set { this.valor_unitario = value; }
        }

        public Arquivo Imagem
        {
            get { return this.imagem; }
            set { this.imagem = value; }
        }
    }
}
