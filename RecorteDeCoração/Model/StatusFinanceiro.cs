using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorteDeCoração.Model
{
    class StatusFinanceiro
    {
        public const int ENTRADA_ID = 1;
        public const int SAIDA_ID = 2;

        public const string ENTRADA_LABEL = "Entrada";
        public const string SAIDA_LABEL = "Saida";

        public static int GetId(string label)
        {
            switch(label)
            {
                case ENTRADA_LABEL: return ENTRADA_ID;
                case SAIDA_LABEL:   return SAIDA_ID;
                default:            throw new Exception("Invalid label to get ID");
            }
        }

        public static string GetLabel(int id) {
            switch (id)
            {
                case ENTRADA_ID: return ENTRADA_LABEL;
                case SAIDA_ID: return SAIDA_LABEL;
                default: throw new Exception("Invalid id to get LABEL");
            }
        }

        public static object[] GetLabels() {
            return new object[]
            {
                ENTRADA_LABEL,
                SAIDA_LABEL
            };
        }
    }
}
