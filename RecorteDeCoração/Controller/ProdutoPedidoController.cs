using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RecorteDeCoração.Connection;
using RecorteDeCoração.Model;
using RecorteDeCoração.Source;

using MySql.Data.MySqlClient;

namespace RecorteDeCoração.Controller
{
    class ProdutoPedidoController
    {
        //private DbConnection dbConnection = new DbConnection();

        //public List<ProdutoPedido> ListPedidoProdutoWithPedido(Pedido pedido)
        //{
        //    List<ProdutoPedido> produtoPedidos = new List<ProdutoPedido>();
        //    Exception err = null;
        //    MySqlDataReader reader = null;

        //    try {
        //        this.dbConnection.Open();                
        //    } 

        //    catch(MySqlException error) {
        //        throw new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException);
        //    }

        //    try {
        //        reader = this.dbConnection.ExecuteReader(
        //            "SELECT * FROM `Produto_Pedido` WHERE (`Pedido` = @PedidoId)", 
        //            new MySqlParameter("@PedidoId", pedido.Id)
        //        );
        //    }

        //    catch (MySqlException error) {
        //        err = new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException);
        //    }

        //    try {
        //        this.dbConnection.Close();
        //    }

        //    catch (MySqlException error) {
        //        throw new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException);
        //    }

        //    if (err != null) throw err;
        //    while(reader.Read())
        //    {
        //        produtoPedidos.Add(
        //            new ProdutoPedido(
        //                reader.GetInt32("Id"),
        //                (new ProdutoController()).GetProduto(reader.GetInt32("Produto")),
        //                pedido,
        //                reader.GetInt32("Quantidade"),
        //                reader.GetDecimal("Valor Total"),
        //                reader.GetDateTime("Criado em")
        //            )
        //        );
        //    }

        //    return produtoPedidos;
        //}

        //public ProdutoPedido CreateProdutoPedido(ProdutoPedido produtoPedido, Pedido pedido)
        //{
        //    long scalar = 0;
        //    DateTime createDate = DateTime.Now;
        //    Exception err = null;

        //    try
        //    {
        //        this.dbConnection.Open();
        //    }

        //    catch (MySqlException error)
        //    {
        //        throw new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException);
        //    }


        //    try
        //    {
        //        scalar = this.dbConnection.ExecuteScalar(
        //            "INSERT INTO `Produto_Pedido` " +
        //            "(`Produto`, `Pedido`, `Quantidade`, `Valor Total`, `Criado em`) VALUES " +
        //            "(@Produto, @Pedido, @Quantidade, @ValorTotal, @CriadoEm);",
        //            new MySqlParameter("@Produto", produtoPedido.Produto.Id),
        //            new MySqlParameter("@Pedido", pedido.Id),
        //            new MySqlParameter("@Quantidade", produtoPedido.Quantidade),
        //            new MySqlParameter("@ValorTotal", produtoPedido.ValorPedidoProduto()),
        //            new MySqlParameter("@CriadoEm", createDate)
        //        );
        //    }

        //    catch (MySqlException error) { err = new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException); }

        //    try {
        //        this.dbConnection.Close();
        //    } 

        //    catch(MySqlException error) {
        //        throw new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException);
        //    }

        //    if (err != null) throw err;
        //    return new ProdutoPedido(Convert.ToInt32(scalar), produtoPedido.Produto, pedido, produtoPedido.Quantidade, produtoPedido.ValorPedidoProduto(), createDate);
        //}
    }
}
