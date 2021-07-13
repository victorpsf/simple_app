using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorteDeCoração.Model
{
    internal class Cliente
    {
        private int id;
        private string nome;
        private string email;
        private string telefone;

        public Cliente()
        {
        }

        public Cliente(string nome, string email, string telefone): this()
        {
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
        }

        public Cliente(int id, string nome, string email, string telefone): this(nome, email, telefone)
        {
            this.id = id;
        }

        public int Id
        {
            get { return this.id; }
        }

        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Telefone
        {
            get { return this.telefone; }
            set { this.telefone = value; }
        }
    }
}
