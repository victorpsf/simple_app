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
using RecorteDeCoração.Source;
using RecorteDeCoração.Controller;

namespace RecorteDeCoração.Pages.PedidoForm
{
    public partial class CreateForm : Form
    {
        //private Cliente cliente = null;
        //private Pedido pedido = null;
        //private PedidoPageForm mainForm;

        //private List<ProdutoPedido> produtosPedido = new List<ProdutoPedido>();

        //Solicitado              -> 
	       // : verifica se tem em estoque e passa para o cliente,
	       // : após amostrar ao cliente informa o valor e espera confirmação

        //Em processo  -> 
	       // : Projeto aprovado 50% pago

        //Confirmado              -> 
	       // : topo da listagem inicial, pronto

        //Entregue                -> 
	       // : a fim de registro, apenas para organização

        //Cancelado
	       // : pedido foi cancelado
        public CreateForm(PedidoPageForm mainForm)
        {
            //this.mainForm = mainForm;
            InitializeComponent();
        }

        //public void SetPedido(dynamic pedido = null)
        //{
        //    this.pedido = pedido;
        //    this.produtosPedido = new List<ProdutoPedido>(this.pedido.Produto_Pedido);
        //    this.SetInGrid(this.produtosPedido);
        //}

        //public void SetCliente(dynamic cliente)
        //{
        //    this.cliente = cliente as Cliente;
        //    this.label6.Text = this.cliente.Id.ToString();
        //}

        //public void SetPedidoProduto(dynamic pedidoProduto)
        //{
        //    this.produtosPedido.Add(pedidoProduto as ProdutoPedido);
        //    this.SetInGrid(this.produtosPedido);
        //}

        //public void VisibleForm(bool boolean)
        //{
        //    this.Visible = boolean;
        //}

        //public void LoadPage() {
        //    this.comboBox1.Items.AddRange(StatusPedido.GetLabels());
        //    this.comboBox1.Text = StatusPedido.GetLabel(StatusPedido.GetId(this.comboBox1.Text));
        //}

        //private void ClearInput()
        //{
        //    // Id
        //    this.label2.Text = "";

        //    // Cliente
        //    this.cliente = null;

        //    // Pedido produto
        //    this.produtosPedido = new List<ProdutoPedido>();
        //    this.SetInGrid(this.produtosPedido);

        //    // Id Cliente
        //    this.label6.Text = "";

        //    // data pedido
        //    this.dateTimePicker1.Value = DateTime.Now;

        //    // data entrega
        //    this.dateTimePicker2.Value = DateTime.Now;
        //}

        //private void SetInGrid(List<ProdutoPedido> produtosPedido) {
        //    this.dataGridView1.DataSource = null;

        //    List<dynamic> viewProdutosPedido = new List<dynamic>();
        //    foreach(ProdutoPedido produtoPedido in produtosPedido) {
        //        viewProdutosPedido.Add(new
        //        {
        //            Id = produtoPedido.Id,
        //            Nome = produtoPedido.Produto.Nome,
        //            Valor = produtoPedido.Produto.Valor_Unitario,
        //            Quantidade = produtoPedido.Quantidade,
        //            Total = produtoPedido.ValorPedidoProduto()
        //        });
        //    }

        //    this.dataGridView1.DataSource = viewProdutosPedido;
        //}

        //// add cliente
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    ClientePedido clientePedido = new ClientePedido(this);
        //    Cursor.Current = Cursors.WaitCursor;

        //    try {
        //        clientePedido.LoadPage();
        //        this.VisibleForm(false);
        //        clientePedido.Show();
        //    } 
            
        //    catch (Exception error)
        //    {
        //        this.VisibleForm(true);
        //        clientePedido.Close();
        //        MessageBox.Show(LogController.WriteExceptionAndGetMessage(error), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    Cursor.Current = Cursors.Default;
        //}

        //// salvar
        //private void pictureBox1_Click(object sender, EventArgs e)
        //{
        //    try {
        //        if (this.cliente == null) {
        //            throw new Exception("Cliente não selecionado");
        //        }

        //        if (this.produtosPedido.Count == 0) {
        //            throw new Exception("Não a produto para este pedido");
        //        }

        //        Pedido pedido = null;

        //        if (this.pedido == null) {
        //            pedido = new Pedido();
        //        }

        //        else {
        //            pedido = this.pedido;
        //        }

        //        pedido.Cliente = this.cliente;
        //        pedido.Produto_Pedido = this.produtosPedido.ToArray();
        //        pedido.Status_Pedido = StatusPedido.GetId(this.comboBox1.Text);
        //        pedido.Data_Pedido = this.dateTimePicker1.Value;
        //        pedido.Data_Entrega = this.dateTimePicker2.Value;

        //        if (this.pedido == null) {
        //            this.mainForm.SetNewPedido((new PedidoController()).CreatePedido(pedido));
        //        }

        //        else {

        //        }


        //        this.mainForm.VisibleForm(true);
        //        this.Close();
        //    }
            
        //    catch (Exception error) {
        //        MessageBox.Show(LogController.WriteExceptionAndGetMessage(error), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //} 

        //// clear
        //private void pictureBox2_Click(object sender, EventArgs e)
        //{
        //    this.ClearInput();
        //}

        //// excluir
        //private void pictureBox3_Click(object sender, EventArgs e)
        //{

        //}

        //private void pictureBox4_Click(object sender, EventArgs e)
        //{
        //    PedidoProduto pedidoProduto = new PedidoProduto(this);
        //    Cursor.Current = Cursors.WaitCursor;

        //    try
        //    {
        //        pedidoProduto.LoadPage();
        //        this.VisibleForm(false);
        //        pedidoProduto.Show();
        //    }

        //    catch (Exception error)
        //    {
        //        this.VisibleForm(true);
        //        pedidoProduto.Close();
        //        MessageBox.Show(LogController.WriteExceptionAndGetMessage(error), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    Cursor.Current = Cursors.Default;
        //}

        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    base.OnFormClosing(e);
        //    this.mainForm.VisibleForm(true);
        //}
    }
}
