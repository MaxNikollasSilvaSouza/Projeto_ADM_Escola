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
    public partial class Escala : Form
    {
        ClassEscala novo;
        string rgA;
        string rgP;
        string id;
        string rg_logado;
        string nome_logado;
        public Escala(string rg, string nome)
        {
            InitializeComponent();
            id = null;
            nome_logado = nome;
            rg_logado = rg;
        }

        public void block(string d)
        {
            if (d == "i")
            {
                ListAluno.Enabled = true;
                ListProfessor.Enabled = true;
                textBox1.Enabled = true;
                comboBox1.Enabled = true;
                CBinicio.Enabled = true;
                CBfim.Enabled = true;

                button2.Enabled = false;
                textBox2.Enabled = false;
                dataGridView1.Enabled = false;
                dataGridView1.DataSource = null; ;
            }
            else if (d == "d")
            {
                ListAluno.Enabled = false;
                ListProfessor.Enabled = false;
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
                CBinicio.Enabled = false;
                CBfim.Enabled = false;

                button2.Enabled = true;
                textBox2.Enabled = true;
                dataGridView1.Enabled = true;

                dataGridView1.DataSource = novo.buscar(1, "");
            }
        }

        private void Escala_Load(object sender, EventArgs e)
        {
            block("i");
            try
            {
                List<DadosAluno> lista = new List<DadosAluno>();
                novo = new ClassEscala();
                lista = novo.buscA();
                ListAluno.Items.Clear();


                foreach (DadosAluno a in lista)
                {
                    ListAluno.Items.Add(a);
                }
            }
            catch { }

            try
            {
                List<DadosProf> lista = new List<DadosProf>();
                novo = new ClassEscala();
                lista = novo.buscP();
                ListProfessor.Items.Clear();


                foreach (DadosProf a in lista)
                {
                    ListProfessor.Items.Add(a);
                }
            }
            catch { }
        }

        private void ListAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DadosAluno novo = (DadosAluno)ListAluno.SelectedItem;
                string rg = novo.RG.ToString();
                rg = rg.Replace("'", "");
                label4.Text = rg;
                label5.Text = novo.TIPOAULA.ToString();
                rgA = rg;
            }
            catch { }
        }

        private void ListProfessor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DadosProf novo = (DadosProf)ListProfessor.SelectedItem;
                string rg = novo.RG.ToString();
                rg = rg.Replace("'", "");
                rgP = rg;
            }
            catch { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (comboBox2.SelectedItem == "DELETAR")
                {
                    id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
            }
            catch
            {
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "INSERIR")
            {
                block("i");
            }
            else if (comboBox2.SelectedItem == "DELETAR")
            {
                block("d");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "INSERIR")
            {
                string dia = comboBox1.SelectedItem.ToString();
                string sala = textBox1.Text;
                string inicio = CBinicio.SelectedItem.ToString();
                string fim = CBfim.SelectedItem.ToString();
                novo = new ClassEscala();
                novo.cadastrar(inicio, fim, sala, dia, rgP, rgA);
            }
            else if (comboBox2.SelectedItem == "DELETAR")
            {
                if (id != null && id != "")
                {
                    novo = new ClassEscala();
                    novo.deletar(id);
                }
                else { MessageBox.Show("Não foi possível deletar o registro, por favor selecione abaixo um registro"); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            novo = new ClassEscala();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = novo.buscar(2, textBox2.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Home home = new Home(nome_logado, rg_logado);
            home.Show();
        }
    }
}
