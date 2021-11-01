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
using RecorteDeCoração.ModelDto;

using RecorteDeCoração.DataBase.Client.Command;
using RecorteDeCoração.Source;

namespace RecorteDeCoração.Forms.ClienteForms
{
    public partial class ClientCreateForm : Form, IForm
    {
        public ClienteViewForm clienteViewForm { get; set; }
        public PersonDto person { get; set; }
        public string formType { get; set; }

        public ClientCreateForm(ClienteViewForm form, string formType, PersonDto person)
        {
            this.clienteViewForm = form;
            this.formType = formType;
            this.person = person;

            this.InitializeComponent();
        }

        public void PageLoad()
        {
            if (this.formType != "edit") return;

            this.textBox1.Text = this.person.Name;
            this.textBox2.Text = this.person.Cpf;
            this.textBox3.Text = this.person.Rg;
            this.dateTimePicker1.Value = this.person.BirthDate;
            this.textBox4.Text = this.person.Email;
            this.textBox5.Text = this.person.Phone;
            this.richTextBox1.Text = this.person.OtherContact;
            this.textBox7.Text = this.person.Cep;
            this.textBox6.Text = this.person.Street;
            this.textBox8.Text = this.person.Complement;
            this.richTextBox2.Text = this.person.OtherLocation;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.clienteViewForm.ChildrenReturn();
        }

        private void ChangeText(Button btn, bool visible)
        {
            if (visible) {
                btn.Text = @"\/";
            }
            
            else {
                btn.Text = @"/\";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ChangeText(this.button3, this.panel4.Visible);
            this.panel4.Visible = !this.panel4.Visible;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.ChangeText(this.button4, this.panel5.Visible);
            this.panel5.Visible = !this.panel5.Visible;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.ChangeText(this.button5, this.panel8.Visible);
            this.panel8.Visible = !this.panel8.Visible;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                ClientCommandDto cmd = new ClientCommandDto();
                PersonDto person = new PersonDto
                {
                    Name = this.textBox1.Text,
                    PersonType = PersonTypes.Client,
                    Cpf = this.textBox2.Text,
                    Rg = this.textBox3.Text,
                    BirthDate = this.dateTimePicker1.Value,
                    Email = this.textBox4.Text,
                    Phone = this.textBox5.Text,
                    OtherContact = this.richTextBox1.Text,
                    Cep = this.textBox7.Text,
                    Street = this.textBox6.Text,
                    Complement = this.textBox8.Text,
                    OtherLocation = this.richTextBox2.Text
                };

                person.PersonId = cmd.Save(person);

                this.clienteViewForm.AddNewPerson(person);
                this.clienteViewForm.ChildrenReturn();
            } catch (Exception error) {
                LogController.WriteException(error);
                LogController.ErrorMessage("Failure in execute", error.Message);
            }
            
        }
    }
}
