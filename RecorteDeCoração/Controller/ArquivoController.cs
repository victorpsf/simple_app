using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

using RecorteDeCoração.Connection;
using RecorteDeCoração.Model;

namespace RecorteDeCoração.Controller
{
    class ArquivoController
    {
        private DbConnection dbConnection = new DbConnection();

        public ArquivoController() { }

        public int CreateArquivo(Arquivo arquivo)
        {
            long scalar = 0;
            MySqlException err = null;

            MySqlParameter paramNome = new MySqlParameter("@Nome", arquivo.Nome);
            MySqlParameter paramTipo = new MySqlParameter("@Extensao", arquivo.Extensao);
            MySqlParameter paramTamanho = new MySqlParameter("@Tamanho", arquivo.Tamanho);
            MySqlParameter paramBinario = new MySqlParameter("@Binario", MySqlDbType.Binary);
            paramBinario.Value = arquivo.Binario;

            try {
                this.dbConnection.Open();
            }

            catch(MySqlException error) {
                throw new Exception("Falha ao abrir conexão com banco de dados!\n\n" + error.Message, error.InnerException);
            }

            try {
                scalar = this.dbConnection.ExecuteScalar(
                    "INSERT INTO `Arquivo` (`Nome`, `Extensao`, `Tamanho`, `Binario`) VALUES (@Nome, @Extensao, @Tamanho, @Binario);", 
                    paramNome, paramTipo, paramTamanho, paramBinario
                );
            }

            catch (MySqlException error) { err = error; }

            this.dbConnection.Close();

            if (err != null) {
                throw new Exception("Error ao tentar salvar registro\n\n" + err.Message, err.InnerException);
            }

            return Convert.ToInt32(scalar);
        }

        public Arquivo GetArquivo(int id = 0) {
            if (id == 0) return null;
            Exception err = null;
            Arquivo arquivo = null;

            MySqlParameter paramId = new MySqlParameter("@Id", id);

            try {
                this.dbConnection.Open();
            }

            catch(MySqlException error) {
                throw new Exception("Falha ao abrir conexão com banco de dados!\n\n" + error.Message, error.InnerException);
            }

            try {
                MySqlDataReader reader = this.dbConnection.ExecuteReader(
                    "SELECT * FROM `Arquivo`;"
                );

                while(reader.Read()) {
                    arquivo = new Arquivo(
                        reader.GetInt32(reader.GetOrdinal("Id")),
                        reader.GetString(reader.GetOrdinal("Nome")),
                        reader.GetString(reader.GetOrdinal("Extensao")),
                        (long) reader["Tamanho"],
                        (byte[]) reader["Binario"] 
                    );
                }
            }

            catch (MySqlException error) { err = error; }

            this.dbConnection.Close();

            if (err != null) {
                throw new Exception("Error ao tentar salvar registro\n\n" + err.Message, err.InnerException);
            }

            return arquivo;
        }
    }
}
