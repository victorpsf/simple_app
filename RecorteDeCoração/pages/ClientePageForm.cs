using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using RecorteDeCoração.Model;
using RecorteDeCoração.Controller;
using RecorteDeCoração.Source;

namespace RecorteDeCoração.Pages
{
    public partial class ClientePageForm : Form
    {
        //private Cliente cliente;
        //private ViewForm viewForm;
        //private Main mainForm;

        public ClientePageForm(Main mainForm)
        {
            //this.mainForm = mainForm;
            InitializeComponent();
        }

        //public void LoadPage() {
        //    this.button2.Enabled = false;
        //    this.SetView();
        //    this.SetToolTip();
        //}

        //private void SetToolTip()
        //{
        //    this.toolTip1.SetToolTip(this.button1, "Informação\n\nClique para salvar registro");
        //    this.toolTip2.SetToolTip(this.button2, "Informação\n\nRemove o dado selecionado.");
        //    this.toolTip3.SetToolTip(this.button3, "Informação\n\nLimpa dados informados.\n\nobs: caso tenha sido selecionado também limpa\nmas não exclui o registro.");
        //}

        //private void SetView()
        //{
        //    this.viewForm = new ViewForm();

        //    try {
        //        this.viewForm.TopLevel = false;
        //        this.viewForm.Width = this.panel2.Width;
        //        this.viewForm.Height = this.panel2.Height;

        //        this.panel2.Controls.Clear();
        //        this.panel2.Controls.Add(this.viewForm);

        //        this.viewForm.SetBaseForm(this);
        //        this.viewForm.Show();
        //    } catch (Exception error) {
        //        LogController.WriteException(error);
        //    }
        //}

        //// clear fields
        //private void ClearFields()
        //{
        //    this.cliente = null;
        //    this.label5.Text = "";
        //    this.textBox1.Text = "";
        //    this.textBox2.Text = "";
        //    this.textBox3.Text = "";
        //}

        //// set client in input values
        //public void SetClient(dynamic cliente)
        //{
        //    this.button2.Enabled = true;
        //    this.ClearFields();
        //    this.cliente = cliente;

        //    this.textBox1.Text = this.cliente.Nome;
        //    this.textBox2.Text = this.cliente.Email;
        //    this.textBox3.Text = this.cliente.Telefone;
        //    this.label5.Text   = this.cliente.Id.ToString();
        //}

        //// validate e-mail
        //private bool IsValidEmail(string email)
        //{
        //    try
        //    {
        //        var addr = new System.Net.Mail.MailAddress(email);
        //        return addr.Address == email;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //// validate fields input
        //private bool ValidateFields()
        //{

        //    if (this.textBox1.Text.Length < 5) {
        //        MessageBox.Show("Nome contém menos de 5 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //    if (!this.IsValidEmail(this.textBox2.Text)) {
        //        MessageBox.Show("Email informado é inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //    if (!(Regex.Match(this.textBox3.Text, @"^[0-9]+$").Success)) {
        //        MessageBox.Show("Possivelmente o telefone pode está incorreto", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        //        return false;
        //    }

        //    return true;
        //}

        //// create button
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (!this.ValidateFields()) return;
        //    if (this.cliente == null) {
        //        (new ClienteController()).CreateCliente(new Cliente(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text));
        //    } else {
        //        DialogResult result = MessageBox.Show("Realmente deseja atualizar o registro?\n\nApós alterado não poderá ser recuperado.", "Atualização do registro!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //        if (result == DialogResult.No) return;
        //        (new ClienteController()).UpdateCliente(new Cliente(this.cliente.Id, this.textBox1.Text, this.textBox2.Text, this.textBox3.Text));
        //    }

        //    this.ClearFields();
        //    this.viewForm.LoadGrid();
        //}

        //// delete button
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    if (this.cliente == null) return;

        //    DialogResult result = MessageBox.Show("Deseja continuar?\n\nCaso você aceite remover este registro não poderá revelo\no registro vai ser removido do banco de dados sem a possibilidade de recuperação.", "Tem certeza que deseja excluir este registro ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        //    if (result == DialogResult.No) return;
        //    (new ClienteController()).DeleteCliente(this.cliente);
        //    this.ClearFields();
        //    this.viewForm.LoadGrid();
        //}

        //// clear button
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    this.ClearFields();
        //}

        //// telefone text validator
        //private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //        MessageBox.Show("este campo aceita somente numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //protected override void OnFormClosing(FormClosingEventArgs e) {
        //    base.OnFormClosing(e);
        //    this.mainForm.VisibleForm(true);
        //}
    }
}
