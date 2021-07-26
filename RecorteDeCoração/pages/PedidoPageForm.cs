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
using RecorteDeCoração.Pages.PedidoForm;

namespace RecorteDeCoração.Pages
{
    public partial class PedidoPageForm : Form
    {
        //private CreateForm createForm;
        //private Main mainForm;
        //private List<Pedido> pedidos = new List<Pedido>();

        public PedidoPageForm(Main mainForm)
        {
            //this.mainForm = mainForm;
            InitializeComponent();
        }

        //public void LoadPage()
        //{

        //}

        //public void SetInGrid()
        //{
        //    this.dataGridView1.DataSource = null;
        //    this.dataGridView1.DataSource = this.pedidos;
        //}

        //public void SetNewPedido(dynamic pedido)
        //{
        //    this.pedidos.Add(pedido);
        //    this.SetInGrid();
        //}

        //// filtrar registros
        //private void button2_Click(object sender, EventArgs e)
        //{

        //}

        //// criar novo registro
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    this.createForm = new CreateForm(this);
        //    this.VisibleForm(false);
        //    this.createForm.LoadPage();
        //    this.createForm.Show();
        //}

        //public void VisibleForm(bool boolean)
        //{
        //    this.Visible = boolean;
        //}

        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    base.OnFormClosing(e);
        //    this.mainForm.VisibleForm(true);
        //}
    }
}
