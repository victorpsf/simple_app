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

        public static List<Arquivo> Get() {
            List<Arquivo> arquivos = new List<Arquivo>();
            DbConnection connection = new DbConnection();

            connection.Open();
            MySqlDataReader reader = connection.ExecuteReader("SELECT `Id`, `Nome`, `Tamanho`, `Criado Em` FROM `Arquivo`;");

            while(reader.Read()) {
                arquivos.Add(
                    new Arquivo(
                        reader.GetInt64("Id"),
                        reader["Nome"].ToString(),
                        reader.GetInt64("Tamanho"),
                        reader.GetDateTime("Criado Em")
                    )
                );
            }

            connection.Close();

            return arquivos;
        }
    }
}
