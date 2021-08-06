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
        public static ProdutoPedido Create(ProdutoPedido produtoPedido)
        {
            DbConnection connection = new DbConnection();

            connection.Open();

            long id = connection.ExecuteScalar(
                "INSERT INTO `Produto_Pedido` (`Produto`, `Pedido`, `Quantidade`, `Valor Total`) " +
                "VALUES (@Produto, @Pedido, @Quantidade, @ValorTotal);",
                new MySqlParameter("@Produto", produtoPedido.Produto.Id),
                new MySqlParameter("@Pedido", produtoPedido.Pedido.Id),
                new MySqlParameter("@Quantidade", produtoPedido.Quantidade),
                new MySqlParameter("@ValorTotal", produtoPedido.ValorPedidoProduto())
            );

            connection.Close();

            return new ProdutoPedido(
                id,
                produtoPedido.Produto,
                produtoPedido.Pedido,
                produtoPedido.Quantidade,
                produtoPedido.ValorPedidoProduto(),
                DateTime.Now
            );
        }

        public static ProdutoPedido[] FindWithPedido(Pedido pedido) {
            List<ProdutoPedido> produtoPedidos = new List<ProdutoPedido>();
            DbConnection connection = new DbConnection();

            connection.Open();

            MySqlDataReader reader = connection.ExecuteReader(
                "SELECT " +
                    "`Produto_Pedido`.`Id` as `Produto_Pedido_Id`, " +
                    "`Produto_Pedido`.`Quantidade` as `Produto_Pedido_Quantidade`, " +
                    "`Produto_Pedido`.`Valor Total` as `Produto_Pedido_Valor_Total`, " +
                    "`Produto_Pedido`.`Criado Em` as `Produto_Pedido_Criado_Em`, " +
                    "`Produto_Pedido`.`Pedido` as `Produto_Pedido_Pedido`, " +
                    "`Produto_Pedido`.`Produto` as `Produto_Pedido_Produto`, " +
                    "`Produto`.`Id` as `Produto_Id`, " +
                    "`Produto`.`Nome` as `Produto_Nome`, " +
                    "`Produto`.`Valor Unitario` as `Produto_Valor_Unitario`, " +
                    "`Produto`.`Imagem` as `Produto_Imagem`, " +
                    "`Produto`.`Criado Em` as `Produto_Criado_Em` " +
                "FROM " +
                    "`Produto_Pedido` " +
                "INNER JOIN " +
                    "`Produto` " +
                "ON " +
                    "`Produto`.`Id` = `Produto_Pedido`.`Produto`" +
                "WHERE " +
                    "(`Produto_Pedido`.`Pedido` = @PedidoId);",
                new MySqlParameter("@PedidoId", pedido.Id)
            );

            while(reader.Read()) {
                ProdutoPedido produtoPedido = new ProdutoPedido(
                    reader.GetInt64("Produto_Pedido_Id"),
                    null,
                    pedido,
                    reader.GetInt32("Produto_Pedido_Quantidade"),
                    reader.GetDecimal("Produto_Pedido_Valor_Total"),
                    reader.GetDateTime("Produto_Pedido_Criado_Em")
                );

                Produto produto = new Produto(
                    reader.GetInt64("Produto_Id"),
                    reader.GetString("Produto_Nome"),
                    reader.GetDecimal("Produto_Valor_Unitario"),
                    null,
                    reader.GetDateTime("Produto_Criado_Em")
                );

                if (connection.IsNotNull(reader, "Produto_Imagem"))
                    produto.Imagem = ArquivoController.Find(reader.GetInt64("Produto_Imagem"));
                
                produtoPedido.Produto = produto;

                produtoPedidos.Add(produtoPedido);
            }

            connection.Close();

            return produtoPedidos.ToArray();
        }

        public static void Delete(ProdutoPedido produtoPedido)
        {
            DbConnection connection = new DbConnection();

            connection.Open();

            connection.ExecuteNonQuery(
                "DELETE FROM `Produto_Pedido` WHERE (`Id` = @Id);",
                new MySqlParameter("@Id", produtoPedido.Id)
            );

            connection.Close();
        }

        public static void Update(ProdutoPedido produtoPedido)
        {
            DbConnection connection = new DbConnection();

            connection.Open();

            connection.ExecuteNonQuery(
                "UPDATE `Produto_Pedido` SET `Quantidade` = @Quantidade WHERE (`Id` = @Id);",
                new MySqlParameter("@Id", produtoPedido.Id),
                new MySqlParameter("@Quantidade", produtoPedido.Quantidade)
            );

            connection.Close();
        }
    }
}
