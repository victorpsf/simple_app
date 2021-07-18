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
        private DbConnection dbconnection = new DbConnection();

        public void CreateCliente(Cliente cliente)
        {
            Exception err = null;

            try {
                this.dbconnection.Open();
            } 

            catch (MySqlException error) {
                throw new Exception("Falha ao abrir conexão com banco de dados!\n\n" + error.Message, error.InnerException);
            }

            MySqlParameter paramNome = new MySqlParameter("@Nome", cliente.Nome);
            MySqlParameter paramEmail = new MySqlParameter("@Email", cliente.Email);
            MySqlParameter paramTelefone = new MySqlParameter("@Telefone", cliente.Telefone);

            try {
                this.dbconnection.ExecuteNonQuery("INSERT INTO `Cliente` " +
                    "(`Nome`, `Email`, `Telefone`)" +
                    "VALUES (@Nome, @Email, @Telefone);",
                    paramNome, paramEmail, paramTelefone
                );
            } 

            catch (MySqlException error) { err = error; } 
            finally                      { this.dbconnection.Close(); }

            if (err != null) {
                throw new Exception("Error ao tentar salvar registro\n\n" + err.Message, err.InnerException);
            }
        }

        public void UpdateCliente(Cliente cliente)
        {
            Exception err = null;

            try {
                this.dbconnection.Open();
            }

            catch (MySqlException error) {
                throw new Exception("Falha ao abrir conexão com banco de dados!\n\n" + error.Message, error.InnerException);
            }

            MySqlParameter paramId = new MySqlParameter("@Id", cliente.Id);
            MySqlParameter paramNome = new MySqlParameter("@Nome", cliente.Nome);
            MySqlParameter paramEmail = new MySqlParameter("@Email", cliente.Email);
            MySqlParameter paramTelefone = new MySqlParameter("@Telefone", cliente.Telefone);

            try {
                this.dbconnection.ExecuteNonQuery("UPDATE `Cliente` SET" +
                    "`Nome` = @Nome, `Email` = @Email, `Telefone` = @Telefone WHERE (`Id` = @Id);",
                    paramNome, paramEmail, paramTelefone, paramId
                );
            }
            catch (MySqlException error) { err = error; }
            finally                      { this.dbconnection.Close(); }

            if (err != null) {
                throw new Exception("Error ao tentar atualizar registro\n\n" + err.Message, err.InnerException);
            }
        }

        public void DeleteCliente(Cliente cliente)
        {
            Exception err = null;

            try {
                this.dbconnection.Open();
            }

            catch (MySqlException error) {
                throw new Exception("Falha ao abrir conexão com banco de dados!\n\n" + error.Message, error.InnerException);
            }

            MySqlParameter paramId = new MySqlParameter("@Id", cliente.Id);
            MySqlParameter paramNome = new MySqlParameter("@Nome", cliente.Nome);
            MySqlParameter paramEmail = new MySqlParameter("@Email", cliente.Email);
            MySqlParameter paramTelefone = new MySqlParameter("@Telefone", cliente.Telefone);

            try {
                this.dbconnection.ExecuteNonQuery("DELETE FROM `Cliente` " +
                    "WHERE (`Id` = @Id AND `Nome` = @Nome AND `Email` = @Email AND `Telefone` = @Telefone);",
                    paramId, paramNome, paramEmail, paramTelefone
                );
            }
            catch (MySqlException error) { err = error; }
            finally                      { this.dbconnection.Close(); }

            if (err != null) {
                throw new Exception("Error ao tentar excluir registro\n\n" + err.Message, err.InnerException);
            }
        }

        public List<Cliente> ListCliente()
        {
            List<Cliente> clientes = new List<Cliente>();
            Exception err = null;

            try {
                this.dbconnection.Open();
            } catch (MySqlException error) {
                throw new Exception("Falha ao abrir conexão com banco de dados!\n\n" + error.Message, error.InnerException);
            }

            try {
                MySqlDataReader reader = this.dbconnection.ExecuteReader("SELECT * FROM Cliente;");

                while(reader.Read())
                {
                    clientes.Add(new Cliente(
                        reader.GetInt32(reader.GetOrdinal("Id")),
                        reader.GetString(reader.GetOrdinal("Nome")),
                        reader.GetString(reader.GetOrdinal("Email")),
                        reader.GetString(reader.GetOrdinal("Telefone"))
                    )); ;
                }
            }
            catch (MySqlException error) { err = error; }
            finally                      { this.dbconnection.Close();  }

            if (err != null) {
                throw new Exception("Error ao tentar excluir registro\n\n" + err.Message, err.InnerException);
            }

            return clientes;
        }
    }
}
