using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecorteDeCoração.pages;

using RecorteDeCoração.src;

namespace RecorteDeCoração
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Versão 0.1.0\n\nBanco de dados externo.\nEste aplicativo foi pensado em resolver um problema de gerencia de uma pequena empresa!", "About app!", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProdutoPageForm produto = new ProdutoPageForm();

            produto.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientePageForm cliente = new ClientePageForm();

            cliente.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PedidoForm pedido = new PedidoForm();

            pedido.Show();
        }
    }
}
