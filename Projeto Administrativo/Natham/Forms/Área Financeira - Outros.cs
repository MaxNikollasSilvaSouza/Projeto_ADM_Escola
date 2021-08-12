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
    public partial class Área_Financeira___Outros : Form
    {
        PagamentoFuncionários novo;
        GastosDiversos novo2;
        private string RG, Nome_logada;
        public Área_Financeira___Outros(string rgg,string nome)
        {
            InitializeComponent();
            novo = new PagamentoFuncionários();
            novo2 = new GastosDiversos();
            RG = rgg;
            Nome_logada = nome;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Pagamento_Funcionário pagamento = new Pagamento_Funcionário(RG);
            pagamento.TopLevel = false;
            panel1.Controls.Add(pagamento);
            pagamento.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            pagamento.Dock = DockStyle.Fill;
            pagamento.Show();
            //chama metodo que manda dados sobre funcionario para o datagrid
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Gastos_Diversos gasto = new Gastos_Diversos(RG,Nome_logada);
            gasto.TopLevel = false;
            panel1.Controls.Add(gasto);
            gasto.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            gasto.Dock = DockStyle.Fill;
            gasto.Show();
            //chama metodo que manda dados sobre gastos diversos para o datagrid
        }

        private void Área_Financeira___Outros_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Área_Financeira novo = new Área_Financeira(RG, Nome_logada);
            this.Close();
            novo.Show();
        }
    }
}
