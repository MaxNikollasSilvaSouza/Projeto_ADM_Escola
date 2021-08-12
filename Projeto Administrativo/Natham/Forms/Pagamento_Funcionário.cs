using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Projeto_Administrativo
{
    public partial class Pagamento_Funcionário : Form
    {
        PagamentoFuncionários pag;
        String rg;
        String id;
        String rg_pagamento;
        public Pagamento_Funcionário(string rgg)
        {
            InitializeComponent();
            id = "";
            rg = rgg;
        }

        private void Pagamento_Funcionário_Load(object sender, EventArgs e)
        {
            pag = new PagamentoFuncionários();
            DG1.DataSource = null;
            if (CB3.SelectedItem == "Funcionários")
            {
                DG1.DataSource = pag.MostrarFunc();
                DG1.ClearSelection();
                CB4.Text = null;
                CB4.Enabled = false;
            }
        }

        private void CB2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CB2.SelectedItem == "Inserir")
            {
                dateTimePicker1.Enabled = true;
                DG1.DataSource = pag.MostrarFunc();
                CB1.Enabled = true;
            }
            else if (CB2.SelectedItem == "Modificar")
            {
                dateTimePicker1.Enabled = true;
                DG1.DataSource = pag.filtros("T");
                CB1.Enabled = true;
            }
            else if (CB2.SelectedItem == "Deletar")
            {
                dateTimePicker1.Enabled = false;
                DG1.DataSource = pag.filtros("T");
                CB1.Enabled = false;
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            string data = dateTimePicker1.Text;
            string[] date = data.Split('/');
            data = date[2] + "-" + date[1] + "-" + date[0];
            string situacao = CB1.SelectedItem.ToString();
            pag = new PagamentoFuncionários();

            if (CB2.SelectedItem == "Inserir")
            {
                pag.CorfirmarPagamento(data, situacao, "", rg_pagamento);
            }
            else if (CB2.SelectedItem == "Deletar")
            {
                pag.deletar(id);
            }
            else if (CB2.SelectedItem == "Modificar")
            {
                pag.atualizar(id, data, situacao, null);
            }
        }

        private void DG1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CB3.SelectedItem == "Pagamentos dos funcionários")
                {
                    id = DG1.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
            }
            catch
            {
            }
            try
            {
                if (CB3.SelectedItem == "Funcionários")
                {
                    rg_pagamento = DG1.Rows[e.RowIndex].Cells[2].Value.ToString();
                }
            }
            catch
            {
            }
        }

        private void CB3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB3.SelectedItem == "Pagamentos dos funcionários")
            {
                CB4.Enabled = true;
            }
            else if (CB3.SelectedItem == "Funcionários")
            {
                CB4.Enabled = false;
                DG1.DataSource = pag.MostrarFunc();
            }
        }

        private void CB4_SelectedIndexChanged(object sender, EventArgs e)
        {
             pag = new PagamentoFuncionários();
             if (CB3.SelectedItem == "Pagamentos dos funcionários")
             {
                 CB4.Enabled = true;

                 if (CB4.SelectedItem == "PAGO")
                 {
                     DG1.DataSource = pag.filtros("P");
                 }
                 if (CB4.SelectedItem == "EM ANDAMENTO")
                 {
                     DG1.DataSource = pag.filtros("EA");
                 }
                 if (CB4.SelectedItem == "TODOS")
                 {
                     DG1.DataSource = pag.filtros("T");
                 }
             }
        }
    }
}
