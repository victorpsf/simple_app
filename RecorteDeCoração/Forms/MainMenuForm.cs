using System;
using System.Windows.Forms;
using RecorteDeCoração.Forms.ClienteForms;
using RecorteDeCoração.Source;
using RecorteDeCoração.Forms.Interfaces;

namespace RecorteDeCoração.Forms
{
    public partial class MainMenuForm : Form, IPaternForm
    {
        private Form currentForm = null;
        private bool formOpened = false;

        public MainMenuForm()
        {
            InitializeComponent();
        }

        public void SetCurrentForm (Form activity)
        {
            if (this.formOpened == true) this.ClearPanel();

            activity.Show();
            this.currentForm = activity;

            this.panel5.Controls.Add(activity);
        }

        public void ClearPanel ()
        {
            if (this.formOpened == false) return;
            this.panel5.Controls.Clear();
            this.currentForm.Close();

            this.currentForm = null;
            this.formOpened = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = !this.panel3.Visible;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.panel4.Visible = !this.panel4.Visible;
        }

        // cliente
        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            ClienteViewForm clienteViewForm = new ClienteViewForm 
            { TopLevel = false, FormBorderStyle = FormBorderStyle.None, Dock = DockStyle.Fill };

            try {
                clienteViewForm.PageLoad();
            }
            catch (Exception error) {
                clienteViewForm = null;
                LogController.WriteException(error);
                LogController.ErrorMessage("Não foi possível carregar a página", error.Message);
            }

            Cursor.Current = Cursors.Default;
            if (clienteViewForm == null) return;
            this.SetCurrentForm(clienteViewForm);
        }

        // modelo
        private void button3_Click(object sender, EventArgs e)
        {

        }

        // produto
        private void button4_Click(object sender, EventArgs e)
        {

        }

        // galeria
        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
