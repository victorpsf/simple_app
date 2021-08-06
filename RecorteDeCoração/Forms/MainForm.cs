using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RecorteDeCoração.Source;

namespace RecorteDeCoração.Forms
{
    public partial class MainForm : Form
    {
        private Form currentForm = null;

        public MainForm()
        {
            InitializeComponent();
            this.UnsetForm();
            this.currentForm = new LogoForm() { TopLevel = false };
            this.SetForm();
        }

        private void UnsetForm()
        {
            if (this.currentForm != null)
                this.currentForm.Close();

            this.panel2.Controls.Clear();
            this.currentForm = null;
        }

        private void SetForm()
        {
            this.panel2.Controls.Add(this.currentForm);
            this.ResetOffSet();
            this.currentForm.Show();
        }

        private void ResetOffSet()
        {
            if (this.currentForm == null) return;

            this.currentForm.Width = this.panel2.Width;
            this.currentForm.Height = this.panel2.Height;
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            this.ResetOffSet();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.UnsetForm();
            this.currentForm = new LogoForm() { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            this.SetForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            ClienteForm cliente = new ClienteForm() { TopLevel = false, FormBorderStyle = FormBorderStyle.None };

            cliente.LoadData();
            cliente.ReloadGrid();

            Cursor.Current = Cursors.Default;

            this.UnsetForm();
            this.currentForm = cliente;
            this.SetForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            ProdutoForm produto = new ProdutoForm() { TopLevel = false, FormBorderStyle = FormBorderStyle.None };

            produto.LoadData();
            produto.ReloadGrid();

            Cursor.Current = Cursors.Default;

            this.UnsetForm();
            this.currentForm = produto;
            this.SetForm();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            PedidoForm pedido = new PedidoForm() { TopLevel = false, FormBorderStyle = FormBorderStyle.None };

            pedido.LoadData();
            pedido.ReloadGrid();

            Cursor.Current = Cursors.Default;

            this.UnsetForm();
            this.currentForm = pedido;
            this.SetForm();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            ArquivoForm arquivo = new ArquivoForm() { TopLevel = false, FormBorderStyle = FormBorderStyle.None };

            //arquivo.LoadData();
            //arquivo.ReloadGrid();

            Cursor.Current = Cursors.Default;

            this.UnsetForm();
            this.currentForm = arquivo;
            this.SetForm();
        }
    }
}
