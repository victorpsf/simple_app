using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

using RecorteDeCoração.Connection;
using RecorteDeCoração.Model;
using RecorteDeCoração.Source;

namespace RecorteDeCoração.Controller
{
    class ArquivoController
    {
        public static Arquivo Create(Arquivo arquivo)
        {
            DbConnection connection = new DbConnection();

            MySqlParameter paramBinario = new MySqlParameter("@Binario", MySqlDbType.Binary);
            paramBinario.Value = arquivo.Binario;

            connection.Open();
            long id = connection.ExecuteScalar(
                "INSERT INTO `Arquivo` (`Nome`, `Extensao`, `Tamanho`, `Binario`) VALUES (@Nome, @Extensao, @Tamanho, @Binario);",
                new MySqlParameter("@Nome", arquivo.Nome),
                new MySqlParameter("@Extensao", arquivo.Extensao),
                new MySqlParameter("@Tamanho", arquivo.Tamanho),
                paramBinario
            );

            connection.Close();
            return new Arquivo(id, arquivo.Nome, arquivo.Extensao, arquivo.Tamanho, arquivo.Binario);
        }

        public static void Delete(Arquivo arquivo) {
            DbConnection connection = new DbConnection();

            connection.Open();
            connection.ExecuteNonQuery(
                "DELETE FROM `Arquivo` WHERE (`Id` = @Id);",
                new MySqlParameter("@Id", arquivo.Id)
            );
            connection.Close();
        }

        public static Arquivo Find(long id)
        {
            Arquivo arquivo = null;
            DbConnection connection = new DbConnection();

            connection.Open();
            MySqlDataReader reader = connection.ExecuteReader(
                "SELECT * FROM `Arquivo` WHERE (`Id` = @Id);",
                new MySqlParameter("@Id", id)
            );

            if (reader.Read()) {
                arquivo = new Arquivo(
                    reader.GetInt64("Id"),
                    reader["Nome"].ToString(),
                    reader["Extensao"].ToString(),
                    reader.GetInt64("Tamanho"),
                    (byte[]) reader["Binario"]
                );
            }
            connection.Close();

            return arquivo;
        }
        //private DbConnection dbConnection = new DbConnection();

        //public ArquivoController() { }

        //public Arquivo GetArquivoUsingId(long id) {
        //    Arquivo arquivo = null;
        //    this.dbConnection.Open();

        //    MySqlDataReader reader = this.dbConnection.ExecuteReader(
        //        "SELECT * FROM `Arquivo` WHERE (`Id` = @Id);",
        //        new MySqlParameter("@Id", id)
        //    );

        //    if (reader.Read()) 
        //        arquivo = new Arquivo(
        //            reader.GetInt64(reader.GetOrdinal("Id")),
        //            reader.GetString(reader.GetOrdinal("Nome")),
        //            reader.GetString(reader.GetOrdinal("Extensao")),
        //            (long)reader["Tamanho"],
        //            (byte[])reader["Binario"]
        //        );

        //    this.dbConnection.Close();

        //    return arquivo;
        //}
        //public Arquivo CreateArquivo(Arquivo arquivo)
        //{
        //    MySqlParameter paramBinario = new MySqlParameter("@Binario", MySqlDbType.Binary);
        //    paramBinario.Value = arquivo.Binario;

        //    this.dbConnection.Open();

        //    long scalar = this.dbConnection.ExecuteScalar(
        //        "INSERT INTO `Arquivo` (`Nome`, `Extensao`, `Tamanho`, `Binario`) VALUES (@Nome, @Extensao, @Tamanho, @Binario);",
        //        new MySqlParameter("@Nome", arquivo.Nome),
        //        new MySqlParameter("@Extensao", arquivo.Extensao),
        //        new MySqlParameter("@Tamanho", arquivo.Tamanho),
        //        paramBinario
        //    );

        //    this.dbConnection.Close();

        //    return new Arquivo(
        //        Convert.ToInt32(scalar), 
        //        arquivo.Nome, 
        //        arquivo.Extensao, 
        //        arquivo.Tamanho, 
        //        arquivo.Binario
        //    );
        //}

        //public Arquivo GetArquivo(dynamic id) {
        //    int QueryId;

        //    try
        //    {
        //        QueryId = Convert.ToInt32(id);
        //    } catch (Exception error) {
        //        LogController.WriteExceptionAndGetMessage(error);
        //        return null;
        //    }

        //    Exception err = null;
        //    Arquivo arquivo = null;

        //    MySqlParameter paramId = new MySqlParameter("@Id", QueryId);

        //    try {
        //        this.dbConnection.Open();
        //    }

        //    catch(MySqlException error) {
        //        throw new Exception("Falha ao abrir conexão com banco de dados!\n\n" + error.Message, error.InnerException);
        //    }

        //    try {
        //        MySqlDataReader reader = this.dbConnection.ExecuteReader(
        //            "SELECT * FROM `Arquivo` WHERE (`Id` = @Id);", paramId
        //        );

        //        while(reader.Read()) {
        //            arquivo = new Arquivo(
        //                reader.GetInt32(reader.GetOrdinal("Id")),
        //                reader.GetString(reader.GetOrdinal("Nome")),
        //                reader.GetString(reader.GetOrdinal("Extensao")),
        //                (long) reader["Tamanho"],
        //                (byte[]) reader["Binario"] 
        //            );
        //        }
        //    }

        //    catch (MySqlException error) { err = error; }

        //    this.dbConnection.Close();

        //    if (err != null) {
        //        throw new Exception("Error ao tentar salvar registro\n\n" + err.Message, err.InnerException);
        //    }

        //    return arquivo;
        //}

        //public void DeleteArquivo(Arquivo arquivo)
        //{
        //    this.dbConnection.Open();

        //    this.dbConnection.ExecuteNonQuery("DELETE FROM `Arquivo` " +
        //        "WHERE (`Id` = @Id AND `Nome` = @Nome AND `Extensao` = @Extensao AND `Tamanho` = @Tamanho);",
        //        new MySqlParameter("@Id", arquivo.Id),
        //        new MySqlParameter("@Nome", arquivo.Nome),
        //        new MySqlParameter("@Extensao", arquivo.Extensao),
        //        new MySqlParameter("@Tamanho", arquivo.Tamanho)
        //    );

        //    this.dbConnection.Close();
        //}
    }
}
