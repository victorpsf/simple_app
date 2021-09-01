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
    public partial class ModeloFormView : Form, IViewInterface
    {
        public ModeloFormView()
        {
            InitializeComponent();
        }

        public void Build() { }

        // obter instancia de Modelo Vazio ou com Registro
        public void ParentEstateData(object value)
        { }

        // sem utilidade neste view
        public void ChildrenEstateData(object value)
        { }
    }
}
