using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using MySql.Data.MySqlClient;
using RecorteDeCoração.Model;
using RecorteDeCoração.connection;

namespace RecorteDeCoração.Controller
{
    class ProdutoController
    {
        private DbConnection dbConnection = new DbConnection();

        public ProdutoController() { }

        public void CreateProduto(Produto produto)
        {
            string errorQuery = null; 
            int arquivoId;

            try
            {
                this.dbConnection.Open();
            } catch(MySqlException error)
            {
                MessageBox.Show("Falha ao abrir conexão com banco de dados!\n\n" + error.Message,
                    "Falha ao iniciar conexão",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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
            } catch (MySqlException error) {
                errorQuery = error.Message;
            } finally {
                this.dbConnection.Close();
            }

            if (errorQuery != null) {
                MessageBox.Show("Error ao tentar salvar registro\n\n" + errorQuery, "Erro ao salvar registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
