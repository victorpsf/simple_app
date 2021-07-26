using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

using System.Windows.Forms;
using RecorteDeCoração.Pages;

using RecorteDeCoração.Source;

namespace RecorteDeCoração
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        //private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Versão 0.1.0\n\nBanco de dados externo.\nEste aplicativo foi pensado em resolver um problema de gerencia de uma pequena empresa!", "About app!", MessageBoxButtons.OK, MessageBoxIcon.Question);
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    ProdutoPageForm produto = new ProdutoPageForm(this);
        //    Cursor.Current = Cursors.WaitCursor;

        //    try {
        //        produto.LoadPage();
        //        this.VisibleForm(false);
        //        produto.Show();
        //    }

        //    catch (Exception error) {
        //        this.VisibleForm(true);
        //        produto.Close();
        //        MessageBox.Show(LogController.WriteExceptionAndGetMessage(error), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    Cursor.Current = Cursors.Default;
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    ClientePageForm cliente = new ClientePageForm(this);
        //    Cursor.Current = Cursors.WaitCursor;

        //    try {
        //        cliente.LoadPage();
        //        this.VisibleForm(false);
        //        cliente.Show();
        //    }

        //    catch (Exception error) {
        //        this.VisibleForm(true);
        //        cliente.Close();
        //        MessageBox.Show(LogController.WriteExceptionAndGetMessage(error), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    Cursor.Current = Cursors.Default;
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    PedidoPageForm pedido = new PedidoPageForm(this);
        //    Cursor.Current = Cursors.WaitCursor;

        //    try
        //    {
        //        pedido.LoadPage();
        //        this.VisibleForm(false);
        //        pedido.Show();
        //    }

        //    catch (Exception error)
        //    {
        //        this.VisibleForm(true);
        //        pedido.Close();
        //        MessageBox.Show(LogController.WriteExceptionAndGetMessage(error), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    Cursor.Current = Cursors.Default;
        //}

        //public void VisibleForm(bool visible) {
        //    this.Visible = visible;
        //}
    }
}
