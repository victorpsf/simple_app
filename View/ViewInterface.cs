using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorteDeCoracao.View
{
    interface ViewInterface
    {
        void Build();
        void ParentEstateData(object value);
        void ChildrenEstateData(object value);
    }
}
