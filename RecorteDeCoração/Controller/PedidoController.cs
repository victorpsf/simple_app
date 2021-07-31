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
        public static Pedido Create(Pedido pedido)
        {
            DbConnection connection = new DbConnection();

            connection.Open();

            long id = connection.ExecuteScalar(
                "INSERT INTO `Pedido` (`Cliente`, `Data Entrega`, `Data Pedido`, `Status`) " + 
                "VALUES (@Cliente, @DataEntrega, @DataPedido, @Status);",
                new MySqlParameter("@Cliente", pedido.Cliente.Id),
                new MySqlParameter("@DataEntrega", pedido.Data_Entrega),
                new MySqlParameter("@DataPedido", pedido.Data_Pedido),
                new MySqlParameter("@Status", pedido.Status_Pedido)
            );

            connection.Close();

            return new Pedido(
                id,
                pedido.Cliente,
                pedido.Data_Entrega,
                pedido.Data_Pedido,
                pedido.Status_Pedido
            );
        }

        public static List<Pedido> Get()
        {
            List<Pedido> pedidos = new List<Pedido>();
            DbConnection connection = new DbConnection();

            connection.Open();

            MySqlDataReader reader = connection.ExecuteReader(
                "SELECT " +
                    "`Cliente`.`Id` as `cliente_id`, " +
                    "`Cliente`.`Nome` as `cliente_nome`, " +
                    "`Cliente`.`Email` as `cliente_email`, " +
                    "`Cliente`.`Telefone` as `cliente_telefone`, " +
                    "`Pedido`.`Id` as `pedido_id`, " +
                    "`Pedido`.`Data Entrega` as `pedido_data_entrega`, " +
                    "`Pedido`.`Data Pedido` as `pedido_data_pedido`, " +
                    "`Pedido`.`Status` as `pedido_status`, " +
                    "`Pedido`.`Criado Em` as `pedido_criado_em` " +
                "FROM `Pedido` " +
                    "INNER JOIN `Cliente` ON `Cliente`.`Id` = `Pedido`.`Cliente`;"
            );

            while(reader.Read()) {
                pedidos.Add(
                    new Pedido(
                        reader.GetInt64("pedido_id"),
                        new Cliente(
                            reader.GetInt64("cliente_id"),
                            reader["cliente_nome"].ToString(),
                            reader["cliente_email"].ToString(),
                            reader["cliente_telefone"].ToString()
                        ),
                        reader.GetDateTime("pedido_data_entrega"),
                        reader.GetDateTime("pedido_data_pedido"),
                        reader.GetInt32("pedido_status"),
                        reader.GetDateTime("pedido_criado_em")
                    )
                );
            }

            connection.Close();

            for(int index = 0; index < pedidos.Count; index++) {
                Pedido pedido = pedidos[index];

                pedido.Produto_Pedido = ProdutoPedidoController.FindWithPedido(pedido);
            }

            return pedidos;
        }
    }
}
