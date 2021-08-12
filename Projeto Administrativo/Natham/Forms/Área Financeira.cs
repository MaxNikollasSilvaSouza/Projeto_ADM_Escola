using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projeto_Administrativo
{
    public partial class Área_Financeira : Form
    {
        PagamentoClientes novo;
        DataTable dt;
        String rg;
        string RG_logado;
        String id;
        String Nome_pessoa_logada;
        public Área_Financeira(string rgg, string nome )
        {
            InitializeComponent();
            R2.Checked = true;
            TxBoleto.Visible = false;
            TxCodPag.Visible = false;
            RG_logado = rgg;
            Nome_pessoa_logada = nome;
            Laluno.Checked = true;
        }

        private void Área_Financeira_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.ClearSelection();
                if (comboBox4.SelectedItem == "Filtros")
                {
                    TxBusc.Enabled = false;
                    TxBusc.Clear();
                    comboBox3.Enabled = true;
                }
                //Lembrete de datas de pagamento
                List<LembretePagamento> lista = new List<LembretePagamento>();
                novo = new PagamentoClientes();
                lista = novo.lembreteDPagamento("A");
                LBlembrete.Items.Clear();

            
                foreach (LembretePagamento a in lista)
                {
                    LBlembrete.Items.Add(a);
                }
            }
            catch { }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "BOLETO")
            {
                TxBoleto.Visible = true;
                TxCodPag.Visible = true;
            }
            else
            {
                TxBoleto.Visible = false;
                TxCodPag.Visible = false;
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                string rg_aluno = "";
                string rg_resp = "";
                string forma = comboBox2.Text;
                string cod_pag = null;
                string cod_bol = null;
                string data = dateTimePicker1.Text;
                string[] date = data.Split('/');
                data = date[2] + "-" + date[1] + "-" + date[0];

                novo = new PagamentoClientes();

                if (R2.Checked == true)
                {
                    rg_aluno = rg;
                    rg_resp = null;
                }
                else if (R1.Checked == true)
                {
                    rg_resp = rg;
                    rg_aluno = null;
                }
                if (comboBox2.SelectedItem == "BOLETO")
                {
                    cod_bol = TxBoleto.Text;
                    cod_pag = TxCodPag.Text;
                }
                if (comboBox5.SelectedItem == "Inserir")
                {
                    novo.pagamento(forma, data, cod_pag, cod_bol, comboBox1.SelectedItem.ToString(), rg_aluno, rg_resp);
                }
                else if (comboBox5.SelectedItem == "Deletar")
                {
                    novo.deletar(id);
                }
                else if (comboBox5.SelectedItem == "Modificar")
                {
                    novo.atualizar(id, data, cod_bol, cod_pag, comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString());
                }
            }
            catch { }
        }

        private void R2_CheckedChanged(object sender, EventArgs e)
        {
            string escolha = "A";
            novo = new PagamentoClientes();
            dataGridView1.DataSource = novo.MostrarPagantes(null, escolha);
        }

        private void R1_CheckedChanged(object sender, EventArgs e)
        {
            string escolha = "R";
            novo = new PagamentoClientes();
            dataGridView1.DataSource = novo.MostrarPagantes(null, escolha);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ao inves de jogar para o text box, jogar para uma variavel qualquer
                rg = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch
            {
            }
        }

        private void Laluno_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                List<LembretePagamento> lista = new List<LembretePagamento>();
                novo = new PagamentoClientes();
                lista = novo.lembreteDPagamento("A");
                LBlembrete.Items.Clear();


                foreach (LembretePagamento a in lista)
                {
                    LBlembrete.Items.Add(a);
                }
            }
            catch {  }
            label10.Text = "...";
            label11.Text = "...";
            label12.Text = "...";
            label9.Text = "...";
        }

        private void Lresponsavel_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                List<LembretePagamento> lista = new List<LembretePagamento>();
                novo = new PagamentoClientes();
                lista = novo.lembreteDPagamento("R");
                LBlembrete.Items.Clear();

            
                foreach (LembretePagamento a in lista)
                {
                    LBlembrete.Items.Add(a);
                }
            }
            catch { }
            label10.Text = "...";
            label11.Text = "...";
            label12.Text = "...";
            label9.Text = "...";
        }

        private void LBlembrete_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LembretePagamento novo = (LembretePagamento)LBlembrete.SelectedItem;
                label10.Text = novo.NOME.ToString();
                label11.Text = novo.VALOR.ToString();
                string rg = novo.RG.ToString();
                rg = rg.Replace("'", "");
                label12.Text = rg;
                label9.Text = novo.DIAP.ToString();
            }
            catch { }
        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox4.SelectedItem != "Filtros")
                {
                    comboBox3.Enabled = false;
                    comboBox3.SelectedItem = null;
                    TxBusc.Enabled = true;
                }
                else if (comboBox4.SelectedItem == "Filtros")
                {
                    TxBusc.Enabled = false;
                    TxBusc.Clear();
                    comboBox3.Enabled = true;
                }
            
            }
            catch { }
        }

        private void comboBox5_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {

                novo = new PagamentoClientes();
                if (comboBox5.SelectedItem == "Inserir")
                {
                    R1.Enabled = true;
                    R2.Enabled = true;
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = true;
                    dateTimePicker1.Enabled = true;
                    dataGridView1.DataSource = novo.MostrarPagantes(null, "A");
                }
                else if (comboBox5.SelectedItem == "Deletar")
                {
                    R1.Enabled = false;
                    R2.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    dataGridView1.DataSource = null;
                    //fazer ele mostrar todos os pagamentos
                    DG1.DataSource = novo.buscar("p", "", "A");
                    CB1.Text = "Aluno";
                    comboBox3.Text = "Pago";
                }
                else if (comboBox5.SelectedItem == "Modificar")
                {
                    R1.Enabled = false;
                    R2.Enabled = false;
                    dateTimePicker1.Enabled = true;
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = true;
                    dataGridView1.DataSource = null;
                    //fazer ele mostrar todos os pagamentos
                    DG1.DataSource = novo.buscar("p", "", "A");
                    CB1.Text = "Aluno";
                    comboBox3.Text = "Pago";
                }
            }
            catch(Exception f) {MessageBox.Show(f.ToString()); }
        }

        private void Bproximo_Click(object sender, EventArgs e)
        {
            Área_Financeira___Outros novo = new Área_Financeira___Outros(RG_logado,Nome_pessoa_logada);
            this.Hide();
            novo.Show();
        }

        private void BtnBusc_Click(object sender, EventArgs e)
        {

            string escolha = "A";
            string nome = TxBusc.Text;
            string i = "";
            DG1.DataSource = null;
            //Criar comando para fazer uma busca geral de todas as situaçoes de pagamentos
            novo = new PagamentoClientes();

            if (CB1.SelectedItem == "Responsável")
            {
                escolha = "R";
            }
            else if (CB1.SelectedItem == "Aluno")
            {
                escolha = "A";
            }
            if (comboBox4.SelectedItem == "Informações cadastrais")
            {
                i = "I";
            }
            if (comboBox4.SelectedItem == "Situação de pagamento individual")
            {
                i = "sp";
            }
            if (comboBox3.SelectedItem == "Pago")
            {
                i = "p";
            }
            if (comboBox3.SelectedItem == "Não pago")
            {
                i = "np";
            }
            if (comboBox3.SelectedItem == "Em andamento")
            {
                i = "ea";
            }
            if (comboBox3.SelectedItem == "Sem retorno")
            {
                i = "sr";
            }
            try
            {
                DG1.DataSource = novo.buscar(i, nome, escolha);
            }
            catch
            {
            }
        }

        private void DG1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (comboBox5.SelectedItem == "Modificar" || comboBox5.SelectedItem == "Deletar")
                {
                    if (comboBox4.SelectedItem != "Informações cadastrais")
                    {
                        id = DG1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    }
                }
            }
            catch
            {
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Home home = new Home(Nome_pessoa_logada, RG_logado);
            home.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Projecao_de_dados graf = new Projecao_de_dados(Nome_pessoa_logada, RG_logado);
            graf.Show();
        }

    }
}
