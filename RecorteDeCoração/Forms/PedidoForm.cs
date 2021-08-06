using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RecorteDeCoração.Forms.PedidoForms;
using RecorteDeCoração.Source;
using RecorteDeCoração.Controller;
using RecorteDeCoração.Model;

namespace RecorteDeCoração.Forms
{
    public partial class PedidoForm : Form
    {
        private Form currentForm = null;
        private List<Pedido> dataSource = new List<Pedido>();
        private List<Pedido> listView = new List<Pedido>();
        private Pedido pedido = null;

        public PedidoForm()
        {
            InitializeComponent();
            this.Initialize();
        }

        /// <summary>
        ///     adiciona pedido aos campos de visualização
        /// </summary>
        /// <param name="pedido"></param>
        public void SetInput(dynamic pedido)
        {
            if (pedido == null) return;
            this.pedido = pedido as Pedido;

            this.label2.Text = this.pedido.Id.ToString();
            this.label4.Text = this.pedido.Cliente.Nome;
            this.label6.Text = this.pedido.Cliente.Telefone;
            this.label8.Text = this.pedido.Data_Entrega.ToString();
            this.label3.Text = StatusPedido.GetLabel(this.pedido.Status_Pedido);
        }

        /// <summary>
        ///     apaga todos os campos de visualização
        /// </summary>
        public void UnSetInput()
        {
            this.pedido = null;

            this.label2.Text = "";
            this.label4.Text = "";
            this.label6.Text = "";
            this.label8.Text = "";
            this.label3.Text = "";
        }

        /// <summary>
        ///     obtem pedido pelo index do datagrid
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Pedido</returns>
        private Pedido GetPedido(int index)
        {
            try
            {
                return this.listView[index];
            }

            catch (Exception error)
            {
                LogController.WriteException(error);
                return null;
            }
        }

        /// <summary>
        ///     obtem registros da base de dados e carrega nos atributos
        ///     
        ///     private List<Pedido> dataSource  dados da base de dados
        ///     private List<Pedido> listView    dados a serem utilizados no grid
        /// </summary>
        public void LoadData()
        {
            try {
                this.dataSource = PedidoController.Get();
                this.listView = this.dataSource;
            }

            catch (Exception error) {
                MessageBox.Show("Não Foi possível fazer leitura dos Pedidos.\n\n" +
                    "Por favor entre em contato com o administrador!\n\n" +
                    LogController.WriteExceptionAndGetMessage(error),
                    "Error: Falha Leitura dos dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop
                );
            }
        }

        /// <summary>
        ///     recarrega grid
        /// </summary>
        public void ReloadGrid() {
            this.UnSetInput();

            this.dataGridView1.DataSource = null;
            this.dataGridView1.Refresh();

            List<dynamic> viewDynamic = new List<dynamic>();
            foreach(Pedido pedido in this.listView) {
                dynamic value = new {
                    Id = pedido.Id,
                    Cliente = pedido.Cliente.Nome,
                    Entrega = pedido.Data_Entrega,
                    Pedido = pedido.Data_Pedido,
                    Status = StatusPedido.GetLabel(pedido.Status_Pedido),
                    Valor = pedido.ValorTotalPedido()
                };

                viewDynamic.Add(value);
            }

            this.dataGridView1.DataSource = viewDynamic;
            this.dataGridView1.Refresh();
        }

        /// <summary>
        ///     inicializa o componente colocando os atributos padrões
        /// </summary>
        private void Initialize()
        {
            this.panel1.Controls.Add(this.tableLayoutPanel1);

            this.SetPositionTable(this.panel1.Location.X, this.panel1.Location.Y);
            this.OffSetTable(this.panel1.Width, this.panel1.Height);
            this.ShowTable(true);
        }

        /// <summary>
        ///     fecha e limpa o formulario aberto
        /// </summary>
        private void CloseAndClearForm()
        {
            if (this.currentForm == null) return;
            this.currentForm.Close();

            this.ClearPanel();
            this.currentForm = null;
        }

        /// <summary>
        ///     adiciona formulario aberto
        /// </summary>
        /// 
        /// <param name="form"></param>
        private void SetCurrentForm(Form form)
        {
            this.CloseAndClearForm();
            this.currentForm = form;
        }

        /// <summary>
        ///     limpa o painel
        /// </summary>
        private void ClearPanel()
        {
            this.panel1.Controls.Clear();
        }

