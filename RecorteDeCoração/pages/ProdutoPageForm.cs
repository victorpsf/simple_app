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
//using RecorteDeCoração.Pages.ProdutoForm;
using RecorteDeCoração.Source;
using RecorteDeCoração.Interfaces;

namespace RecorteDeCoração.Pages
{
  public partial class ProdutoPageForm : Form
  {
    //private string path = null;

    //private ProdutoController produtoController = new ProdutoController();
    //private ArquivoController arquivoController = new ArquivoController();

    //private ViewForm viewForm;
    //private Main mainForm;
    //private Produto produto;

    public ProdutoPageForm(Main mainForm)
    {
      //this.mainForm = mainForm;
      InitializeComponent();
    }

    //public void LoadPage()
    //{
    //  //this.button2.Enabled = false;
    //  this.SetView();
    //  this.SetToolTip();
    //}

    //private void SetToolTip()
    //{
    //  this.toolTip1.SetToolTip(this.pictureBox2, "Informação\n\nClique para salvar registro");
    //  this.toolTip2.SetToolTip(this.pictureBox3, "Informação\n\nLimpa dados informados.\n\nobs: caso tenha sido selecionado também limpa\nmas não exclui o registro.");
    //  this.toolTip3.SetToolTip(this.pictureBox4, "Informação\n\nRemove o dado selecionado.");

    //  this.toolTip4.SetToolTip(this.pictureBox5, "Informação\n\nAdiciona a imagem ao produto");
    //  this.toolTip5.SetToolTip(this.pictureBox6, "Informação\n\nRemove imagem do produto, \nnecessita da atualização do registro para \nmudar o registro na base de dados, \napós isto não podera ser disfeito");
    //}

    //private void SetView()
    //{
    //  this.viewForm = new ViewForm();

    //  this.viewForm.TopLevel = false;
    //  this.viewForm.Width = this.panel2.Width;
    //  this.viewForm.Height = this.panel2.Height;

    //  this.panel2.Controls.Clear();
    //  this.panel2.Controls.Add(this.viewForm);

    //  this.viewForm.SetBaseForm(this);
    //  this.viewForm.Show();
    //}

    //private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
    //{
    //  if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
    //  {
    //    e.Handled = true;
    //    MessageBox.Show("este campo aceita somente numero e virgula");
    //  }

    //  if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
    //  {
    //    e.Handled = true;
    //    MessageBox.Show("este campo aceita somente uma virgula");
    //  }
    //}

    //private void ClearImage()
    //{
    //  this.path = "";
    //  this.pictureBox1.Image = null;
    //}

    //private void ClearInput()
    //{
    //  this.ClearImage();

    //  this.produto = null;
    //  this.label2.Text = "";
    //  this.textBox1.Text = "";
    //  this.textBox2.Text = "";
    //}

    //private Arquivo ReadArquivo()
    //{
    //  if (this.path == null) return null;

    //  if (this.produto != null && this.produto.Imagem != null) {
    //    DialogResult result = MessageBox.Show("Mudança de imagem detectada deseja continuar ?\n\nCaso deseje a imagem anterior vai ser removida,\nnão vai ser possível recuperar.", "Mudança de imagem!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

    //    if (result == DialogResult.No) return this.produto.Imagem;

    //    this.arquivoController.DeleteArquivo(this.produto.Imagem);
    //    this.produto.Imagem = null;
    //    this.viewForm.LoadGrid();
    //  }

    //  ArquivoInfo info = FileController.FileInfo(this.path);
    //  return this.arquivoController.CreateArquivo(new Arquivo(info.Name, info.Extension, info.Length, FileController.ByteImage(this.path)));
    //}

    //// save
    //private void button1_Click(object sender, EventArgs e)
    //{
    //  try {
    //    Produto produto;

    //    if (this.produto == null) produto = new Produto();
    //    else                      produto = this.produto;

    //    produto.Nome = this.textBox1.Text;
    //    produto.Valor_Unitario = Convert.ToDecimal(this.textBox2.Text);
    //    produto.Imagem = this.ReadArquivo();

    //    if (this.produto == null)
    //        this.produtoController.CreateProduto(produto);
    //    else
    //        this.produtoController.UpdateProduto(produto);

    //    this.ClearInput();
    //    this.viewForm.LoadGrid();
    //  }

    //  catch (Exception error) {
    //    LogController.WriteException(error);
    //  }
    //}

    //// excluir
    //private void button2_Click(object sender, EventArgs e)
    //{
    //  if (this.produto == null) {
    //    MessageBox.Show("Primeiro selecione o registro para depois remover.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //  }

    //  DialogResult result = MessageBox.Show("Você solicitou a remoção deste registro!\n\nEste processo realiza a remoção completa, \nvocê não podera recuperar caso continue.\n\nDeseja continuar ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

    //  if (result == DialogResult.No) return;
    //  if (this.produto.Imagem != null) {
    //    this.arquivoController.DeleteArquivo(this.produto.Imagem);
    //    this.produto.Imagem = null;
    //  }

    //  this.produtoController.DeleteProduto(this.produto);
    //  this.ClearInput();
    //  this.viewForm.LoadGrid();
    //}

    //// clear
    //private void button3_Click(object sender, EventArgs e)
    //{
    //  this.ClearInput();
    //}

    //private void button4_Click(object sender, EventArgs e)
    //{
    //  OpenFileDialog dialog = new OpenFileDialog();

    //  dialog.Title = "Selecione a Imagem.";
    //  dialog.Filter = "image .png (*.png)|*.png|image .jpeg (*.jpeg)|*.jpeg|image .jpg (*.jpg)|*.jpg";

    //  if (dialog.ShowDialog() == DialogResult.OK) {
    //    this.path = dialog.FileName;
    //    this.pictureBox1.Image = FileController.GetBitMap(this.path, this.pictureBox1.Width, this.pictureBox1.Height);
    //  }
    //}

    //private void button5_Click(object sender, EventArgs e)
    //{
    //  if (this.produto == null) {
    //    this.ClearImage();
    //    return;
    //  }

    //  DialogResult result = MessageBox.Show("A imagem está vinculada ao produto, deseja remover ?\n\nAo continuar a imagem removida não podera ser recuperada.", "Remoção de imagem", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
    //  if (result == DialogResult.No) return;

    //  this.arquivoController.DeleteArquivo(this.produto.Imagem);
    //  this.produto.Imagem = null;
    //  this.ClearImage();
    //  this.viewForm.LoadGrid();
    //}

    //public void SetProduto(dynamic produto)
    //{
    //  //this.button2.Enabled = true;
    //  this.ClearInput();
    //  this.produto = produto;

    //  this.textBox1.Text = this.produto.Nome;
    //  this.textBox2.Text = this.produto.Valor_Unitario.ToString();
    //  this.label2.Text = this.produto.Id.ToString();

    //  if (this.produto.Imagem != null) {
    //    this.pictureBox1.Image = FileController.BytesToBitmap(this.produto.Imagem.Binario);
    //  }
    //}

    //protected override void OnFormClosing(FormClosingEventArgs e)
    //{
    //  base.OnFormClosing(e);
    //  this.mainForm.VisibleForm(true);
    //}

    //private void pictureBox4_Click(object sender, EventArgs e)
    //{

    //}
  }
}
