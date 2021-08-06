using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RecorteDeCoração.Source;
using RecorteDeCoração.Model;
using RecorteDeCoração.Controller;

namespace RecorteDeCoração.Forms.PedidoForms
{
    public partial class PedidoFormForm : Form
    {
        private Form currentForm = null;
        private PedidoForm pedidoForm = null;
        private Cliente cliente = null;
        private List<ProdutoPedido> pedidoProdutos = new List<ProdutoPedido>();
        private Pedido pedido = null;

        //Solicitado              -> 
        // : verifica se tem em estoque e passa para o cliente,
        // : após amostrar ao cliente informa o valor e espera confirmação

        //Em processo  -> 
        // : Projeto aprovado 50% pago

        //Confirmado              -> 
        // : topo da listagem inicial, pronto

        //Entregue                -> 
        // : a fim de registro, apenas para organização

        //Cancelado
        // : pedido foi cancelado
        public PedidoFormForm(PedidoForm pedidoForm, dynamic pedido = null)
        {
            this.pedidoForm = pedidoForm;
            InitializeComponent();
            this.Initialize();
            if (pedido != null && typeof(Pedido).IsInstanceOfType(pedido)) {
                this.SetPedido(pedido as Pedido);
            }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="pedido"></param>
        private void SetPedido(Pedido pedido)
        {
            this.pedido = pedido;

            this.label2.Text = this.pedido.Id.ToString();
            this.LabelNome.Text = this.pedido.Cliente.Nome;

            this.pedidoProdutos = new List<ProdutoPedido>(pedido.Produto_Pedido);
            this.ReloadGrid();

            this.comboBox2.Text = StatusPedido.GetLabel(this.pedido.Status_Pedido);

            this.dateTimePicker1.Value = this.pedido.Data_Pedido;
            this.dateTimePicker2.Value = this.pedido.Data_Entrega;
        }

        /// <summary>
        ///     atualiza produto pedido ou remove
        /// </summary>
        /// 
        /// <param name="type">update delete</param>
        /// <param name="produtoPedido"></param>
        /// <param name="index"></param>
        public void ChangeProdutoPedido(string type, dynamic produtoPedido)
        {
            int index = -1;

            switch(type)
            {
                case "append":
                    index = this.FindProdutopedido(this.pedidoProdutos, produtoPedido, "produto.id");
                    if (index >= 0) {
                        this.pedidoProdutos[index].Quantidade += (produtoPedido as ProdutoPedido).Quantidade;
                    } 

                    else {
                        this.pedidoProdutos.Add(produtoPedido);
                    }
                    break;
                case "update":
                    index = this.FindProdutopedido(this.pedidoProdutos, produtoPedido, "produto.id");
                    if (index >= 0) {
                        this.pedidoProdutos[index] = produtoPedido;
                    }
                    break;
                case "delete":
                    index = this.FindProdutopedido(this.pedidoProdutos, produtoPedido, "produto.id");
                    if (index >= 0) {
                        this.pedidoProdutos.RemoveAt(index);
                    }
                    break;
                default:
                    return;
            } 

            this.ReloadGrid();
        }

        private int FindProdutopedido(List<ProdutoPedido> produtoPedidos, ProdutoPedido produtoPedido, string field = "id")
        {
            int index = -1;

            for(int x = 0; x < produtoPedidos.Count; x++) {
                switch(field)
                {
                    case "id":
                        if (produtoPedidos[x].Id == produtoPedido.Id) {
                            index = x;
                        }
                        break;

                    case "produto.id":
                        if (produtoPedidos[x].Produto.Id == produtoPedido.Produto.Id) {
                            index = x;
                        }
                        break;
                }

                if (index >= 0) break;
            }

            return index;
        }

        #region controlles_internos
        /// <summary>
        ///     adiciona cliente a propriedade da classe
        /// </summary>
        /// <param name="cliente"></param>
        public void SetCliente(dynamic cliente)
        {
            this.cliente = cliente as Cliente;
            if (this.cliente != null) 
                this.LabelNome.Text = this.cliente.Nome;
        }

        public void SetPedidoProduto(dynamic pedidoProduto)
        {
            this.ChangeProdutoPedido("append", pedidoProduto);
            this.ReloadGrid();
        }

        /// <summary>
        ///     adiciona a tabela de layout ao panel principal do form
        /// </summary>
        private void Initialize()
        {
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.comboBox1.Text = "Id";

            this.comboBox2.Items.Clear();
            this.comboBox2.Items.AddRange(StatusPedido.GetLabels());
            this.comboBox2.Text = StatusPedido.DefaultLabel();

            this.SetPositionTable(this.panel1.Location.X, this.panel1.Location.Y);
            this.OffSetTable(this.panel1.Width, this.panel1.Height);
            this.ShowTable(true);
            this.ReloadGrid();
        }

        /// <summary>
        ///     fecha o formulario vinculado ao panel e seta ull a propriedade da classe
        /// </summary>
        private void CloseAndClearForm()
        {
            if (this.currentForm != null)
                this.currentForm.Close();

            this.ClearPanel();
            this.currentForm = null;
        }

        /// <summary>
        ///     adiciona novo formulario a propriedade da classe, antes limpa a propriedade
        /// </summary>
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
        /// <param name="inpanel"></param>
        private void AddInPanel(dynamic inpanel)
        {
            this.panel1.Controls.Add(inpanel);
        }

        /// <summary>
        ///     adiciona posição a tabela de painel
        /// </summary>
        /// 
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void SetPositionTable(int x, int y)
        {
            this.tableLayoutPanel1.Location = new System.Drawing.Point(x, y);
        }

        /// <summary>
        ///     adiciona tamanho a tabela de painel
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        private void OffSetTable(int Width, int Height)
        {
            this.tableLayoutPanel1.Size = new System.Drawing.Size(Width, Height);
        }

        /// <summary>
        ///     muda tamanho do formulario vinculado ao painel
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        private void OffSetForm(int Width, int Height)
        {
            if (this.currentForm == null) return;

            this.currentForm.Size = new System.Drawing.Size(Width, Height);
        }

        /// <summary>
        ///     torna a tabela visivel
        /// </summary>
        /// <param name="boolean"></param>
        private void ShowTable(bool boolean)
        {
            this.tableLayoutPanel1.Visible = boolean;
        }

        /// <summary>
        ///     fecha formulario limpa propriedade e inicia a tabela
        /// </summary>
        public void CloseForm()
        {
            this.CloseAndClearForm();
            this.Initialize();
        }

        /// <summary>
        ///     recarrega daragrid view
        /// </summary>
        public void ReloadGrid()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Refresh();

            List<dynamic> viewProdutosPedido = new List<dynamic>();
            foreach (ProdutoPedido produtoPedido in this.pedidoProdutos)
            {
                viewProdutosPedido.Add(new
                {
                    Nome = produtoPedido.Produto.Nome,
                    Valor = produtoPedido.Produto.Valor_Unitario,
                    Quantidade = produtoPedido.Quantidade,
                    Total = produtoPedido.ValorPedidoProduto()
                });
            }

            this.dataGridView1.DataSource = viewProdutosPedido;
            this.dataGridView1.Refresh();
        }

