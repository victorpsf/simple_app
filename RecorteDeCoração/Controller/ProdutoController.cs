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

        //private DbConnection dbConnection = new DbConnection();
        //private ArquivoController arquivoController = new ArquivoController();

        //public ProdutoController() { }


        //public Produto CreateProduto(Produto produto)
        //{
        //    this.dbConnection.Open();

        //    long scalar = this.dbConnection.ExecuteScalar("INSERT INTO `Produto` " +
        //        "(`Nome`, `Valor Unitario`)" +
        //        "VALUES (@Nome, @ValorUnitario);",
        //        new MySqlParameter("@Nome", produto.Nome),
        //        new MySqlParameter("@ValorUnitario", produto.Valor_Unitario)
        //    );

        //    this.dbConnection.Close();

        //    return new Produto(Convert.ToInt32(scalar), produto.Nome, produto.Valor_Unitario);
        //}

        //public Produto UpdateProduto(Produto produto) {
        //    this.dbConnection.Open();

        //    this.dbConnection.ExecuteNonQuery(
        //        "UPDATE `Produto` SET " +
        //        "`Nome` = @Nome, `Valor Unitario` = @ValorUnitario " +
        //        "WHERE (`Id` = @Id);",
        //        new MySqlParameter("@Id", produto.Id),
        //        new MySqlParameter("@Nome", produto.Nome),
        //        new MySqlParameter("@ValorUnitario", produto.Valor_Unitario)
        //    );

        //    this.dbConnection.Close();

        //    return produto;
        //}

        //public Produto SetImage(Produto produto, Arquivo arquivo)
        //{
        //    this.dbConnection.Open();

        //    this.dbConnection.ExecuteNonQuery(
        //        "UPDATE `Produto` SET " +
        //        "`Imagem` = @Imagem " +
        //        "WHERE (`Id` = @Id);",
        //        new MySqlParameter("@Id", produto.Id),
        //        new MySqlParameter("@Imagem", arquivo.Id)
        //    );

        //    this.dbConnection.Close();

        //    produto.Imagem = arquivo;

        //    return produto;
        //}

        //public List<Produto> ListProduto()
        //{
        //    List<Produto> produtos = new List<Produto>();
        //    MySqlDataReader reader = null;

        //    this.dbConnection.Open();

        //    reader = this.dbConnection.ExecuteReader("SELECT * FROM `Produto`;");

        //    while(reader.Read()) {
        //        Arquivo imagem = null;
        //        if (DBNull.Value.Equals(reader["Imagem"]) == false) {
        //            long imagem_id = reader.GetInt64("Imagem");

        //            if (imagem_id > 0)
        //                imagem = this.arquivoController.GetArquivoUsingId(imagem_id);
        //        }

        //        produtos.Add(
        //            new Produto(
        //                reader.GetInt64("Id"),
        //                reader["Nome"].ToString(),
        //                reader.GetDecimal("Valor Unitario")
        //            )
        //        );
        //    }

        //    this.dbConnection.Close();


        //    return produtos;
        //}

        //public void DeleteProduto(Produto produto) {
        //    this.dbConnection.Open();

        //    this.dbConnection.ExecuteNonQuery(
        //        "DELETE FROM `Produto` WHERE (`Id` = @Id);",
        //        new MySqlParameter("@Id", produto.Id)
        //    );

        //    this.dbConnection.Close();
        //}

        #region refatorar
        //public Produto GetProduto(int id) {
        //    Exception err = null;
        //    MySqlDataReader reader = null;

        //    try {
        //        this.dbConnection.Open();
        //    } 

        //    catch (MySqlException error) {
        //        throw new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException);
        //    }

        //    try {
        //        reader = this.dbConnection.ExecuteReader(
        //            "SELECT * FROM `Produto` WHERE (`Id` = @Id)", 
        //            new MySqlParameter("@Id", id)
        //        );
        //    } 

        //    catch (MySqlException error) {
        //        err = new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException);
        //    }

        //    try {
        //        this.dbConnection.Close();
        //    }

        //    catch(MySqlException error) {
        //        throw new Exception(LogController.WriteExceptionAndGetMessage(error), error.InnerException);
        //    }

        //    if (err != null) throw err;

        //    while (reader.Read())
        //    {
        //        return new Produto(
        //            reader.GetInt32("Id"),
        //            reader["Nome"].ToString(),
        //            reader.GetDecimal("Valor Unitario"),
        //            this.arquivoController.GetArquivo(reader.GetInt32("Imagem"))
        //        );
        //    }

        //    return null;
        //}
        #endregion
    }
}
