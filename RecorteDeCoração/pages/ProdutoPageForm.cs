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
using RecorteDeCoração.pages.ProdutoForm;

namespace RecorteDeCoração.pages
{
    public partial class ProdutoPageForm : Form
    {
        private Arquivo arquivo = null;
        private string path = null;
        private ProdutoController produtoController = new ProdutoController();
        private ViewForm viewForm;

        public ProdutoPageForm()
        {
            InitializeComponent();

            this.button2.Enabled = false;
            this.SetView();
            this.SetToolTip();
        }

        private void SetToolTip()
        {
            this.toolTip1.SetToolTip(this.button1, "Informação\n\nClique para salvar registro");
            this.toolTip2.SetToolTip(this.button2, "Informação\n\nRemove o dado selecionado.");
            this.toolTip3.SetToolTip(this.button3, "Informação\n\nLimpa dados informados.\n\nobs: caso tenha sido selecionado também limpa\nmas não exclui o registro.");

            this.toolTip4.SetToolTip(this.button4, "Informação\n\nAdiciona a imagem ao produto");
            this.toolTip5.SetToolTip(this.button5, "Informação\n\nRemove imagem do produto, \nnecessita da atualização do registro para \nmudar o registro na base de dados, \napós isto não podera ser disfeito");
        }

        private void SetView()
        {
            this.viewForm = new ViewForm();

            this.viewForm.TopLevel = false;
            this.viewForm.Width = this.panel2.Width;
            this.viewForm.Height = this.panel2.Height;

            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(this.viewForm);

            this.viewForm.SetBaseForm(this);
            this.viewForm.Show();
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

        private void ClearImage()
        {
            this.path = "";
            this.pictureBox1.Image = null;
        }

        private void ClearInput()
        {
            this.ClearImage();

            this.label2.Text = "";
            this.textBox1.Text = "";
            this.textBox2.Text = "";
        }

        // save
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.path != null)
            {
                dynamic info = this.arquivo.FileInfo(this.path);
                this.arquivo = new Arquivo(info.Name, info.Tyoe, info.Length, this.arquivo.ByteImage(this.path));
            }


            new Produto(this.textBox1.Text, decimal.Parse(this.textBox2.Text), this.arquivo);
        }

        // excluir
        private void button2_Click(object sender, EventArgs e)
        {

        }

        // clear
        private void button3_Click(object sender, EventArgs e)
        {
            this.ClearInput();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Selecione a Imagem.";
            dialog.Filter = "image .jpeg (*.jpeg)|*.jpeg|image .jpg (*.jpg)|*.jpg|image .png (*.png)|*.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.path = dialog.FileName;
                this.pictureBox1.Image = (new Arquivo()).GetBitMap(this.path, this.pictureBox1.Width, this.pictureBox1.Height);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.ClearImage();
        }
    }
}
