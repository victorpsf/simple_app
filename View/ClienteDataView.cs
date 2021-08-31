using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecorteDeCoracao.View
{
    public partial class ClienteDataView : Form, ViewInterface
    {
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
    }
}
