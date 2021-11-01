using System;
using System.Windows.Forms;
using System.Drawing;
using RecorteDeCoração.ModelDto;

namespace RecorteDeCoração.Forms.Creator
{
    public delegate void EventClickCustom (object sender, EventArgs e, string label, PersonDto cliente);

    public class ClientViewFormCreator
    {
        public TableLayoutPanel MainPanel;
        public TableLayoutPanel ContentPanel;
        public TableLayoutPanel OptionsPanel;
        public PersonDto cliente;

        public EventClickCustom FirstButtonCallback;
        public EventClickCustom SeccondButtonCallback;

        public ClientViewFormCreator (EventClickCustom firstButton, EventClickCustom seccondButton, PersonDto cliente) {
            this.FirstButtonCallback = firstButton;
            this.SeccondButtonCallback = seccondButton;

            this.cliente = cliente;
        }

        public PictureBox CreatePicture (string picture, EventClickCustom Handler)
        {
            PictureBox pictureBox = new PictureBox();

            pictureBox.Anchor = AnchorStyles.None;
            pictureBox.BackgroundImage = (picture == "delete") ?
                global::RecorteDeCoração.Properties.Resources.trashd_rec :
                global::RecorteDeCoração.Properties.Resources.created_r;

            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox.Cursor = Cursors.Hand;
            pictureBox.TabStop = false;

            pictureBox.Location = new Point(17, 177);
            pictureBox.Margin = new Padding(0);
            pictureBox.Size = new Size(40, 40);
            pictureBox.TabIndex = 1;

            pictureBox.Click += new EventHandler((object sender, EventArgs e) => Handler(sender, e, picture, this.cliente));

            return pictureBox;
        }

        public TableLayoutPanel CreateActionPanel ()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));

            tableLayoutPanel.BackColor = Color.White;
            tableLayoutPanel.Controls.Add(this.CreatePicture("delete", this.SeccondButtonCallback), 0, 1);
            tableLayoutPanel.Controls.Add(this.CreatePicture("edit", this.FirstButtonCallback), 0, 0);

            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.Location = new Point(723, 3);
            tableLayoutPanel.Size = new Size(74, 263);

            return tableLayoutPanel;
        }

        public TableLayoutPanel CreateContentPanel ()
        {
            string[] Labels = new string[] { "Id", "Nome", "Cpf", "Rg", "Email", "Telefone", "Cep", "Rua" };
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();

            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            for (int x = 0; x < Labels.Length; x++) {
                tableLayoutPanel.Controls.Add(this.CreateLabel(Labels[x], "none"), 0, x);
            }

            tableLayoutPanel.Controls.Add(this.CreateLabel(this.cliente.PersonId.ToString(), "left"), 1, 0);
            tableLayoutPanel.Controls.Add(this.CreateLabel(this.cliente.Name, "left"), 1, 1);
            tableLayoutPanel.Controls.Add(this.CreateLabel(this.cliente.Cpf.ToString(), "left"), 1, 2);
            tableLayoutPanel.Controls.Add(this.CreateLabel(this.cliente.Rg.ToString(), "left"), 1, 3);
            tableLayoutPanel.Controls.Add(this.CreateLabel(this.cliente.Email, "left"), 1, 4);
            tableLayoutPanel.Controls.Add(this.CreateLabel(this.cliente.Phone.ToString(), "left"), 1, 5);
            tableLayoutPanel.Controls.Add(this.CreateLabel(this.cliente.Cep.ToString(), "left"), 1, 6);
            tableLayoutPanel.Controls.Add(this.CreateLabel(this.cliente.Street, "left"), 1, 7);

            tableLayoutPanel.BackColor = Color.White;
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Margin = new Padding(0);

            tableLayoutPanel.Font = new Font("Segoe Script", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.RowCount = 8;
            tableLayoutPanel.Size = new Size(720, 269);

            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));

            return tableLayoutPanel;
        }

        public AnchorStyles GetDirection (string direction)
        {
            switch (direction)
            {
                case "left":
                    return AnchorStyles.Left;
                case "right":
                    return AnchorStyles.Right;
                case "top":
                    return AnchorStyles.Top;
                case "bottom":
                    return AnchorStyles.Bottom;
                case "none":
                default:
                    return AnchorStyles.None;
            }
        }

        public Label CreateLabel(string label, string direction)
        {
            Label LabelClass = new Label();

            LabelClass.Anchor = this.GetDirection(direction);
            LabelClass.AutoSize = true;
            LabelClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(191)))), ((int)(((byte)(166)))));
            LabelClass.Location = new System.Drawing.Point(52, 103);
            LabelClass.Size = new System.Drawing.Size(35, 25);
            LabelClass.Text = label;

            return LabelClass;
        }

        public TableLayoutPanel Generate()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();

            tableLayoutPanel.Dock = DockStyle.Top;

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Padding = new Padding(2);

            tableLayoutPanel.Controls.Add(this.CreateContentPanel(), 0, 0);
            tableLayoutPanel.Controls.Add(this.CreateActionPanel(), 1, 0);

            tableLayoutPanel.Location = new Point(0, 84);
            tableLayoutPanel.Size = new Size(800, 269);

            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.TabIndex = 2;

            return tableLayoutPanel;
        }
    }
}
