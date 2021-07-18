using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecorteDeCoração.Pages
{
    public partial class PedidoForm : Form
    {
        private Main mainForm;

        public PedidoForm(Main mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        public void LoadPage() {
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            this.mainForm.VisibleForm(true);
        }
    }
}