        /// <summary>
        ///     faz a limpeza dos campos de input
        /// </summary>
        private void ClearInput()
        {
            this.cliente = null;

            this.LabelNome.Text = "";

            this.dateTimePicker1.Value = DateTime.Now;
            this.dateTimePicker2.Value = DateTime.Now;

            this.pedidoProdutos = new List<ProdutoPedido>();
            this.ReloadGrid();
        }
        #endregion

        #region botoes_pagina_eventos
        /// <summary>
        ///     retorna para o formulario anterior    
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.pedidoForm.CloseForm();
        }

        /// <summary>
        ///     muda para painel para adicionar cliente    
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            PedidoClienteForm pedidoClienteForm = new PedidoClienteForm(this) { TopLevel = false };

            Cursor.Current = Cursors.WaitCursor;

            try {
                pedidoClienteForm.LoadData();
                pedidoClienteForm.ReloadGrid();

                this.ShowTable(false);
                this.SetCurrentForm(pedidoClienteForm);
                this.AddInPanel(pedidoClienteForm);
                this.OffSetForm(this.panel1.Width, this.panel1.Height);

                pedidoClienteForm.Show();
            } 

            catch (Exception error) {
                MessageBox.Show(LogController.WriteExceptionAndGetMessage(error), "Erro ao carregar pagina", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.CloseAndClearForm();
                this.Initialize();
            }

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        ///      muda para painel para adicionar produto ao pedido  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ProdutoPedidoForm produtoPedidoForm = new ProdutoPedidoForm(this) { TopLevel = false };

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                produtoPedidoForm.LoadData();
                produtoPedidoForm.ReloadGrid();

                this.ShowTable(false);
                this.SetCurrentForm(produtoPedidoForm);
                this.AddInPanel(produtoPedidoForm);
                this.OffSetForm(this.panel1.Width, this.panel1.Height);

                produtoPedidoForm.Show();
            }

