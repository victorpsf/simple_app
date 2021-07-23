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

namespace RecorteDeCoração.Pages.PedidoForm
{
    public partial class PedidoProduto : Form
    {
        private List<Produto> produtos;
        private List<Produto> viewProdutos;
        private Produto produto = null;
        private CreateForm createForm;
        private ProdutoController produtoController = new ProdutoController();

        public PedidoProduto(CreateForm createForm)
        {
            this.createForm = createForm;
            InitializeComponent();
        }

        public void LoadPage()
        {
            this.produtos = this.produtoController.ListProduto();
            this.viewProdutos = new List<Produto>(this.produtos);

            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.viewProdutos;
        }

        private void ClearImage() {
            this.pictureBox1.Image = null;
        }

        private void ClearInput()
        {
            this.produto = null;

            this.ClearImage();

            // Id
            this.label2.Text = "";

            // Nome
            this.label4.Text = "";

            // Valor
            this.label6.Text = "";

            // Quantidade
            this.numericUpDown1.Value = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > this.viewProdutos.Count()) return;
            Produto produto = this.viewProdutos[e.RowIndex];

            if (produto == null) {
                return;
            }

            this.ClearInput();
            this.produto = produto;

            this.label2.Text = this.produto.Id.ToString();
            this.label4.Text = this.produto.Nome;
            this.label6.Text = this.produto.Valor_Unitario.ToString();
        }

        //
        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (this.produto == null) {
                    throw new Exception("Produto não foi selecionado para ser adicionado");
                }

                if (this.numericUpDown1.Value == 0) {
                    throw new Exception("Informe a quantidade para adicionar o produto");
                }

                this.createForm.SetProduto(this.produto);
                this.createForm.VisibleForm(true);
                this.Close();
            } catch(Exception error) {
                MessageBox.Show(LogController.WriteExceptionAndGetMessage(error), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // limpar
        private void button3_Click(object sender, EventArgs e)
        {
            this.ClearInput();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            this.createForm.VisibleForm(true);
        }
    }
}
