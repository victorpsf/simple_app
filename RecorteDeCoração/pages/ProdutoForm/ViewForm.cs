﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RecorteDeCoração.Model;
using RecorteDeCoração.Controller;

namespace RecorteDeCoração.pages.ProdutoForm
{
    public partial class ViewForm : Form
    {
        private List<Produto> produtos;
        private ProdutoPageForm form;

        public ViewForm()
        {
            InitializeComponent();
            this.LoadGrid();
        }

        private void ClearGrid()
        {
            this.dataGridView1.DataSource = null;
        }

        private List<Produto> SetAndGetClientes()
        {
            this.produtos = (new ProdutoController()).ListProduto();
            return this.produtos;
        }

        private Produto GetProduto(int listIndex)
        {
            if (this.produtos.Count < listIndex) return null;
            return this.produtos[listIndex];
        }

        public void LoadGrid()
        {
            this.ClearGrid();
            this.dataGridView1.DataSource = this.SetAndGetClientes();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        public void SetBaseForm(ProdutoPageForm form)
        {
            this.form = form;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            //Cliente cliente = this.GetClient(e.RowIndex);

            //if (cliente == null) return;
            //this.form.SetProduto(cliente);
        }
    }
}
