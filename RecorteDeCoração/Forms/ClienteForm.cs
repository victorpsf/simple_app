using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;

using RecorteDeCoração.Model;
using RecorteDeCoração.Controller;
using RecorteDeCoração.Source;

namespace RecorteDeCoração.Forms
{
    public partial class ClienteForm : Form
    {
        private List<Cliente> dataSource = new List<Cliente>();
        private List<Cliente> listView = new List<Cliente>();

        private Cliente cliente = null;

        public ClienteForm()
        {
            InitializeComponent();
            this.comboBox1.Text = "Id";
            this.LoadTools();
        }

        public void InitializeGrid()
        {
            this.ReloadGrid();
            this.LoadData();
            this.ReloadGrid();
        }

        private void LoadTools()
        {
            this.toolTip1.SetToolTip(this.pictureBox2, "Clique para salvar ou para alterar");
            this.toolTip2.SetToolTip(this.pictureBox3, "Clique para Limpar");
            this.toolTip3.SetToolTip(this.pictureBox4, "Clique para excluir registro selecionado");
            this.toolTip4.SetToolTip(this.pictureBox5, "Recarregar dados");
            this.toolTip5.SetToolTip(this.pictureBox1, "Filtrar dados");
        }

        public void ReloadGrid()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Refresh();
            this.dataGridView1.DataSource = this.listView;
            this.dataGridView1.Refresh();
        }

        public void LoadData()
        {
            try {
                this.dataSource = ClienteController.Get();
                this.listView = this.dataSource;
            }

            catch (Exception error) {
                MessageBox.Show("Não Foi possível fazer leitura dos clientes.\n\n" +
                    "Por favor entre em contato com o administrador!\n\n" +
                    LogController.WriteExceptionAndGetMessage(error),
                    "Error: Falha Leitura dos dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop
                );
            }
        }

        // validate e-mail
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void ClearInput()
        {
            // Id
            this.LabelId.Text = "";

            // Nome
            this.textBox1.Text = "";

            // Email
            this.textBox2.Text = "";

            // Telefone
            this.textBox3.Text = "";

            this.cliente = null;
        }

        private Cliente GetCliente(int index)
        {
            try {
                return this.listView[index];
            } catch (Exception error) {
                LogController.WriteException(error);
                return null;
            }
        }

        private void InputValue(Cliente cliente)
        {
            this.cliente = cliente;

            this.LabelId.Text = cliente.Id.ToString();
            this.textBox1.Text = cliente.Nome;
            this.textBox2.Text = cliente.Email;
            this.textBox3.Text = cliente.Telefone;
        }

        private void CreateClient()
        {
            try {
                Cliente cliente = ClienteController.Create(
                    new Cliente(
                        this.textBox1.Text,
                        this.textBox2.Text,
                        this.textBox3.Text
                    )
                );

                this.InputValue(cliente);
                this.dataSource.Add(cliente);
                this.listView = this.dataSource;
                this.ReloadGrid();
            } 

            catch (Exception error) {
                LogController.WriteException(error);
                MessageBox.Show("Não foi possivel criar o cliente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateClient()
        {
            try
            {
                this.cliente.Nome = this.textBox1.Text;
                this.cliente.Email = this.textBox2.Text;
                this.cliente.Telefone = this.textBox3.Text;

                this.cliente = ClienteController.Update(this.cliente);

                this.ClearInput();
                this.LoadData();
                this.ReloadGrid();
            }

            catch (Exception error)
            {
                LogController.WriteException(error);
                MessageBox.Show("Não foi possivel salvar o cliente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // salvar
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!this.IsValidEmail(this.textBox2.Text)) {
                MessageBox.Show("Email invalido, verifique se está correto.\n\n" + 
                    "ex: example@example.com" + 
                    "    example.exampledomain@example.com.br", "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            if (this.cliente == null)
                this.CreateClient();
            else
                this.UpdateClient();

            Cursor.Current = Cursors.Default;
        }

        // limpar
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.ClearInput();
        }

        // excluir
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (this.cliente == null) return;

            DialogResult result = MessageBox.Show("Você realmente deseja remover ?", "Info: remoção de cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.No) return;

            MessageBox.Show("Se o cliente não poder ser removido isso pode indicar que ele está ligado lógicamente com" + 
                " outro informação, o sistema vai previnir a remoção para evitar perder informações" + 
                " caso isto persista contate o administrador.", "Info: remoção de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information
            );

            Cursor.Current = Cursors.WaitCursor;

            try {
                ClienteController.Delete(this.cliente);
            }

            catch (Exception error) {
                MessageBox.Show("Error ao excluir!\n\n" + LogController.WriteExceptionAndGetMessage(error), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        // refresh
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.LoadData();
            this.ReloadGrid();

            Cursor.Current = Cursors.Default;
        }

        // search
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.listView = ClienteController.Filter(this.dataSource, this.comboBox1.Text, this.textBox4.Text);
            this.ReloadGrid();
        }

        #region controller
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClienteController.ValidateFilterEvent(sender, e, this.comboBox1.Text);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || this.listView.Count < e.RowIndex) return;
            Cliente cliente = this.GetCliente(e.RowIndex);
            if (cliente == null) return;
            this.InputValue(cliente);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            this.textBox4.Text = "";
        }
        #endregion
    }
}
