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

namespace RecorteDeCoração.Forms.Pedido
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

        }

        // search
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        // save
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        // clear
        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
