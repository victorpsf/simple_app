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




        //private DbConnection dbconnection = new DbConnection();

        //private MySqlCommand BuildWhere(Cliente cliente, string selectQuery)
        //{
        //    List<string> whereQuery = new List<string>();
        //    List<dynamic> parameters = new List<dynamic>();

        //    if (cliente.Id > 0) {
        //        whereQuery.Add("`Id` = @Id");
        //        parameters.Add(new MySqlParameter("@Id", cliente.Id));
        //    }

        //    if (cliente.Nome.Length > 0) {
        //        whereQuery.Add("`Nome` = @Nome");
        //        parameters.Add(new MySqlParameter("@Nome", cliente.Nome));
        //    }

        //    if (cliente.Email.Length > 0) {
        //        whereQuery.Add("`Email` = @Email");
        //        parameters.Add(new MySqlParameter("@Email", cliente.Email));
        //    }

        //    if (cliente.Telefone.Length > 0) {
        //        whereQuery.Add("`Telefone` = @Telefone");
        //        parameters.Add(new MySqlParameter("@Telefone", cliente.Telefone));
        //    }

        //    if (whereQuery.Count == 0) return this.dbconnection.PrepareCommand((selectQuery + ";"));
        //    else {
        //        selectQuery += "WHERE (";

        //        for (int x = 0; x < whereQuery.Count; x++)
        //        {
        //            selectQuery += whereQuery[x];
        //            if (x < whereQuery.Count - 1)
        //            {
        //                selectQuery += " AND ";
        //            }
        //        }

        //        selectQuery += ");";
        //    }

        //    return this.dbconnection.PrepareCommand(selectQuery, parameters.ToArray() as MySqlParameter[]);
        //}

        //public Cliente CreateCliente(Cliente cliente)
        //{
        //    this.dbconnection.Open();

        //    long scalar = this.dbconnection.ExecuteScalar(
        //        "INSERT INTO `Cliente` " +
        //        "(`Nome`, `Email`, `Telefone`) VALUES " +
        //        "(@Nome, @Email, @Telefone);",
        //        new MySqlParameter("@Nome", cliente.Nome),
        //        new MySqlParameter("@Email", cliente.Email),
        //        new MySqlParameter("@Telefone", cliente.Telefone)
        //    );

        //    this.dbconnection.Close();
        //    return new Cliente(Convert.ToInt32(scalar), cliente.Nome, cliente.Email, cliente.Telefone);
        //}

        //public Cliente UpdateCliente(Cliente cliente)
        //{
        //    this.dbconnection.Open();

        //    this.dbconnection.ExecuteNonQuery(
        //        "UPDATE `Cliente` SET " +
        //        "`Nome` = @Nome, `Email` = @Email, `Telefone` = @Telefone " +
        //        "WHERE (`Id` = @Id);",
        //        new MySqlParameter("@Id", cliente.Id),
        //        new MySqlParameter("@Nome", cliente.Nome),
        //        new MySqlParameter("@Email", cliente.Email),
        //        new MySqlParameter("@Telefone", cliente.Telefone)
        //    );

        //    this.dbconnection.Close();

        //    return cliente;
        //}



        //public List<Cliente> ListCliente()
        //{
        //    List<Cliente> clientes = new List<Cliente>();
        //    Exception err = null;

        //    try {
        //        this.dbconnection.Open();
        //    } catch (MySqlException error) {
        //        throw new Exception("Falha ao abrir conexão com banco de dados!\n\n" + error.Message, error.InnerException);
        //    }

        //    try {
        //        MySqlDataReader reader = this.dbconnection.ExecuteReader("SELECT * FROM Cliente;");

        //        while(reader.Read())
        //        {
        //            clientes.Add(new Cliente(
        //                reader.GetInt32(reader.GetOrdinal("Id")),
        //                reader.GetString(reader.GetOrdinal("Nome")),
        //                reader.GetString(reader.GetOrdinal("Email")),
        //                reader.GetString(reader.GetOrdinal("Telefone"))
        //            )); ;
        //        }
        //    }
        //    catch (MySqlException error) { err = error; }
        //    finally                      { this.dbconnection.Close();  }

        //    if (err != null) {
        //        throw new Exception("Error ao tentar excluir registro\n\n" + err.Message, err.InnerException);
        //    }

        //    return clientes;
        //}
    }
}
