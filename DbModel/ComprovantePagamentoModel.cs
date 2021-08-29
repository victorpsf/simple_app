using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel
{
    class ComprovantePagamentoModel
    {
        public int Id
        { get; set; }

        public int EntidadeId
        { get; set; }

        public string EntidadeName
        { get; set; }

        public ArquivoModel Arquivo
        { get; set; }

        public DateTime? CriadoEm
        { get; set; }

        public DateTime? AtualizadoEm
        { get; set; }

        public DateTime? DeletadoEm
        { get; set; }
    }
}
