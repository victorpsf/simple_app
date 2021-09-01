using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RecorteDeCoracao.ViewInterface;

namespace RecorteDeCoracao.View
{
    public partial class ClienteDataView : Form, IViewInterface, IViewData
    {
        private ClienteFormView clienteFormView;

        public ClienteDataView()
        {
            InitializeComponent();
        }

        public void Build() { }

        // sem utilidade neste view
        public void ParentEstateData(object value)
        { }

        // obter instancia de Cliente
        public void ChildrenEstateData(object value)
        { }


        public void ChangeViewPanelToFormPanel(params object[] parameters) {
            this.clienteFormView = new ClienteFormView(this, parameters) { TopLevel = false, Dock = DockStyle.Fill, FormBorderStyle = FormBorderStyle.None };

            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(this.clienteFormView);
            this.clienteFormView.Show();
        }

        public void ChangeFormPanelToViewPanel(params object[] parameters) {
            this.clienteFormView.Close();
            this.clienteFormView = null;

            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
        }

        public void ButtonViewClick(string type, object sender, EventArgs e, object value, object controller)
        { }

        // create
        private void button4_Click(object sender, EventArgs e)
        {
            this.ChangeViewPanelToFormPanel();
        }
    }
}
