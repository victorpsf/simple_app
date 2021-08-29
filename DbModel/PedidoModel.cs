using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel
{
    public class PedidoModel
    {
        public int Id
        { get; set; }

        public int Status
        { get; set; }

        public DateTime DataPedido
        { get; set; }

        public DateTime DataEntrega
        { get; set; }

        public ClienteModel Cliente
        { get; set; }

        public DateTime? CriadoEm
        { get; set; }

        public DateTime? AtualizadoEm
        { get; set; }

        public DateTime? DeletadoEm
        { get; set; }
    }
}
