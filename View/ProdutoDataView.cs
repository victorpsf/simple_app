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
    public partial class ProdutoDataView : Form, IViewInterface, IViewData
    {
        public ProdutoDataView()
        {
            InitializeComponent();
        }

        public void Build() { }

        // sem utilidade neste view
        public void ParentEstateData(object value)
        { }

        // obter instancia de Produto
        public void ChildrenEstateData(object value)
        { }

        public void ButtonViewClick(string type, object sender, EventArgs e, object value, object controller)
        { }

        public void ChangeViewPanelToFormPanel(params object[] parameters) { }

        public void ChangeFormPanelToViewPanel(params object[] parameters) { }
    }
}
