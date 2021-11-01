using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using RecorteDeCoração.Connection;
using RecorteDeCoração.Source;
using RecorteDeCoração.Forms;

namespace RecorteDeCoração
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Program.ValidateLogPath()) return;
            if (Program.LoadDbConfig()) return;

            Program.Init();
        }

        static void Init() {
            try { 
                Application.Run(new MainMenuForm());
            }

            catch (Exception error) {
                LogController.ErrorMessage("Erro não mapeado", "Error: ocorreu um erro não mapeado, contate o desenvolvedor para verificar o que foi ocorrido.");

                try {
                    LogController.WriteException(error);
                }

                catch (Exception error_save) {
                    LogController.ErrorMessage("Erro", "Error: não foi possível salvar o registro do erro");
                }
            }
        }

        static bool LoadDbConfig() {
            try {
                DbConfiguration.Init();
                return false;
            }

            catch (Exception error) {
                LogController.WriteException(error);
                LogController.ErrorMessage("Erro", "Error: não foi possível verificar arquivo de configuração da base de dados");
                return true;
            }
        }

        static bool ValidateLogPath() {
            try {
                LogController.Init();
                return false;
            }

            catch (Exception error) {
                LogController.ErrorMessage("Erro", "Error: não foi possível verificar pasta de log");
                return true;
            }
        }
    }
}
