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
    class PedidoController
    {
        //private DbConnection dbconnection = new DbConnection();

        //private MySqlCommand BuildWhere(Pedido pedido, string selectQuery)
        //{
        //    string[] whereQuery = new string[] { };
        //    dynamic[] parameters = new dynamic[] { };

        //    if (pedido.Id > 0) {
        //        whereQuery.Append("`Id` = @Id");
        //        parameters.Append(new MySqlParameter("@Id", pedido.Id));
        //    }

        //    if (pedido.Status_Pedido > 0) {
        //        whereQuery.Append("`Status Pedido` = @StatusPedido");
        //        parameters.Append(new MySqlParameter("@StatusPedido", pedido.Status_Pedido));
        //    }

        //    //if ()

        //    if (whereQuery.Length == 0) return this.dbconnection.PrepareCommand((selectQuery + ";"));
        //    else {
        //        selectQuery += "WHERE (";

        //        for (int x = 0; x < whereQuery.Length; x++)
        //        {
        //            selectQuery += whereQuery[x];
        //            if (x < whereQuery.Length - 1)
        //            {
        //                selectQuery += " AND ";
        //            }
        //        }

        //        selectQuery += ");";
        //    }

        //    return this.dbconnection.PrepareCommand(selectQuery, parameters as MySqlParameter[]);
        //}

        //public List<Pedido> ListPedido(Pedido pedido)
        //{
        //    List<Pedido> pedidos = new List<Pedido>();
        //    Exception err = null;

        //    try {
        //        this.dbconnection.Open();
        //    } 
            
        //    catch(MySqlException error) {
        //        throw new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException);
        //    }

        //    try {
        //        MySqlCommand command = this.BuildWhere(
        //            pedido, 
        //            "SELECT " +
        //                "`Pedido`.`Id` as `PedidoId`, " +
        //                "`Pedido`.`Data Entrega` as `PedidoDE`, " +
        //                "`Pedido`.`Data Pedido` as `PedidoDP`, " +
        //                "`Pedido`.`Status` as `PedidoS`, " +
        //                "`Pedido`.`Valor Pago` as `PedidoVP`, " +
        //                "`Cliente`.`Id` as `ClienteId`, " +
        //                "`Cliente`.`Nome` as `ClienteN`, " +
        //                "`Cliente`.`Email` as `ClienteE`, " +
        //                "`Cliente`.`Telefone` as `ClienteT` " +
        //            " FROM `Pedido` " + 
        //                " INNER JOIN `Cliente` ON `Cliente`.`Id` = `Pedido`.`Cliente` "
        //        );
        //        MySqlDataReader reader = command.ExecuteReader();

        //        while(reader.Read()) {
        //            pedidos.Add(
        //                new Pedido(
        //                    reader.GetInt32("PedidoId"),
        //                    new Cliente(
        //                        reader.GetInt32("ClienteId"),
        //                        reader["ClienteN"].ToString(),
        //                        reader["ClienteE"].ToString(),
        //                        reader["ClienteT"].ToString()
        //                    ),
        //                    reader.GetDateTime("Data Entrega"),
        //                    reader.GetDateTime("Data Pedido"),
        //                    reader.GetInt32("Status"),
        //                    null,
        //                    null
        //                )
        //            );
        //        }
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

        //    if (err != null)
        //    {
        //        throw err;
        //    }

        //    for(int x = 0; x < pedidos.Count; x++)
        //    {
        //        Pedido build_pedido = pedidos[x];

        //        build_pedido.Valor_Pago = (new FinanceiroController()).ListFinanceiroWithPedido(build_pedido).ToArray();
        //        build_pedido.Produto_Pedido = (new ProdutoPedidoController()).ListPedidoProdutoWithPedido(build_pedido).ToArray();

        //        pedidos[x] = build_pedido;
        //    }

        //    return pedidos;
        //}
    
        //public Pedido CreatePedido(Pedido pedido)
        //{
        //    long scalar = 0;
        //    Exception err = null;

        //    try {
        //        this.dbconnection.Open();
        //    } 
            
        //    catch(MySqlException error) { throw new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException); }

        //    try {
        //        scalar = this.dbconnection.ExecuteScalar(
        //            "INSERT INTO `Pedido` " +
        //            "(`Cliente`, `Data Entrega`, `Data Pedido`, `Status`)" +
        //            "VALUES (@ClienteId, @DataEntrega, @DataPedido, @Status);",
        //            new MySqlParameter("@ClienteId", pedido.Cliente.Id),
        //            new MySqlParameter("@DataEntrega", pedido.Data_Entrega),
        //            new MySqlParameter("@DataPedido", pedido.Data_Pedido),
        //            new MySqlParameter("@Status", pedido.Status_Pedido)
        //        ) ;
        //    }

        //    catch (MySqlException error) { err = new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException); }

        //    try {
        //        this.dbconnection.Close();
        //    }

        //    catch (MySqlException error) { throw new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException); }

        //    if (err != null) throw err;

        //    ProdutoPedido[] produtoPedidos = pedido.Produto_Pedido;
        //    pedido = new Pedido(Convert.ToInt32(scalar), pedido.Cliente, pedido.Data_Entrega, pedido.Data_Pedido, pedido.Status_Pedido);

        //    for (int x = 0; x < produtoPedidos.Length; x++) {
        //        produtoPedidos[x] = (new ProdutoPedidoController()).CreateProdutoPedido(produtoPedidos[x], pedido);
        //    }

        //    pedido.Produto_Pedido = produtoPedidos;
        //    return pedido;
        //    //try
        //    //{
        //    //    this.dbconnection.Open();
        //    //}

        //    //catch (MySqlException error) { throw new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException); }

        //    //try
        //    //{

        //    //}

        //    //catch (MySqlException error) { err = new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException); }

        //    //try
        //    //{
        //    //    this.dbconnection.Close();
        //    //}

        //    //catch (MySqlException error) { throw new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException); }
        //}
    }
}
