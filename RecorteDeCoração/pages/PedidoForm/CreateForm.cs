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

namespace RecorteDeCoração.Pages.PedidoForm
{
    public partial class CreateForm : Form
    {

        private PedidoPageForm mainForm;
        private Cliente cliente = null;

        private List<PedidoProduto> pedidoProdutos = new List<PedidoProduto>();


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
            this.mainForm = mainForm;
            InitializeComponent();
        }

        public void LoadPage() {
            
        }

        public void SetCliente(dynamic cliente) {
            this.cliente = cliente;
            this.label6.Text = this.cliente.Id.ToString();
        }

        public void SetPedidoProduto(dynamic pedidoProduto) {
            this.pedidoProdutos.Add(pedidoProduto);
        }

        public void VisibleForm(bool boolean)
        {
            this.Visible = boolean;
        }

        // add cliente
        private void button1_Click(object sender, EventArgs e)
        {
            ClientePedido clientePedido = new ClientePedido(this);
            Cursor.Current = Cursors.WaitCursor;

            try {
                clientePedido.LoadPage();
                this.VisibleForm(false);
                clientePedido.Show();
            } 
            
            catch (Exception error)
            {
                this.VisibleForm(true);
                clientePedido.Close();
                MessageBox.Show(LogController.WriteExceptionAndGetMessage(error), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        // clear
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Id
            this.label2.Text = "";

            // Cliente
            this.cliente = null;

            // Id Cliente
            this.label6.Text = "";

            // data pedido
            this.dateTimePicker1.Value = DateTime.Now;

            // data entrega
            this.dateTimePicker2.Value = DateTime.Now;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            this.mainForm.VisibleForm(true);
        }
    }
}
