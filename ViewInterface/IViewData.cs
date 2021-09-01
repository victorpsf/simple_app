using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RecorteDeCoracao.Delegates;

namespace RecorteDeCoracao.ViewInterface
{
    interface IViewData
    {
        void ButtonViewClick(string type, object sender, EventArgs e, object value, object controller);

        void ChangeViewPanelToFormPanel(params object[] parameters);

        void ChangeFormPanelToViewPanel(params object[] parameters);


        //public void Build() { }

        //public void ParentEstateData(object value)
        //{ }

        //public void ChildrenEstateData(object value)
        //{ }

        //public void ButtonViewClick(string type, object sender, EventArgs e, object value, object controller)
        //{ }

        //public void ChangeViewPanelToFormPanel() { }

        //public void ChangeFormPanelToViewPanel() { }
    }
}
