using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RecorteDeCoração.Model;
using RecorteDeCoração.Connection;
using RecorteDeCoração.Source;

using MySql.Data.MySqlClient;

namespace RecorteDeCoração.Controller
{
    class FinanceiroController
    {
        //private void 
        //private DbConnection dbconnection = new DbConnection();

        //public List<Financeiro> ListFinanceiroWithPedido(Pedido pedido)
        //{
        //    List<Financeiro> financeiros = new List<Financeiro>();
        //    Exception err = null;
        //    MySqlDataReader reader = null;

        //    try {
        //        this.dbconnection.Open();
        //    }

        //    catch (MySqlException error) {
        //        throw new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException);
        //    }

        //    try {
        //        reader = dbconnection.ExecuteReader(
        //            "SELECT * FROM `Pagamento` WHERE (`Pedido` = @PedidoId);",
        //            new MySqlParameter("@PedidoId", pedido.Id)
        //        );
        //    }

        //    catch (MySqlException error) {
        //        err = new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException);
        //    }

        //    try {
        //        this.dbconnection.Close();
        //    }

        //    catch (MySqlException error) {
        //        throw new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException);
        //    }

        //    if (err != null) throw err;
        //    while(reader.Read()) {
        //        financeiros.Add(
        //            new Financeiro(
        //                reader.GetInt32("Id"),
        //                reader.GetDecimal("Valor"),
        //                reader.GetInt32("Status"),
        //                pedido,
        //                (new ArquivoController()).GetArquivo(reader.GetInt32("Comprovante"))
        //            )
        //        );
        //    }

        //    return financeiros;
        //}
    }
}
