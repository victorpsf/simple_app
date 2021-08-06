using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RecorteDeCoração.Model;
using RecorteDeCoração.Controller;
using RecorteDeCoração.Controller.View;
using System.IO;

namespace RecorteDeCoração.Forms
{
    public partial class ArquivoForm : Form
    {
        public ArquivoForm()
        {
            InitializeComponent();
            //this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.LoadLayout();
        }

        private void LoadLayout()
        {
            this.flowLayoutPanel1.Controls.Clear();
            List<Arquivo> arquivos = ArquivoController.Get();
            ArquivoViewCreator arquivoViewCreator = new ArquivoViewCreator();

            foreach (Arquivo arquivo in arquivos) {
                this.flowLayoutPanel1.Controls.Add(arquivoViewCreator.CreateTable(arquivo, this));
            }
        }

        public void Listen(Object sender, EventArgs e, string type, dynamic arquivo)
        {
            DialogResult result;
            switch (type)
            {
                case "download":
                    SaveFileDialog saveFile = new SaveFileDialog();

                    saveFile.FileName = arquivo.Nome;
                    saveFile.Title = "Salvar em";
                    result = saveFile.ShowDialog();

                    if (result == DialogResult.OK) {
                        Arquivo _arquivo_ = ArquivoController.Find(arquivo.Id);
                        File.WriteAllBytes(saveFile.FileName, _arquivo_.Binario);
                    }
                    break;
                case "remove":
                    result = MessageBox.Show("deseja realmente remover o arquivo" + arquivo.Nome + " ?", "deseja remover ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        ArquivoController.Delete(arquivo);
                        this.LoadLayout();
                    }
                    break;
            }
        }
    }
}
