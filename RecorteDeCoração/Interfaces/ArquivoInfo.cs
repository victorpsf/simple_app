using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using System;
using System.IO;

using RecorteDeCoração.Source;

namespace RecorteDeCoração.Interfaces
{
    internal class ArquivoInfo
    {
        #region Atributos
        private string name;
        private string extension;
        private long length;
        #endregion

        #region Contrutor

        public ArquivoInfo() {

        }

        public ArquivoInfo(string path): this()
        {
            try {
                FileInfo file = new FileInfo(path);

                this.name = file.Name;
                this.Extension = file.Extension;
                this.length = file.Length;
            }

            catch (Exception error) {
                LogController.WriteException(error);
            }
        }
        #endregion


        #region propriedades
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Extension
        {
            get { return this.extension; }
            set { this.extension = value; }
        }

        public long Length
        {
            get { return this.length; }
            set { this.length = value; }
        }
        #endregion

        #region Funcoes
        #endregion
    }

}
