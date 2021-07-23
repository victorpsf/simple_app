using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RecorteDeCoração.Pages.PedidoForm;

namespace RecorteDeCoração.Pages
{
    public partial class PedidoPageForm : Form
    {
        private CreateForm createForm;
        private Main mainForm;

        public PedidoPageForm(Main mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        public void LoadPage()
        {

        }

        // filtrar registros
        private void button2_Click(object sender, EventArgs e)
        {

        }

        // criar novo registro
        private void button1_Click(object sender, EventArgs e)
        {
            this.createForm = new CreateForm(this);
            this.VisibleForm(false);
            this.createForm.Show();
        }

        public void VisibleForm(bool boolean)
        {
            this.Visible = boolean;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            this.mainForm.VisibleForm(true);
        }
    }
}
