//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//using RecorteDeCoração.Model;
//using RecorteDeCoração.Controller;
//using RecorteDeCoração.Source;

//namespace RecorteDeCoração.Forms.PedidoForms
//{
//    public partial class ProdutoPedidoForm : Form
//    {
//        private List<Produto> dataSource = new List<Produto>();
//        private List<Produto> listView = new List<Produto>();
//        private Produto produto = null;
//        private PedidoFormForm pedidoFormForm;

//        public ProdutoPedidoForm(PedidoFormForm pedidoFormForm)
//        {
//            this.pedidoFormForm = pedidoFormForm;

//            InitializeComponent();
//            this.LoadTool();
//        }

//        public void LoadTool()
//        {
//            this.comboBox1.Text = "Id";
//        }

//        public void LoadData()
//        {
//            this.dataSource = ProdutoController.Get();
//            this.listView = this.dataSource;
//        }

//        public void ReloadGrid()
//        {
//            this.dataGridView1.DataSource = null;
//            this.dataGridView1.Refresh();

//            this.dataGridView1.DataSource = this.listView;
//            this.dataGridView1.Refresh();
//        }

//        public void ClearInput()
//        {
//            this.label2.Text = "";
//            this.label4.Text = "";
//            this.label6.Text = "";

//            this.pictureBox3.Image = null;

//            this.produto = null;

//            this.numericUpDown1.Value = 0;
//        }

//        private void SetInput(Produto produto)
//        {
//            this.produto = produto;

//            this.label2.Text = produto.Id.ToString();
//            this.label4.Text = produto.Nome;
//            this.label6.Text = produto.Valor_Unitario.ToString();

//            if (produto.Imagem != null)
//            {
//                this.pictureBox3.Image = FileController.BytesToBitmap(produto.Imagem.Binario, this.pictureBox3.Width, this.pictureBox3.Height);
//            }

//            this.numericUpDown1.Value = 0;
//        }

//        private Produto GetProduto(int index)
//        {
//            try
//            {
//                return this.listView[index];
//            }

//            catch (Exception error)
//            {
//                LogController.WriteException(error);
//                return null;
//            }
//        }

//        /// <summary>
//        ///     valor combobox alterado
//        /// </summary>
//        /// 
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
//        {
//            this.textBox1.Text = "";
//        }

//        /// <summary>
//        ///     buscar conteudo
//        /// </summary>
//        /// 
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void pictureBox2_Click(object sender, EventArgs e)
//        {
//            this.listView = ProdutoController.Filter(this.dataSource, this.comboBox1.Text, this.textBox1.Text);
//            this.ReloadGrid();
//        }

//        /// <summary>
//        ///     novo valor adicionado
//        /// </summary>
//        /// 
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            ProdutoController.ValidateFilterEvent(sender, e, this.comboBox1.Text);
//        }

//        /// <summary>
//        ///     adicionar produto ao pedido
//        /// </summary>
//        /// 
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void pictureBox6_Click(object sender, EventArgs e)
//        {
//            if (this.produto == null) return;
//            if (Convert.ToInt32(this.numericUpDown1.Value) <= 0)
//            {
//                MessageBox.Show("Informe uma quantidade", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            this.pedidoFormForm.SetPedidoProduto(
//                new ProdutoPedido(
//                    this.produto,
//                    Convert.ToInt32(this.numericUpDown1.Value)
//                )
//            );
//            this.pedidoFormForm.CloseForm();
//        }

//        /// <summary>
//        ///     limpar dados informados
//        /// </summary>
//        /// 
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void pictureBox7_Click(object sender, EventArgs e)
//        {
//            this.ClearInput();
//        }

//        /// <summary>
//        ///     atualizar lista de produtos
//        /// </summary>
//        /// 
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void pictureBox9_Click(object sender, EventArgs e)
//        {
//            Cursor.Current = Cursors.WaitCursor;

//            try
//            {
//                this.LoadData();
//                this.ReloadGrid();
//            }

//            catch (Exception error)
//            {
//                LogController.WriteException(error);
//                MessageBox.Show("Não foi possível recarregar informações", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }

//            Cursor.Current = Cursors.Default;
//        }

//        /// <summary>
//        ///     adicionar produto ao input values
//        /// </summary>
//        /// 
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex < 0 || e.RowIndex > this.listView.Count) return;
//            Produto produto = this.GetProduto(e.RowIndex);

//            if (produto == null) return;
//            this.SetInput(produto);
//        }

//        private void pictureBox1_Click(object sender, EventArgs e)
//        {
//            this.pedidoFormForm.CloseForm();
//        }
//    }
//}
