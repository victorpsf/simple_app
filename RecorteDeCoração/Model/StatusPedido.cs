using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorteDeCoração.Model
{
    class StatusPedido
    {
        public const int SOLICITADO_ID = 1;
        public const int EM_PROCESSO_ID = 2;
        public const int CONFIRMADO_ID = 3;
        public const int ENTREGUE_ID = 4;
        public const int CANCELADO_ID = 5;

        public const string SOLICITADO_LABEL = "Solicitado";
        public const string EM_PROCESSO_LABEL = "Em Processo";
        public const string CONFIRMADO_LABEL = "Confirmado";
        public const string ENTREGUE_LABEL = "Entregue";
        public const string CANCELADO_LABEL = "Cancelado";

        public static string GetLabel(int id)
        {
            switch(id)
            {
                case SOLICITADO_ID:  return SOLICITADO_LABEL;
                case EM_PROCESSO_ID: return EM_PROCESSO_LABEL;
                case CONFIRMADO_ID:  return CONFIRMADO_LABEL;
                case ENTREGUE_ID:    return ENTREGUE_LABEL;
                case CANCELADO_ID:   return CANCELADO_LABEL;
                default:             return SOLICITADO_LABEL;
            }
        }

        public static int GetId(string label)
        {
            switch(label)
            {
                case SOLICITADO_LABEL:  return SOLICITADO_ID;
                case EM_PROCESSO_LABEL: return EM_PROCESSO_ID;
                case CONFIRMADO_LABEL:  return CONFIRMADO_ID;
                case ENTREGUE_LABEL:    return ENTREGUE_ID;
                case CANCELADO_LABEL:   return CANCELADO_ID;
                default:                return SOLICITADO_ID;
            }
        }

        public static object[] GetLabels()
        {
            return new object[] {
                SOLICITADO_LABEL,
                EM_PROCESSO_LABEL,
                CONFIRMADO_LABEL,
                ENTREGUE_LABEL,
                CANCELADO_LABEL
            };
        }
    }
}
