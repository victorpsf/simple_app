using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;
using DbMySqlConnection.Builder;

namespace RecorteDeCoracao
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string query = DbMySqlSelectBuilder.Instance("MyManager.Login")
                                .Select("e-mail", "LoginEmail")
                                .Select("passphrase", "LoginSenha")
                                .Where(new IDbMySqlSelectWhere { column = "Login.Id", projection = "@LoginId", comparison = "=", value = 1 })
                                .BuildQuery();

            Console.WriteLine(query);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
