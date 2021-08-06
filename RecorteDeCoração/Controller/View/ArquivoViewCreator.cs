using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
using RecorteDeCoração.Model;
using RecorteDeCoração.Source;
using RecorteDeCoração.Forms;


namespace RecorteDeCoração.Controller.View
{
    class ArquivoViewCreator
    {

        private PictureBox GetPicture(string image, ArquivoForm arquivoForm, Arquivo arquivo) {
            PictureBox pictureBox = new PictureBox();

            pictureBox.Anchor = AnchorStyles.None;
            pictureBox.BackgroundImage = (image == "download") ? 
                global::RecorteDeCoração.Properties.Resources.file_download : 
                global::RecorteDeCoração.Properties.Resources.file_rem;
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox.Cursor = Cursors.Hand;
            pictureBox.Location = new Point(12, 35);
            pictureBox.Margin = new Padding(0);
            pictureBox.Size = new Size(25, 25);
            pictureBox.TabStop = false;
            pictureBox.Click += new EventHandler((Object sender, EventArgs e) => arquivoForm.Listen(sender, e, image, arquivo));

            return pictureBox;
        }

        private TableLayoutPanel CreateEventTable(ArquivoForm arquivoForm, Arquivo arquivo)
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            
            tableLayoutPanel.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Location = new Point(500, 0);
            tableLayoutPanel.Margin = new Padding(0);
            tableLayoutPanel.RowCount = 5;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel.Size = new Size(50, 160);

            tableLayoutPanel.Controls.Add(this.GetPicture("download", arquivoForm, arquivo), 0, 1);
            tableLayoutPanel.Controls.Add(this.GetPicture("remove", arquivoForm, arquivo), 0, 3);

            return tableLayoutPanel;
        }

        private Label CreateLabel(string Text, string direction) {
            Label label = new Label();

            label.Anchor = (direction == "esquerda") ? AnchorStyles.Left: AnchorStyles.Right;
            label.AutoSize = true;
            label.Font = new Font("Segoe Script", 14.25F, ((FontStyle)((FontStyle.Bold | FontStyle.Italic))), GraphicsUnit.Point, ((byte)(0)));
            label.ForeColor = Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(191)))), ((int)(((byte)(166)))));
            label.Location = new Point(70, 26);
            label.Size = new Size(77, 26);
            label.Text = Text;

            return label;
        }

        private Label GetLabel(Arquivo arquivo, int index)
        {
            string text = "";

            switch (index)
            {
                case 0:
                    text = arquivo.Id.ToString();
                    break;
                case 1:
                    text = arquivo.Nome;
                    break;
                case 2:
                    text = arquivo.Tamanho.ToString();
                    break;
                case 3:
                    text = arquivo.CriadoEm.ToString();
                    break;
            }

            return this.CreateLabel(text, "esquerda");
        }

        private TableLayoutPanel CreateViewTable(Arquivo arquivo) {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            
            tableLayoutPanel.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Margin = new Padding(0);
            tableLayoutPanel.RowCount = 6;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel.Size = new Size(500, 160);

            string[] labels = new string[4] { "Id", "Nome", "Tamanho", "Criado Em"};

            for(int x = 0; x < labels.Length; x++) {
                tableLayoutPanel.Controls.Add(this.CreateLabel(labels[x], "direita"), 0, x + 1);
            }

            for(int x = 0; x < labels.Length; x++) {
                tableLayoutPanel.Controls.Add(this.GetLabel(arquivo, x), 1, x + 1);
            }

            return tableLayoutPanel;
        }

        public TableLayoutPanel CreateTable(Arquivo arquivo, ArquivoForm arquivoForm) {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();

            tableLayoutPanel.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
            tableLayoutPanel.BackColor = Color.White;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.Location = new Point(5, 5);
            tableLayoutPanel.Margin = new Padding(5);
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(550, 160);

            tableLayoutPanel.Controls.Add(this.CreateViewTable(arquivo), 0, 0);
            tableLayoutPanel.Controls.Add(this.CreateEventTable(arquivoForm, arquivo), 1, 0);

            return tableLayoutPanel;
        }
    }
}
