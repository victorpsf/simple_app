using Newtonsoft.Json;
using RecorteDeCoração.Source;

namespace RecorteDeCoração.Connection
{
    class Configuration
    {
        public string host = "127.0.0.1";
        public int port = 3306;
        public bool enable_port = false;
        public string user = "root";
        public string passphrase = "";
        public string database = "";

        public static Configuration ReadFile()
        {
            string configFile = "./configuration.json";
            Configuration instance;

            if (FileController.NotExists(configFile)) {
                instance = new Configuration();
                FileController.Write(configFile, JsonConvert.SerializeObject(instance));
            }

            else {
                instance = JsonConvert.DeserializeObject<Configuration>(FileController.Read(configFile));
            }

            return instance;
        }

        public string ConnectionString()
        {
            string connectionString = "";

            connectionString += "server=" + this.host;
            if (this.enable_port) {
                connectionString += this.port.ToString();
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
