using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace RecorteDeCoração.Model
{
    internal class Arquivo
    {
        #region Atributos

        /// <summary>
        ///     @params { id_file } serve para quando o arquivo for lido no banco de dados, para facilitar a manipulação do mesmo
        ///     dentro das referências a ponteiros e etc.
        ///     @params { name_file, type_file } informações necessarias para criação dos respectivos arquivos.
        ///     @params { length_file } serve para aprensetar em form o tamanho de cada um dos arquivos sem necessariamente puxa-los do banco de dados
        ///     @obs: puxar os arquivos de dados só pode ser feito mediante a escolha, para evitar de carregar inumeros arquivos 
        ///           e ficar com eles em memoria.
        /// </summary>
        private int id_File;
        private string name_File;
        private string type_File;
        private int length_File;
        private byte[] bytes;

        #endregion

        #region Contrutor

        public Arquivo()
        {

        }

        public Arquivo(int id_File_c) : this()
        {
            this.id_File = id_File_c;
        }

        public Arquivo(string name_file_c, string type_file_c, int length_File_c, byte[] bytes_c)
        {
            this.name_File = name_file_c;
            this.type_File = type_file_c;
            this.length_File = length_File_c;
            this.bytes = bytes_c;
        }

        #endregion

        #region propriedades

        public int Id_File
        {
            get { return id_File; }
            set { id_File = value; }
        }
        public string Name_File
        {
            get { return name_File; }
            set { name_File = value; }
        }
        public string Type_File
        {
            get { return type_File; }
            set { type_File = value; }
        }
        public int Length_File
        {
            get { return length_File; }
            set { length_File = value; }
        }
        public byte[] Bytes
        {
            get { return bytes; }
            set { bytes = value; }
        }

        #endregion

        #region Funcoes


        /// <summary>
        ///     faz a verificação do arquivo.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>vetor de string com 3 posições</returns>
        public string[] FileInfoArray(string path)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                string[] file_info = new string[3];
                file_info[0] = file.Name;
                file_info[1] = file.Extension;
                file_info[2] = file.Length.ToString();
                return file_info;
            }
            catch (Exception error)
            {
                MessageBox.Show("error ao verificar informações do arquivo" + error.ToString());
                return new string[3];
            }
        }
        /// <summary>
        ///     retorna binario da imagem.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public byte[] ByteImage(string path)
        {
            try
            {
                Bitmap bitm = null;
                if (path != "")
                {
                    bitm = new Bitmap(path);
                    MemoryStream MS = new MemoryStream();
                    bitm.Save(MS, ImageFormat.Bmp);
                    byte[] foto = MS.ToArray();
                    return foto;
                }
                else
                {
                    MessageBox.Show("Arquivo não Selecionado.");
                    return null;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Tipo de imagem não suportado.");
                return null;
            }
        }

        /// <summary>
        ///     retorna bitmap para apresentação de imagens e etc.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>bitmap caso </returns>
        public Bitmap GetBitMap(string path, int Width = 80, int Height = 80)
        {
            try
            {
                byte[] foto = this.ByteImage(path);
                MemoryStream MS = new MemoryStream(foto);
                Image img = Image.FromStream(MS);
                Bitmap bitm = new Bitmap(img, Width, Height);
                return bitm;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro no tratamento da Imagem para amostragem.");
                return null;
            }
        }

        #endregion
    }

}
