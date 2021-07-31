using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;

using RecorteDeCoração.Interfaces;
using RecorteDeCoração.Model;
using RecorteDeCoração.Source;
using RecorteDeCoração.Controller;

namespace RecorteDeCoração.Forms
{
    public partial class ProdutoForm : Form
    {
        #region attributes
        private List<Produto> dataSource = new List<Produto>();
        private List<Produto> listView = new List<Produto>();
        private ProdutoController controller = new ProdutoController();

        private Arquivo file = new Arquivo();

        private int index = -1;
        private Produto produto = null;
        #endregion

        public ProdutoForm()
        {
            InitializeComponent();
            this.LoadTools();
        }

        #region page
        /// <summary>
        ///     initialize component
        /// </summary>
        public void InitializeGrid()
        {
            this.LoadData();
            this.ReloadGrid();
        }

        private void LoadTools()
        {
            this.comboBox1.Text = "Id";
            this.toolTip1.SetToolTip(this.pictureBox2, "Clique para salvar ou para alterar");
            this.toolTip2.SetToolTip(this.pictureBox3, "Clique para Limpar");
            this.toolTip3.SetToolTip(this.pictureBox4, "Clique para excluir registro selecionado");
            this.toolTip4.SetToolTip(this.pictureBox5, "Recarregar dados");
            this.toolTip5.SetToolTip(this.pictureBox1, "Filtrar dados");
            this.toolTip6.SetToolTip(this.pictureBox6, "Adicionar Imagem");
            this.toolTip7.SetToolTip(this.pictureBox7, "Remover Imagem");
        }

        /// <summary>
        ///     reload grid
        /// </summary>
        public void ReloadGrid()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Refresh();
            this.dataGridView1.DataSource = this.listView;
            this.dataGridView1.Refresh();
        }

        /// <summary>
        ///     get data 
        /// </summary>
        public void LoadData()
        {
            try {
                this.dataSource = ProdutoController.Get();
                this.listView = this.dataSource;
            }

            catch (Exception error) {
                MessageBox.Show("Não Foi possível fazer leitura dos Produtos.\n\n" +
                    "Por favor entre em contato com o administrador!\n\n" +
                    LogController.WriteExceptionAndGetMessage(error),
                    "Error: Falha Leitura dos dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop
                );
            }
        }

        /// <summary>
        ///     set values in view attributes
        /// </summary>
        /// <param name="produto"></param>
        private void InputValues(Produto produto)
        {
            this.ClearInput();
            this.produto = produto;

            this.labelId.Text = produto.Id.ToString();
            this.textBox1.Text = produto.Nome;
            this.textBox2.Text = produto.Valor_Unitario.ToString();

            if (produto.Imagem == null) return;
            this.pictureBox6.Image = null;
            this.pictureBox6.Image = FileController.BytesToBitmap(produto.Imagem.Binario, this.pictureBox6.Width, this.pictureBox6.Height);

        }

        /// <summary>
        ///     unset values in view attributes
        /// </summary>
        private void ClearInput()
        {
            this.file = null;

            this.labelId.Text = "";
            this.textBox1.Text = "";
            this.textBox2.Text = "";

            this.produto = null;
            this.pictureBox6.Image = null;
        }

        private Produto GetValueInList(int index)
        {
            try {
                return this.listView[index];
            } 
            
            catch (Exception error) {
                LogController.WriteException(error);
                return null;
            }
        }
        #endregion

        #region click
        // filter
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.listView = ProdutoController.Filter(this.dataSource, this.comboBox1.Text, this.textBox3.Text);
            this.ReloadGrid();

