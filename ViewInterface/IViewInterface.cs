using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorteDeCoracao.ViewInterface
{
    interface IViewInterface
    {
        void Build();
        void ParentEstateData(object value);
        void ChildrenEstateData(object value);
    }
}
