using Newtonsoft.Json;
using RecorteDeCoração.Source;
using System.Windows.Forms;
using System.Diagnostics;

namespace RecorteDeCoração.Connection
{
    public class DbConfiguration
    {
        public string host = "127.0.0.1";
        public string port = "3306";
        public bool enable_port = false;
        public string user = "root";
        public string passphrase = "";
        public string database = "";

        public static DbConfiguration Init()
        {
            string path = FileController.AppendPath(FileController.AppDataDirectory(), "database_configuration.json");

            if (FileController.NotExists(path))
            {
                FileController.Write(path, JsonConvert.SerializeObject(new DbConfiguration()));
                MessageBox.Show("Configure o arquivo de conexão com o banco de dados", "informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(FileController.AppDataDirectory());
                throw new System.Exception("File configuration database is not defined");
            }

            return JsonConvert.DeserializeObject<DbConfiguration>(FileController.Read(path));
        }

        public string ConnectionString()
        {
            string connectionString = "";

            connectionString += "server=" + this.host;
            if (this.enable_port) {
                connectionString += this.port;
            }

            else {
                connectionString += ';';
            }

            connectionString += "user id=" + this.user + ";";
            connectionString += "password=" + this.passphrase + ";";
            connectionString += "database=" + this.database + ";";

            return connectionString;
        }
    }
}
