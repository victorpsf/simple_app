using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using MySql.Data.MySqlClient;
using RecorteDeCoração.Model;
using RecorteDeCoração.connection;

using RecorteDeCoração.src;

namespace RecorteDeCoração.Controller
{
    class ProdutoController
    {
        private DbConnection dbConnection = new DbConnection();

        public ProdutoController() { }

        public void CreateProduto(Produto produto)
        {
            string errorQuery = null; 
            //int arquivoId;

            try {
                this.dbConnection.Open();
            }
            
            catch(MySqlException error) {
                LogController.WriteException(error);
                MessageBox.Show("Falha ao abrir conexão com banco de dados!\n\n" + error.Message,
                    "Falha ao iniciar conexão",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            if (produto.Imagem != null) {
            }

            MySqlParameter paramNome = new MySqlParameter("@Nome", produto.Nome);
            MySqlParameter paramValor = new MySqlParameter("@ValorUnitario", produto.Valor_Unitario);

            try {
                this.dbConnection.ExecuteNonQuery("INSERT INTO `Produto` " +
                    "(`Nome`, `Valor Unitario`)" + 
                    "VALUES (@Nome, @ValorUnitario);",
                    paramNome, paramValor
                );
            }

            catch (MySqlException error) {
                LogController.WriteException(error);
                errorQuery = error.Message;
            } 

            finally {
                this.dbConnection.Close();
            }

            if (errorQuery != null) {
                MessageBox.Show("Error ao tentar salvar registro\n\n" + errorQuery, "Erro ao salvar registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Produto> ListProduto()
        {
            List<Produto> produtos = new List<Produto>();
            string errorQuery = null;

            try {
                this.dbConnection.Open();
            } 

            catch (MySqlException error) {
                LogController.WriteException(error);
                MessageBox.Show("Falha ao abrir conexão com banco de dados!\n\n" + error.Message,
                    "Falha ao iniciar conexão",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }

            try {
                MySqlDataReader reader = this.dbConnection.ExecuteReader("SELECT * FROM `Produto`;");

                while(reader.Read()) {
                    produtos.Add(
                        new Produto(
                            reader.GetInt32(reader.GetOrdinal("Id")),
                            reader.GetString(reader.GetOrdinal("Nome")),
                            reader.GetDecimal(reader.GetOrdinal("Valor Unitario"))
                        )
                    );
                }
            } 

            catch (MySqlException error) {
                LogController.WriteException(error);
                errorQuery = error.Message;
            }

            finally {
                this.dbConnection.Close();
            }

            if (errorQuery != null) {
                MessageBox.Show("Não foi possível obter registros\n\n" + errorQuery, "Erro ao obter registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return produtos;
        }
    }
}
