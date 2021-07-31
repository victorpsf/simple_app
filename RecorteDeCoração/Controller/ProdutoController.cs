using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using MySql.Data.MySqlClient;
using RecorteDeCoração.Model;
using RecorteDeCoração.Connection;

using System.Text.RegularExpressions;
using RecorteDeCoração.Source;

namespace RecorteDeCoração.Controller
{
    class ProdutoController
    {
        public static Produto Create(Produto produto)
        {
            DbConnection connection = new DbConnection();

            connection.Open();

            long id = connection.ExecuteScalar(
                "INSERT INTO `Produto` (`Nome`, `Valor Unitario`) VALUES (@Nome, @ValorUnitario);",
                new MySqlParameter("@Nome", produto.Nome),
                new MySqlParameter("@ValorUnitario", produto.Valor_Unitario)
            );

            connection.Close();

            return new Produto(id, produto.Nome, produto.Valor_Unitario);
        }

        public static Produto Update(Produto produto)
        {
            DbConnection connection = new DbConnection();

            connection.Open();

            connection.ExecuteNonQuery(
                "UPDATE `Produto` SET `Nome` = @Nome, `Valor Unitario` = @ValorUnitario WHERE (`Id` = @Id)",
                new MySqlParameter("@Id", produto.Id),
                new MySqlParameter("@Nome", produto.Nome),
                new MySqlParameter("@ValorUnitario", produto.Valor_Unitario)
            );

            connection.Close();

            return produto;
        }

        public static void Delete(Produto produto) {
            DbConnection connection = new DbConnection();

            connection.Open();

            connection.ExecuteNonQuery(
                "DELETE FROM `Produto` WHERE (`Id` = @Id);",
                new MySqlParameter("@Id", produto.Id)
            );

            connection.Close();
        }

        public static Produto SetImagem(Produto produto, Arquivo arquivo)
        {
            DbConnection connection = new DbConnection();

            connection.Open();

            connection.ExecuteNonQuery(
                "UPDATE `Produto` SET `Imagem` = @IdImagem WHERE (`Id` = @Id)",
                new MySqlParameter("@IdImagem", arquivo.Id),
                new MySqlParameter("@Id", produto.Id)
            );

            connection.Close();

            produto.Imagem = arquivo;
            return produto;
        }

        public static List<Produto> Get()
        {
            List<Produto> produtos = new List<Produto>();
            DbConnection connection = new DbConnection();

            connection.Open();

            MySqlDataReader reader = connection.ExecuteReader("SELECT * FROM `Produto`;");

            while(reader.Read()) {
                Arquivo arquivo = null;

                if (DBNull.Value.Equals(reader["Imagem"]) == false)
                {
                    arquivo = ArquivoController.Find(reader.GetInt64("Imagem"));
                }

                produtos.Add(
                    new Produto(
                        reader.GetInt64("Id"),
                        reader["Nome"].ToString(),
                        reader.GetDecimal("Valor Unitario"),
                        arquivo
                    )
                );
            }

            connection.Close();

            return produtos;
        }

        public static List<Produto> Filter(List<Produto> produtos, string field, string value)
        {
            List<Produto> FilterProdutos = new List<Produto>();

            foreach (Produto produto in produtos)
            {
                if (field == "Id")
                {
                    if (produto.Id == Convert.ToInt64(value))
                        FilterProdutos.Add(produto);
                    continue;
                }

                string current_value = "";
                if (field == "Nome") current_value = produto.Nome;

                if (Regex.Match(current_value.ToLower(), @"" + value.ToLower() + "").Success)
                    FilterProdutos.Add(produto);

                continue;
            }

            if (FilterProdutos.Count == 0) return produtos;
            else return FilterProdutos;
        }

        public static void ValidateFilterEvent(object sender, KeyPressEventArgs e, string field)
        {
            switch (field)
            {
                case "Id":
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                        MessageBox.Show("este campo aceita somente numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Nome": break;
            }
        }
    }
}
