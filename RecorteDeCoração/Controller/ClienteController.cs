using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RecorteDeCoração.Model;
using RecorteDeCoração.connection;
using System.Data.SqlClient;
using System.Windows.Forms;

using System.Data;
using MySql.Data.MySqlClient;

namespace RecorteDeCoração.Controller
{
    class ClienteController
    {
        private DbConnection dbconnection = new DbConnection();

        public void CreateCliente(Cliente cliente)
        {
            string errorQuery = null;

            try
            {
                this.dbconnection.Open();
            } catch (MySqlException error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MySqlParameter paramNome = new MySqlParameter("@Nome", cliente.Nome);
            MySqlParameter paramEmail = new MySqlParameter("@Email", cliente.Email);
            MySqlParameter paramTelefone = new MySqlParameter("@Telefone", cliente.Telefone);

            try
            {
                this.dbconnection.ExecuteNonQuery("INSERT INTO `Cliente` " +
                    "(`Nome`, `Email`, `Telefone`)" +
                    "VALUES (@Nome, @Email, @Telefone);",
                    paramNome, paramEmail, paramTelefone
                );
            } catch(MySqlException error)
            {
                errorQuery = error.Message;
            } finally
            {
                this.dbconnection.Close();
            }

            if (errorQuery != null)
            {
                MessageBox.Show(errorQuery, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateCliente(Cliente cliente)
        {
            string errorQuery = null;

            try
            {
                this.dbconnection.Open();
            }
            catch (MySqlException error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
            catch (MySqlException error) { errorQuery = error.Message; }
            finally                    { this.dbconnection.Close(); }

            if (errorQuery != null) { MessageBox.Show(errorQuery, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void DeleteCliente(Cliente cliente)
        {
            string errorQuery = null;

            try
            {
                this.dbconnection.Open();
            }
            catch (MySqlException error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MySqlParameter paramId = new MySqlParameter("@Id", cliente.Id);
            MySqlParameter paramNome = new MySqlParameter("@Nome", cliente.Nome);
            MySqlParameter paramEmail = new MySqlParameter("@Email", cliente.Email);
            MySqlParameter paramTelefone = new MySqlParameter("@Telefone", cliente.Telefone);

            try
            {
                this.dbconnection.ExecuteNonQuery("DELETE FROM `Cliente` " +
                    "WHERE (`Id` = @Id AND `Nome` = @Nome AND `Email` = @Email AND `Telefone` = @Telefone);",
                    paramId, paramNome, paramEmail, paramTelefone
                );
            }
            catch (MySqlException error) { errorQuery = error.Message; }
            finally { this.dbconnection.Close(); }

            if (errorQuery != null) { MessageBox.Show(errorQuery, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public List<Cliente> ListCliente()
        {
            List<Cliente> clientes = new List<Cliente>();
            string errorQuery = null;

            try {
                this.dbconnection.Open();
            } catch (SqlException error) {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return clientes;
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
            catch (MySqlException error) { errorQuery = error.Message; }
            finally                    { this.dbconnection.Close();  }

            if (errorQuery != null)    {  MessageBox.Show(errorQuery, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return clientes;
        }
    }
}
