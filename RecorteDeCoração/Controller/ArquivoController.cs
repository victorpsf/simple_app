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

        public Arquivo CreateArquivo(Arquivo arquivo)
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

            return new Arquivo(Convert.ToInt32(scalar), arquivo.Nome, arquivo.Extensao, arquivo.Tamanho, arquivo.Binario);
        }

        public Arquivo GetArquivo(object id) {
            int QueryId;

            try
            {
                QueryId = Convert.ToInt32(id);
            } catch (Exception error) {
                return null;
            }

            Exception err = null;
            Arquivo arquivo = null;

            MySqlParameter paramId = new MySqlParameter("@Id", QueryId);

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

        public void DeleteArquivo(Arquivo arquivo)
        {
            Exception err = null;

            try
            {
                this.dbConnection.Open();
            }

            catch (MySqlException error)
            {
                throw new Exception("Falha ao abrir conexão com banco de dados!\n\n" + error.Message, error.InnerException);
            }

            MySqlParameter paramId = new MySqlParameter("@Id", arquivo.Id);
            MySqlParameter paramNome = new MySqlParameter("@Nome", arquivo.Nome);
            MySqlParameter paramExtensao = new MySqlParameter("@Extensao", arquivo.Extensao);
            MySqlParameter paramTamanho = new MySqlParameter("@Tamanho", arquivo.Tamanho);

            try
            {
                this.dbConnection.ExecuteNonQuery("DELETE FROM `Arquivo` " +
                    "WHERE (`Id` = @Id AND `Nome` = @Nome AND `Extensao` = @Extensao AND `Tamanho` = @Tamanho);",
                    paramId, paramNome, paramExtensao, paramTamanho
                );
            }
            catch (MySqlException error) { err = error; }

            this.dbConnection.Close();

            if (err != null)
            {
                throw new Exception("Error ao tentar excluir registro\n\n" + err.Message, err.InnerException);
            }
        }
    }
}
