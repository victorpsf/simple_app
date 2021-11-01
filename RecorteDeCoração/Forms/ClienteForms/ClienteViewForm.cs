using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using RecorteDeCoração.Forms.Interfaces;
using RecorteDeCoração.Source;
using RecorteDeCoração.Forms.Creator;
using RecorteDeCoração.ModelDto;
using RecorteDeCoração.DataBase.Client.Query;

namespace RecorteDeCoração.Forms.ClienteForms
{
    public partial class ClienteViewForm : Form, IForm, IPaternForm
    {
        public Form currentForm;

        public List<PersonDto> clientes = new List<PersonDto>();
        public List<ClientViewFormCreator> clientViewFormCreators = new List<ClientViewFormCreator>();
        public Form CurrentForm;

        public ClienteViewForm()
        {
            InitializeComponent();
        }

        public void SetCurrentForm(Form activity)
        {
            this.ClearPanel();

            activity.Show();
            this.currentForm = activity;

            this.panel1.Controls.Add(activity);
        }

        public void AddNewPerson (PersonDto person)
        {
            this.clientes.Add(person);
            this.LoadPanelData();
        }

        public void ChildrenReturn ()
        {
            this.ClearPanel();

            this.panel1.Controls.Add(this.tableLayoutPanel1);

            this.LoadPanelData();
        }

        public void ClearPanel()
        {
            this.panel1.Controls.Clear();

            if (this.currentForm != null)
                this.currentForm.Close();

            this.currentForm = null;
        }

        public void EditButtonClick (object sender, EventArgs e, string label, PersonDto cliente)
        {
            Cursor.Current = Cursors.WaitCursor;

            ClientCreateForm clientCreateForm = new ClientCreateForm(this, label, cliente)
            { TopLevel = false, FormBorderStyle = FormBorderStyle.None, Dock = DockStyle.Fill };

            try {
                clientCreateForm.PageLoad();
                this.SetCurrentForm(clientCreateForm);
            }

            catch (Exception error) {
                LogController.WriteException(error);
                LogController.ErrorMessage("Não foi possível recarregar a página", error.Message);
            }

            Cursor.Current = Cursors.Default;
        }

        public void DeleteButtonClick (object sender, EventArgs e, string label, PersonDto cliente)
        {
            MessageBox.Show("Delete", label);
        }

        public void PageLoad()
        {
            ClientQueryDto clientQueryDto = new ClientQueryDto();
            this.clientes = clientQueryDto.GetPerson();

            this.LoadPanelData();
        }

        public void LoadPanelData()
        {
            this.panel3.Controls.Clear();

            foreach (PersonDto person in this.clientes)
            {
                ClientViewFormCreator creator = new ClientViewFormCreator(this.EditButtonClick, this.DeleteButtonClick, person);
                this.panel3.Controls.Add(creator.Generate());
                this.clientViewFormCreators.Add(creator);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ClientCreateForm clientCreateForm = new ClientCreateForm(this, "Create", null) 
            { TopLevel = false, FormBorderStyle = FormBorderStyle.None, Dock = DockStyle.Fill };

            try
            {
                clientCreateForm.PageLoad();
                this.SetCurrentForm(clientCreateForm);
            }

            catch (Exception error)
            {
                LogController.WriteException(error);
                LogController.ErrorMessage("Não foi possível recarregar a página", error.Message);
            }

            Cursor.Current = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                this.PageLoad();
            }

            catch (Exception error)
            {
                LogController.WriteException(error);
                LogController.ErrorMessage("Não foi possível recarregar a página", error.Message);
            }

            Cursor.Current = Cursors.Default;
        }
    }
}
