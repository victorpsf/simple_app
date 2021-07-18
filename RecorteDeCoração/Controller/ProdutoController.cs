using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using MySql.Data.MySqlClient;
using RecorteDeCoração.Model;
using RecorteDeCoração.Connection;

using RecorteDeCoração.Source;

namespace RecorteDeCoração.Controller
{
    class ProdutoController
    {
        private DbConnection dbConnection = new DbConnection();
        private ArquivoController arquivoController = new ArquivoController();

        public ProdutoController() { }

        public void CreateProduto(Produto produto)
        {
            Exception err = null;

            MySqlParameter paramNome = new MySqlParameter("@Nome", produto.Nome);
            MySqlParameter paramValor = new MySqlParameter("@ValorUnitario", produto.Valor_Unitario);
            MySqlParameter paramImagem = null;

            if (produto.Imagem != null) {
                int arquivoId = this.arquivoController.CreateArquivo(produto.Imagem);

                paramImagem = new MySqlParameter("@Imagem", arquivoId);
            }

            try {
                this.dbConnection.Open();
            }
            
            catch(MySqlException error) {
                throw new Exception("Falha ao abrir conexão com banco de dados!\n\n" + error.Message, error.InnerException);
            }

            try {
                this.dbConnection.ExecuteNonQuery("INSERT INTO `Produto` " +
                    "(`Nome`, `Valor Unitario`, `Imagem`)" + 
                    "VALUES (@Nome, @ValorUnitario, @Imagem);",
                    paramNome, paramValor, paramImagem
                );
            }

            catch (MySqlException error) { err = error; }

            this.dbConnection.Close();

            if (err != null) {
                throw new Exception("Error ao tentar salvar registro\n\n" + err.Message, err.InnerException);
            }
        }

        public void UpdateProduto(Produto produto) {
            Exception err = null;

            try {
                this.dbConnection.Open();
            }
            
            catch(MySqlException error) {
                throw new Exception("Falha ao abrir conexão com banco de dados!\n\n" + error.Message, error.InnerException);
            }

            if (produto.Imagem != null) {
            }

            MySqlParameter paramId = new MySqlParameter("@Id", produto.Id);
            MySqlParameter paramNome = new MySqlParameter("@Nome", produto.Nome);
            MySqlParameter paramValor = new MySqlParameter("@ValorUnitario", produto.Valor_Unitario);

            try {
                this.dbConnection.ExecuteNonQuery("UPDATE `Produto` SET " +
                    "`Nome` = @Nome, `Valor Unitario` = @ValorUnitario " + 
                    "WHERE (`Id` = @Id);",
                    paramId, paramNome, paramValor
                );
            }

            catch (MySqlException error) { err = error; } 

            this.dbConnection.Close();

            if (err != null) {
                throw new Exception("Error ao tentar salvar registro\n\n" + err.Message, err.InnerException);
            }
        }

        public List<Produto> ListProduto()
        {
            List<Produto> produtos = new List<Produto>();
            Exception err = null;

            try {
                this.dbConnection.Open();
            } 

            catch (MySqlException error) {
                throw new Exception("Falha ao abrir conexão com banco de dados!\n\n" + error.Message, error.InnerException);
            }

            try {
                MySqlDataReader reader = this.dbConnection.ExecuteReader("SELECT * FROM `Produto`;");

                while(reader.Read()) {
                    produtos.Add(
                        new Produto(
                            reader.GetInt32(reader.GetOrdinal("Id")),
                            reader.GetString(reader.GetOrdinal("Nome")),
                            reader.GetDecimal(reader.GetOrdinal("Valor Unitario")),
                            this.arquivoController.GetArquivo(reader.GetInt32(reader.GetOrdinal("Imagem")))
                        )
                    );
                }
            } 

            catch (MySqlException error) { err = error; }

            this.dbConnection.Close();

            if (err != null) {
                throw new Exception("Não foi possível obter registros\n\n" + err.Message, err.InnerException);
            }

            return produtos;
        }
    }
}
