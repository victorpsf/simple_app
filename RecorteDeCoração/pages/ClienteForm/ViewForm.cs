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
using RecorteDeCoração.pages;

namespace RecorteDeCoração.pages.ClienteForm
{
    public partial class ViewForm : Form
    {
        private List<Cliente> clientes;
        private ClientePageForm form = null;

        public ViewForm()
        {
            InitializeComponent();
            this.LoadGrid();
        }

        private void ClearGrid()
        {
            this.dataGridView1.DataSource = null;
        }

        private List<Cliente> SetAndGetClientes()
        {
            this.clientes = (new ClienteController()).ListCliente();
            return this.clientes;
        }

        private Cliente GetClient(int listIndex)
        {
            if (this.clientes.Count < listIndex) return null;
            return this.clientes[listIndex];
        }

        public void LoadGrid()
        {
            this.ClearGrid();
            this.dataGridView1.DataSource = this.SetAndGetClientes();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        public void SetBaseForm(ClientePageForm form)
        {
            this.form = form;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Cliente cliente = this.GetClient(e.RowIndex);

            if (cliente == null) return;
            this.form.SetClient(cliente);
        }
    }
}
