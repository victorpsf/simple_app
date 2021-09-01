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
    public partial class ClienteFormView : Form, IViewInterface
    {
        private ClienteDataView clienteDataView;

        public ClienteFormView(ClienteDataView clienteDataView, params object[] parameters)
        {
            InitializeComponent();
            this.clienteDataView = clienteDataView;
        }

        public void Build () { }

        // obter instancia de Cliente Vazio ou com Registro
        public void ParentEstateData(object value)
        { }

        // sem utilidade neste view
        public void ChildrenEstateData(object value)
        { }

        private void button2_Click(object sender, EventArgs e)
        {
            this.clienteDataView.ChangeFormPanelToViewPanel();
        }
    }
}