            Cursor.Current = Cursors.Default;
        }

        // add imagem
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (this.produto == null) {
                MessageBox.Show(
                    "Primeiro selecione o produto para depois vincular a imagem.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
                return;
            }

            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Selecione a Imagem.";
            dialog.Filter = "image .png (*.png)|*.png|image .jpeg (*.jpeg)|*.jpeg|image .jpg (*.jpg)|*.jpg";

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            Cursor.Current = Cursors.WaitCursor;
            ArquivoInfo info = FileController.FileInfo(dialog.FileName);
            Arquivo arquivo = null;

            try {
                arquivo = ArquivoController.Create(new Arquivo(info.Name, info.Extension, info.Length, FileController.ByteImage(dialog.FileName)));
            } 

            catch (Exception error) {
                LogController.WriteException(error);
                MessageBox.Show("Não foi possível criar a imagem!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }

            try {
                this.produto = ProdutoController.SetImagem(this.produto, arquivo);
                this.pictureBox6.Image = FileController.BytesToBitmap(this.produto.Imagem.Binario, this.pictureBox6.Width, this.pictureBox6.Height);
                MessageBox.Show("Imagem adicionada!");
            } 
            
            catch (Exception error) {
                ArquivoController.Delete(arquivo);
                LogController.WriteException(error);
                MessageBox.Show("Não foi possível adicionar a imagem!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        // remove imagem
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (this.produto == null)
                return;

            if (this.produto.Imagem == null) 
                return;

            Cursor.Current = Cursors.WaitCursor;
            try {
                ArquivoController.Delete(this.produto.Imagem);
                this.produto.Imagem = null;
                this.pictureBox6.Image = null;

                this.LoadData();
                this.ReloadGrid();
                MessageBox.Show("Imagem Removida!");
            } 

            catch(Exception error) {
                LogController.WriteException(error);
                MessageBox.Show("Não foi possível remover a imagem!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        private void CreateProduto()
        {
            try {
                Produto produto = ProdutoController.Create(
                    new Produto(
                        this.textBox1.Text,
                        Convert.ToDecimal(this.textBox2.Text)
                    )
                );

                this.produto = produto;
                this.dataSource.Add(produto);
                this.ReloadGrid();
                this.InputValues(produto);
            } 

            catch (Exception error) {
                LogController.WriteException(error);
                MessageBox.Show("Falha ao criar produto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateProduto()
        {
            try
            {
                this.produto.Nome = this.textBox1.Text;
                this.produto.Valor_Unitario = Convert.ToDecimal(this.textBox2.Text);

                ProdutoController.Update(this.produto);

                this.ClearInput();
                this.LoadData();                
                this.ReloadGrid();
            }

            catch (Exception error)
            {
                LogController.WriteException(error);
                MessageBox.Show("Falha ao salvar produto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // save or update
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (this.produto == null)
                this.CreateProduto();
            else
                this.UpdateProduto();

            Cursor.Current = Cursors.Default;
        }

        // delete
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (this.produto == null) return;

            DialogResult result = MessageBox.Show("Você realmente deseja remover ?", "Info: remoção de Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.No) return;

            MessageBox.Show("Se o produto não poder ser removido isso pode indicar que ele está ligado lógicamente com" +
                " outra informação, o sistema vai previnir a remoção para evitar perder informações" +
                " caso isto persista contate o administrador.", "Info: remoção de produto", MessageBoxButtons.OK, MessageBoxIcon.Information
            );

            Cursor.Current = Cursors.WaitCursor;
            if (this.produto.Imagem != null) {
                try {
                    ArquivoController.Delete(this.produto.Imagem);
                    this.produto.Imagem = null;
                } 

                catch (Exception error) {
                    LogController.WriteException(error);
                    MessageBox.Show("Não foi possível remover o produto!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor.Current = Cursors.Default;
                    return;
                }
            }

            try {
                ProdutoController.Delete(this.produto);
            } 
            
            catch (Exception error) {
                LogController.WriteException(error);
                MessageBox.Show("Não foi possível remover o produto!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }

            this.ClearInput();
            this.LoadData();
            this.ReloadGrid();

            Cursor.Current = Cursors.Default;
        }
        
        // refresh
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try { 
                this.LoadData();
                this.ReloadGrid();
            }
            catch (Exception error) {
                LogController.WriteException(error);
                MessageBox.Show("Não foi possivel recarregar registros", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        // clear
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.ClearInput();
        }

        #endregion

        #region controllers
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            this.textBox3.Text = "";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero e virgula");
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente uma virgula");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProdutoController.ValidateFilterEvent(sender, e, this.comboBox1.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || this.listView.Count < e.RowIndex) return;
            Produto produto = this.GetValueInList(e.RowIndex);
            if (produto == null) return;

            this.InputValues(produto);
        }
        #endregion
    }
}
