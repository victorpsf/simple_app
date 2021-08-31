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
    public partial class ModeloDataView : Form, ViewInterface
    {
        public ModeloDataView()
        {
            InitializeComponent();
        }

        public void Build() { }

        // sem utilidade neste view
        public void ParentEstateData(object value)
        { }

        // obter instancia de Modelo
        public void ChildrenEstateData(object value)
        { }
    }
}
