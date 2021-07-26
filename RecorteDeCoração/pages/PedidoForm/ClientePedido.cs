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
    public partial class ClientePedido : Form
    {
        //private List<Cliente> clientes;
        //private List<Cliente> viewClientes;
        //private Cliente cliente = null;
        //private ClienteController clienteController = new ClienteController();
        //private CreateForm createForm;

        public ClientePedido(CreateForm createForm)
        {
            //this.createForm = createForm;
            InitializeComponent();
        }

        //public void LoadPage()
        //{
        //    this.clientes = this.clienteController.ListCliente();
        //    this.viewClientes = new List<Cliente>(this.clientes);

        //    this.dataGridView1.DataSource = null;
        //    this.dataGridView1.DataSource = this.viewClientes;
        //}

        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex < 0 || e.RowIndex > this.viewClientes.Count()) return;
        //    Cliente cliente = this.viewClientes[e.RowIndex];

        //    if (cliente == null) {
        //        return;
        //    }

        //    this.ClearInput();
        //    this.cliente = cliente;

        //    this.label2.Text = cliente.Id.ToString();
        //    this.label4.Text = cliente.Nome;
        //    this.label6.Text = cliente.Email;
        //    this.label8.Text = cliente.Telefone;
        //}

        //// adicionar
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try {
        //        if (this.cliente == null) {
        //            throw new Exception("Cliente não vinculado para adicionar");
        //        }

        //        this.createForm.SetCliente(this.cliente);
        //        this.createForm.VisibleForm(true);
        //        this.Close();
        //    }
            
        //    catch (Exception error) {
        //        MessageBox.Show("erro: " + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        LogController.WriteException(error);
        //    }
        //}

        //private void ClearInput () {
        //    this.cliente = null;

        //    // Id
        //    this.label2.Text = "";

        //    // Nome
        //    this.label4.Text = "";

        //    // Email
        //    this.label6.Text = "";

        //    // telefone
        //    this.label8.Text = "";
        //}

        //// limpar
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    this.ClearInput();
        //}

        //// filtrar
        //private void button3_Click(object sender, EventArgs e)
        //{

        //}

        //protected override void OnFormClosing(FormClosingEventArgs e) {
        //    base.OnFormClosing(e);
        //    this.createForm.VisibleForm(true);
        //}
    }
}
