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

namespace RecorteDeCoração.Forms.PedidoForms
{
    public partial class PedidoClienteForm : Form
    {
        private List<Cliente> dataSource = new List<Cliente>();
        private List<Cliente> listView = new List<Cliente>();
        private Cliente cliente = null;
        private PedidoFormForm pedidoFormForm;

        public PedidoClienteForm(PedidoFormForm pedidoFormForm)
        {
            this.pedidoFormForm = pedidoFormForm;
            InitializeComponent();
            this.LoadTool();
        }

        private void LoadTool()
        {
            this.comboBox1.Text = "Id";
        }

        public void LoadData()
        {
            this.dataSource = ClienteController.Get();
            this.listView = this.dataSource;
        }

        public void ReloadGrid()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Refresh();
            this.dataGridView1.DataSource = this.listView;
            this.dataGridView1.Refresh();
        }

        private Cliente GetCliente(int index)
        {
            try {
                return this.listView[index];
            } 
            
            catch (Exception error) {
                LogController.WriteException(error);
                return null;
            }
        }

        private void SetInput(Cliente cliente) {
            this.cliente = cliente;

            this.label2.Text = this.cliente.Id.ToString();
            this.label4.Text = this.cliente.Nome;
            this.label6.Text = this.cliente.Email;
            this.label8.Text = this.cliente.Telefone;
        }

        public void ClearInput()
        {
            this.cliente = null;

            this.label2.Text = "";
            this.label4.Text = "";
            this.label6.Text = "";
            this.label8.Text = "";
        }

        // back
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.pedidoFormForm.CloseForm();
        }

        // search
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.listView = ClienteController.Filter(this.dataSource, this.comboBox1.Text, this.textBox1.Text);
            this.ReloadGrid();
        }

        // save
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.cliente == null) return;
            this.pedidoFormForm.SetCliente(this.cliente);
            this.pedidoFormForm.CloseForm();
        }

        // clear
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.ClearInput();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 && this.listView.Count < e.RowIndex) return;
            Cliente cliente = this.GetCliente(e.RowIndex);

            if (cliente == null) return;
            this.SetInput(cliente);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClienteController.ValidateFilterEvent(sender, e, this.comboBox1.Text);
        }
    }
}
