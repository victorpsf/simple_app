using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using RecorteDeCoração.Source;

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

            try {
                Application.Run(new Main());
            } 
            
            catch(Exception error) {
                LogController.WriteException(error);
                MessageBox.Show("Error: ocorreu um erro não mapeado, contate o desenvolvedor para verificar o que foi ocorrido.", "Erro não mapeado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
