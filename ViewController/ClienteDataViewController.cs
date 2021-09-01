using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using DbModel;
using RecorteDeCoracao.View;
using RecorteDeCoracao.Delegates;

namespace RecorteDeCoracao.ViewController
{
    class ClienteDataViewController
    {
        private ClienteModel model;
        private ClienteDataView form;
        private TableLayoutPanel mainTableLayoutPanel;
        private TableLayoutPanel actionTableLayoutPanel;
        private TableLayoutPanel viewTableLayoutPanel;

        public ClienteDataViewController(object clienteModel, object form)
        {
            this.model = clienteModel as ClienteModel;
            this.form = form as ClienteDataView;
        }

        private Label CreateLabel(string Text)
        {
            Label label = new Label();

            label.Anchor = AnchorStyles.Right;
            label.AutoSize = true;
            label.Location = new Point(101, 9);
            label.Size = new Size(16, 13);
            label.Text = Text;

            return label;
        }

        private Button CreateButton(Image image, string type, ViewClickEventHandler handler)
        {
            Button button = new Button();

            button.Anchor = AnchorStyles.None;
            button.BackgroundImage = image;
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Location = new Point(7, 47);
            button.Size = new Size(25, 25);
            button.UseVisualStyleBackColor = true;
            button.Click += new EventHandler((object sender, EventArgs e) => handler(type, sender, e, this.model, this));

            return button;
        }

        private void SetViewTableLayoutPanel()
        {
            this.actionTableLayoutPanel = new TableLayoutPanel();

            this.actionTableLayoutPanel.BackColor = Color.White;
            this.actionTableLayoutPanel.ColumnCount = 2;
            this.actionTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            this.actionTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.actionTableLayoutPanel.Controls.Add(this.CreateLabel("Id"), 0, 0);
            this.actionTableLayoutPanel.Controls.Add(this.CreateLabel("Nome"), 0, 1);
            this.actionTableLayoutPanel.Controls.Add(this.CreateLabel("Cpf"), 0, 2);
            this.actionTableLayoutPanel.Controls.Add(this.CreateLabel("Email"), 0, 3);
            this.actionTableLayoutPanel.Controls.Add(this.CreateLabel("Cep"), 0, 4);
            this.actionTableLayoutPanel.Controls.Add(this.CreateLabel(this.model.Id.ToString()), 1, 0);
            this.actionTableLayoutPanel.Controls.Add(this.CreateLabel(this.model.Pessoa.Nome), 1, 1);
            this.actionTableLayoutPanel.Controls.Add(this.CreateLabel(this.model.Pessoa.Cpf.ToString()), 1, 2);
            this.actionTableLayoutPanel.Controls.Add(this.CreateLabel(this.model.Endereco.Cep.ToString()), 1, 3);
            this.actionTableLayoutPanel.Controls.Add(this.CreateLabel(this.model.Contato.Email), 1, 4);
            this.actionTableLayoutPanel.Dock = DockStyle.Fill;
            this.actionTableLayoutPanel.Location = new Point(0, 5);
            this.actionTableLayoutPanel.Margin = new Padding(0);
            this.actionTableLayoutPanel.RowCount = 5;
            this.actionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.actionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.actionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.actionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.actionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.actionTableLayoutPanel.Size = new Size(730, 160);
        }

        private void SetActionTableLayoutPanel()
        {
            this.actionTableLayoutPanel = new TableLayoutPanel();

            this.actionTableLayoutPanel.BackColor = Color.White;
            this.actionTableLayoutPanel.ColumnCount = 1;
            this.actionTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.actionTableLayoutPanel.Controls.Add(this.CreateButton(global::RecorteDeCoracao.Properties.Resources.viewd_r, "view", this.form.ButtonViewClick), 0, 1); // view
            this.actionTableLayoutPanel.Controls.Add(this.CreateButton(global::RecorteDeCoracao.Properties.Resources.trash_r, "trash", this.form.ButtonViewClick), 0, 2); // trash
            this.actionTableLayoutPanel.Dock = DockStyle.Fill;
            this.actionTableLayoutPanel.Location = new Point(730, 5);
            this.actionTableLayoutPanel.Margin = new Padding(0);
            this.actionTableLayoutPanel.RowCount = 4;
            this.actionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.actionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.actionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.actionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.actionTableLayoutPanel.Size = new Size(40, 160);
        }

        private void SetMainTableLayoutPanel()
        {
            this.mainTableLayoutPanel = new TableLayoutPanel();

            this.mainTableLayoutPanel.BackColor = Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(204)))), ((int)(((byte)(195)))));
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            this.mainTableLayoutPanel.Controls.Add(this.actionTableLayoutPanel, 1, 0); // buttons
            this.mainTableLayoutPanel.Controls.Add(this.viewTableLayoutPanel, 0, 0); // view
            this.mainTableLayoutPanel.Dock = DockStyle.Top;
            this.mainTableLayoutPanel.Location = new Point(10, 10);
            this.mainTableLayoutPanel.Margin = new Padding(0, 0, 0, 10);
            this.mainTableLayoutPanel.Padding = new Padding(0, 5, 0, 5);
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
            this.mainTableLayoutPanel.Size = new Size(770, 170);
        }

        public void Build()
        {
            this.SetViewTableLayoutPanel();
            this.SetActionTableLayoutPanel();
            this.SetMainTableLayoutPanel();
        }

        public object GetValue()
        { return this.model; }

        public TableLayoutPanel GetPanel()
        { return this.mainTableLayoutPanel; }
    }
}
