using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RecorteDeCoração.Forms.PedidoForms;
using RecorteDeCoração.Source;
using RecorteDeCoração.Controller;
using RecorteDeCoração.Model;

namespace RecorteDeCoração.Forms
{
    public partial class PedidoForm : Form
    {
        private Form currentForm = null;
        private List<Pedido> dataSource = new List<Pedido>();
        private List<Pedido> listView = new List<Pedido>();
        private Pedido pedido = null;

        public PedidoForm()
        {
            InitializeComponent();
            this.Initialize();
        }

        public void LoadData()
        {
            try {
                this.dataSource = PedidoController.Get();
                this.listView = this.dataSource;
            }

            catch (Exception error) {
                MessageBox.Show("Não Foi possível fazer leitura dos Pedidos.\n\n" +
                    "Por favor entre em contato com o administrador!\n\n" +
                    LogController.WriteExceptionAndGetMessage(error),
                    "Error: Falha Leitura dos dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop
                );
            }
        }

        public void ReloadGrid() {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Refresh();

            List<dynamic> viewDynamic = new List<dynamic>();
            foreach(Pedido pedido in this.listView) {
                dynamic value = new {
                    Id = pedido.Id,
                    Cliente = pedido.Cliente.Nome,
                    Entrega = pedido.Data_Entrega,
                    Pedido = pedido.Data_Pedido,
                    Status = StatusPedido.GetLabel(pedido.Status_Pedido)
                };

                viewDynamic.Add(value);
            }

            this.dataGridView1.DataSource = viewDynamic;
            this.dataGridView1.Refresh();
        }

        public void SetInput(dynamic pedido)
        {
            if (pedido == null) return;
            this.pedido = pedido as Pedido;

            this.label2.Text = this.pedido.Id.ToString();
            this.label4.Text = this.pedido.Cliente.Nome;
            this.label6.Text = this.pedido.Cliente.Telefone;
            this.label8.Text = this.pedido.Data_Entrega.ToString();
            this.label3.Text = StatusPedido.GetLabel(this.pedido.Status_Pedido);
        }

        public void UnSetInput()
        {
            this.pedido = null;

            this.label2.Text = "";
            this.label4.Text = "";
            this.label6.Text = "";
            this.label8.Text = "";
            this.label3.Text = "";
        }

        private Pedido GetPedido(int index) {
            try {
                return this.listView[index];
            } 
            
            catch (Exception error) {
                LogController.WriteException(error);
                return null;
            }
        }

        private void Initialize()
        {
            this.panel1.Controls.Add(this.tableLayoutPanel1);

            this.SetPositionTable(this.panel1.Location.X, this.panel1.Location.Y);
            this.OffSetTable(this.panel1.Width, this.panel1.Height);
            this.ShowTable(true);
        }

        private void CloseAndClearForm()
        {
            if (this.currentForm == null) return;
            this.currentForm.Close();

            this.ClearPanel();
            this.currentForm = null;
        }

        private void SetCurrentForm(Form form)
        {
            this.CloseAndClearForm();
            this.currentForm = form;
        }

        private void ClearPanel()
        {
            this.panel1.Controls.Clear();
        }

        private void AddInPanel(dynamic inpanel)
        {
            this.panel1.Controls.Add(inpanel);
        }

        private void SetPositionTable(int x, int y)
        {
            this.tableLayoutPanel1.Location = new System.Drawing.Point(x, y);
        }

        private void OffSetTable(int Width,int Height)
        {
            this.tableLayoutPanel1.Size = new System.Drawing.Size(Width, Height);
        }

        private void OffSetForm(int Width, int Height)
        {
            if (this.currentForm == null) return;

            this.currentForm.Size = new System.Drawing.Size(Width, Height);
        }

        private void ShowTable(bool boolean)
        {
            this.tableLayoutPanel1.Visible = boolean;
        }
        public void CloseForm()
        {
            this.CloseAndClearForm();
            this.Initialize();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.ClearPanel();

            PedidoFormForm pedidoForm = new PedidoFormForm(this) { TopLevel = false };

            this.SetCurrentForm(pedidoForm);
            this.AddInPanel(pedidoForm);
            this.OffSetForm(this.panel1.Width, this.panel1.Height);

            pedidoForm.Show();
        }

        private void PedidoForm_Resize(object sender, EventArgs e)
        {
            this.OffSetForm(this.panel1.Width, this.panel1.Height);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > this.listView.Count) return;
            Pedido pedido = this.GetPedido(e.RowIndex);
            if (pedido == null) return;
            this.SetInput(pedido);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.LoadData();
            this.ReloadGrid();

            Cursor.Current = Cursors.Default;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.UnSetInput();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.pedido == null) return;

        }
    }
}
