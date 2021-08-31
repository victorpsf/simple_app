using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace RecorteDeCoracao.View
{
    public partial class MainView : Form
    {
        private Form currentForm = null;

        public MainView()
        {
            InitializeComponent();
            this.SetOpacityAllPanel();
        }

        public void SetOpacityAllPanel()
        {
            this.panel4.Visible = false;
            this.panel5.Visible = false;
            this.panel6.Visible = false;
        }

        private void AnimationPanel(Panel panel, int heigth)
        {
            if (!panel.Visible) {
                panel.Height = 0;
                panel.Visible = true;
                for(int x = 0; x <= heigth; x += 10)
                {
                    Thread.Sleep(5);
                    panel.Height = x;
                }
            } else {
                for (int x = heigth; x >= 0; x -= 10)
                {
                    Thread.Sleep(5);
                    panel.Height = x;
                }
                panel.Visible = false;
                panel.Height = heigth;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.AnimationPanel(this.panel4, this.panel4.Height);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.AnimationPanel(this.panel5, this.panel5.Height);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.AnimationPanel(this.panel6, this.panel6.Height);
        }

        private void UnsetFormInPanel ()
        {
            if (this.currentForm == null) return;
            this.currentForm.Close();
            this.currentForm = null;
            this.panel2.Controls.Clear();
        }

        private void SetFormInPanel (Form form)
        {
            this.UnsetFormInPanel();
            this.currentForm = form;
            this.panel2.Controls.Add(form);
            this.currentForm.Show();
        }

        // cliente
        private void button2_Click(object sender, EventArgs e)
        {
            ClienteDataView clienteDataView = new ClienteDataView() { TopLevel = false, FormBorderStyle = FormBorderStyle.None, Dock = DockStyle.Fill };

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                clienteDataView.Build();
            } catch (Exception error) {
                this.UnsetFormInPanel();
                return;
            }
            Cursor.Current = Cursors.Default;

            this.SetFormInPanel(clienteDataView);
        }

        // produto
        private void button3_Click(object sender, EventArgs e)
        {
            ProdutoDataView produtoDataView = new ProdutoDataView() { TopLevel = false, FormBorderStyle = FormBorderStyle.None, Dock = DockStyle.Fill };

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                produtoDataView.Build();
            }
            catch (Exception error)
            {
                this.UnsetFormInPanel();
                return;
            }
            Cursor.Current = Cursors.Default;

            this.SetFormInPanel(produtoDataView);
        }

        // modelo
        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
