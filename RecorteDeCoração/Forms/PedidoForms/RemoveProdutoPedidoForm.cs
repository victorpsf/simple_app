using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RecorteDeCoração.Model;
using RecorteDeCoração.Controller;
using RecorteDeCoração.Source;

namespace RecorteDeCoração.Forms.PedidoForms
{
    public partial class RemoveProdutoPedidoForm : Form
    {
        private List<ProdutoPedido> pedidoProdutos = new List<ProdutoPedido>();
        private PedidoFormForm pedidoFormForm = null;

        private ProdutoPedido produtoPedido = null;
        private int index = -1;

        public RemoveProdutoPedidoForm(PedidoFormForm pedidoFormForm, dynamic pedidoProdutos)
        {
            this.pedidoFormForm = pedidoFormForm;
            this.pedidoProdutos = pedidoProdutos as List<ProdutoPedido>;

            InitializeComponent();
            this.ReloadGrid();
        }

        private void SetInput(ProdutoPedido produtoPedido, int index)
        {
            this.index = index;
            this.produtoPedido = produtoPedido;

            this.label3.Text = produtoPedido.Produto.Nome;
            this.numericUpDown1.Value = produtoPedido.Quantidade;
        }

        private void UnSetInput()
        {
            this.index = 0;
            this.produtoPedido = null;

            this.label3.Text = "";
            this.numericUpDown1.Value = 0;
        }

        private void ReloadGrid()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Refresh();

            List<dynamic> view = new List<dynamic>();
            foreach (ProdutoPedido produtoPedido in this.pedidoProdutos)
            {
                dynamic value = new
                {
                    Nome = produtoPedido.Produto.Nome,
                    Valor = produtoPedido.Produto.Valor_Unitario,
                    Quantidade = produtoPedido.Quantidade,
                    Total = produtoPedido.ValorPedidoProduto()
                };

                view.Add(value);
            }

            this.dataGridView1.DataSource = view;
            this.dataGridView1.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > this.pedidoProdutos.Count) return;
            this.SetInput(this.pedidoProdutos[e.RowIndex], e.RowIndex);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.produtoPedido == null) return;
            if (Convert.ToInt32(this.numericUpDown1.Value) != this.produtoPedido.Quantidade) {
                this.produtoPedido.Quantidade = Convert.ToInt32(this.numericUpDown1.Value);
                ProdutoPedidoController.Update(this.produtoPedido);
            }

            this.pedidoFormForm.ChangeProdutoPedido("update", this.produtoPedido);
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.produtoPedido == null) return;
            if (this.produtoPedido.Id > 0) {
                ProdutoPedidoController.Delete(this.produtoPedido);
            }
            this.pedidoFormForm.ChangeProdutoPedido("delete", this.produtoPedido);
            this.Close();
        }
    }
}