            catch (Exception error)
            {
                MessageBox.Show(LogController.WriteExceptionAndGetMessage(error), "Erro ao carregar pagina", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.CloseAndClearForm();
                this.Initialize();
            }

            Cursor.Current = Cursors.Default;
        }
        #endregion

        /// <summary>
        ///     botão para limpeza dos campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.ClearInput();
        }

        /// <summary>
        ///     botão para excluir pedido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            RemoveProdutoPedidoForm removeProdutoPedidoForm = new RemoveProdutoPedidoForm(this, this.pedidoProdutos);
            removeProdutoPedidoForm.Show();
        }

        #region eventos_formulario_atual

        /// <summary>
        ///     evento de redimencionamento de formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PedidoFormForm_Resize(object sender, EventArgs e)
        {
            this.OffSetForm(this.panel1.Width, this.panel1.Height);
        }
        #endregion

        private void CreatePedido()
        {
            Pedido pedido = null;
            if (this.cliente == null) {
                MessageBox.Show("Cliente não selecionado");
                return;
            }

            if (this.pedidoProdutos.Count == 0) {
                MessageBox.Show("Sem produtos para o pedido, primeiro adicione");
                return;
            }

            try {
                pedido = PedidoController.Create(
                    new Pedido(
                        this.cliente,
                        // dateTimePicker2 data entrega
                        this.dateTimePicker2.Value,
                        // dateTimePicker1 data pedido
                        this.dateTimePicker1.Value,
                        StatusPedido.GetId(this.comboBox2.Text)
                    )
                );

                this.cliente = null;

                List<ProdutoPedido> produtoPedidos = new List<ProdutoPedido>();
                foreach(ProdutoPedido produtoPedido in this.pedidoProdutos) {
                    try {
                        produtoPedido.Pedido = pedido;
                        produtoPedidos.Add(ProdutoPedidoController.Create(produtoPedido));
                    }

                    catch (Exception error) {
                        LogController.WriteException(error);
                        continue;
                    }
                }

                pedido.Produto_Pedido = produtoPedidos.ToArray();
                this.SetPedido(pedido);
                this.pedidoForm.ReloadGrid();
            }

            catch (Exception error) {
                LogController.WriteException(error);
                MessageBox.Show("Não foi possível criar o pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void UpdatePedido()
        {
            if (this.cliente != null)
            {
                DialogResult result = MessageBox.Show("Cliente do pedido foi alterado, deseja realmente alterar ?", "question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (DialogResult.No == result) {
                    this.cliente = null;
                    this.SetPedido(this.pedido);
                    return;
                }
            }

            if (this.pedidoProdutos.Count == 0) {
                MessageBox.Show("Sem produtos para o pedido, primeiro adicione");
                return;
            }

            if (this.cliente != null) this.pedido.Cliente = this.cliente;
            this.cliente = null;
            
            try {
                // dateTimePicker2 data entrega
                this.pedido.Data_Entrega = this.dateTimePicker2.Value;
                // dateTimePicker1 data pedido
                this.pedido.Data_Pedido = this.dateTimePicker1.Value;

                MessageBox.Show(this.comboBox1.Text);
                this.pedido.Status_Pedido = StatusPedido.GetId(this.comboBox2.Text);

                PedidoController.Update(this.pedido);

                this.SetPedido(this.pedido);
                this.pedidoForm.ReloadGrid();
            }

            catch (Exception error) {
                LogController.WriteException(error);
                LogController.ErrorMessage("Error", "Não foi possível criar o pedido");
                return;
            }
        }

        /// <summary>
        ///     criar registro de pedido
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (this.pedido == null)
                this.CreatePedido();
            else
                this.UpdatePedido();

            Cursor.Current = Cursors.Default;
        }
    }
}
