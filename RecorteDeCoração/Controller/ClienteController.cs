using System;
using System.Collections.Generic;

using RecorteDeCoração.Model;
using RecorteDeCoração.Connection;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace RecorteDeCoração.Controller
{
    class ClienteController
    {
        public static Cliente Create(Cliente cliente)
        {
            DbConnection connection = new DbConnection();

            connection.Open();

            long scalar = connection.ExecuteScalar(
                "INSERT INTO `Cliente` (`Nome`,`Email`,`Telefone`) VALUES (@Nome, @Email, @Telefone);",
                new MySqlParameter("@Nome", cliente.Nome),
                new MySqlParameter("@Email", cliente.Email),
                new MySqlParameter("@Telefone", cliente.Telefone)
            );

            connection.Close();
            return new Cliente(scalar, cliente.Nome, cliente.Email, cliente.Telefone);
        }

        public static Cliente Update(Cliente cliente)
        {
            DbConnection connection = new DbConnection();

            connection.Open();
            connection.ExecuteNonQuery(
                "UPDATE `Cliente` SET `Nome` = @Nome, `Email` = @Email, `Telefone` = @Telefone WHERE (`Id` = @Id);",
                new MySqlParameter("@Id", cliente.Id),
                new MySqlParameter("@Nome", cliente.Nome),
                new MySqlParameter("@Email", cliente.Email),
                new MySqlParameter("@Telefone", cliente.Telefone)
            );
            connection.Close();

            return cliente;
        }

        public static void Delete(Cliente cliente)
        {
            DbConnection connection = new DbConnection();

            connection.Open();

            connection.ExecuteNonQuery(
                "DELETE FROM `Cliente` WHERE (`Id` = @Id AND `Nome` = @Nome AND `Email` = @Email AND `Telefone` = @Telefone)",
                new MySqlParameter("@Id", cliente.Id),
                new MySqlParameter("@Nome", cliente.Nome),
                new MySqlParameter("@Email", cliente.Email),
                new MySqlParameter("@Telefone", cliente.Telefone)
            );

            connection.Close();
        }

        public static List<Cliente> Get()
        {
            List<Cliente> clientes = new List<Cliente>();
            DbConnection connection = new DbConnection();

            connection.Open();

            MySqlDataReader reader = connection.ExecuteReader("SELECT * FROM `Cliente`;");

            while (reader.Read())
            {
                clientes.Add(
                    new Cliente(
                        reader.GetInt64("Id"),
                        reader["Nome"].ToString(),
                        reader["Email"].ToString(),
                        reader["Telefone"].ToString()
                    )
                );
            }

            connection.Close();

            return clientes;
        }

        public static Cliente Find(long id)
        {
            Cliente cliente = null;
            DbConnection connection = new DbConnection();

            connection.Open();

            MySqlDataReader reader = connection.ExecuteReader(
                "SELECT * FROM `Cliente` WHERE (`Id` = @Id);",
                new MySqlParameter("@Id", id)
            );

            if (reader.Read()) {
                cliente = new Cliente(
                    reader.GetInt64("Id"),
                    reader["Nome"].ToString(),
                    reader["Email"].ToString(),
                    reader["Telefone"].ToString()
                );
            }

            connection.Close();

            return cliente;
        }
    }
}