        /// <summary>
        ///     adiciona ao painel
        /// </summary>
        /// 
        /// <param name="inpanel"></param>
        private void AddInPanel(dynamic inpanel)
        {
            this.panel1.Controls.Add(inpanel);
        }

        /// <summary>
        ///     adiciona posição para tabela
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void SetPositionTable(int x, int y)
        {
            this.tableLayoutPanel1.Location = new System.Drawing.Point(x, y);
        }

        /// <summary>
        ///     adiciona dimensão para tabela
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        private void OffSetTable(int Width,int Height)
        {
            this.tableLayoutPanel1.Size = new System.Drawing.Size(Width, Height);
        }

        /// <summary>
        ///     adiciona dimensão para formulario    
        /// </summary>
        /// 
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        private void OffSetForm(int Width, int Height)
        {
            if (this.currentForm == null) return;

            this.currentForm.Size = new System.Drawing.Size(Width, Height);
        }

        /// <summary>
        ///     permite visualização do painel    
        /// </summary>
        /// 
        /// <param name="boolean"></param>
        private void ShowTable(bool boolean)
        {
            this.tableLayoutPanel1.Visible = boolean;
        }

        /// <summary>
        ///     fecha formulario e retorna para painel
        /// </summary>
        public void CloseForm()
        {
            this.CloseAndClearForm();
            this.Initialize();
        }

        /// <summary>
        ///     redimencionamento de formulario
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PedidoForm_Resize(object sender, EventArgs e)
        {
            this.OffSetForm(this.panel1.Width, this.panel1.Height);
        }

        /// <summary>
        ///     apagar registro selecionado
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.pedido == null) return;
            DialogResult result = MessageBox.Show(
                "obs: Este pedido só vai ser removido caso não exista entrada financeira, caso exista o pedido não vai ser removido, você pode mudar para o status de cancelado " +
                "para evitar complicações.\n\n" +
                "Tem certeza que deseja remover este pedido ?",
                "deseja continuar ?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            Cursor.Current = Cursors.WaitCursor;

            if (result == DialogResult.No) return;
            if (PedidoController.DeleteOpen(this.pedido) == false) {
                Cursor.Current = Cursors.Default;
                LogController.ErrorMessage("Error", "Não é possivel remover este registro\n\nExiste pagamento para este Pedido!");
                return;
            }

            try
            {
                foreach(ProdutoPedido produtoPedido in this.pedido.Produto_Pedido)
                {
                    ProdutoPedidoController.Delete(produtoPedido);
                }
            } catch (Exception error)
            {
                Cursor.Current = Cursors.Default;
                LogController.WriteException(error);
                LogController.ErrorMessage("Error", "Não foi possivel remover este pedido!");
                return;
            }

            PedidoController.Delete(this.pedido);

            this.UnSetInput();
            this.LoadData();
            this.ReloadGrid();

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        ///     atualizar pagina
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.LoadData();
            this.ReloadGrid();

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        ///     novo 
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PedidoFormForm pedidoForm = new PedidoFormForm(this) { TopLevel = false };

            try
            {
                this.SetCurrentForm(pedidoForm);
                this.OffSetForm(this.panel1.Width, this.panel1.Height);
                this.ClearPanel();
                this.AddInPanel(pedidoForm);

                pedidoForm.Show();
            }

            catch (Exception error)
            {
                LogController.WriteException(error);
                this.CloseForm();
            }

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        ///     limpar vizualisação
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.UnSetInput();
        }

        /// <summary>
        ///     valor selecionado
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > this.listView.Count) return;
            Pedido pedido = this.GetPedido(e.RowIndex);
            if (pedido == null) return;
            this.SetInput(pedido);
        }

        /// <summary>
        ///     editar pedido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.pedido == null) return;
            Cursor.Current = Cursors.WaitCursor;
            PedidoFormForm pedidoForm = new PedidoFormForm(this, this.pedido) { TopLevel = false };

            try
            {
                this.SetCurrentForm(pedidoForm);
                this.OffSetForm(this.panel1.Width, this.panel1.Height);
                this.ClearPanel();
                this.AddInPanel(pedidoForm);

                pedidoForm.Show();
            }

            catch (Exception error)
            {
                LogController.WriteException(error);
                this.CloseForm();
            }

            Cursor.Current = Cursors.Default;
        }
    }
}
