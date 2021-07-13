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

namespace RecorteDeCoração.pages
{
    public partial class ProdutoPageForm : Form
    {
        private Arquivo arquivo = new Arquivo();
        private string path = "";

        public ProdutoPageForm()
        {
            InitializeComponent();

            this.button2.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Selecione a Imagem.";
            dialog.Filter = "image .jpeg (*.jpeg)|*.jpeg|image .jpg (*.jpg)|*.jpg|image .png (*.png)|*.png";

            if (dialog.ShowDialog() == DialogResult.OK) {
                this.path = dialog.FileName;
                this.pictureBox1.Image = this.arquivo.GetBitMap(this.path, this.pictureBox1.Width, this.pictureBox1.Height);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.ClearImage();
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ClearInput();
        }
    }
}
