using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace Projeto_Administrativo
{
    public partial class AreaProfessor : Form
    {
        private string local_conexao = "server=localhost;user=root;database=mydb";
        MySqlConnection conexao; 

        private string desejado;
        private string Nome_pessoa_logada;
        string RG_logado;
        Areaporofessor prof;
        public AreaProfessor(string nome_logado,string rgg_logado)
        {
            InitializeComponent();
            this.Nome_pessoa_logada = nome_logado;
            this.RG_logado = rgg_logado;
            TBaluno_rg.Visible = false;
            Lnome.Visible = false;
            prof = new Areaporofessor(Nome_pessoa_logada, RG_logado);

            Lgrupo.Visible = false;
            TBgrupo.Visible = false;

            Ldata.Visible = false;
            dateTimePicker1.Visible = false;

            Linicio.Visible = false;
            CBinicio.Visible = false;

            Lfim.Visible = false;
            CBfim.Visible = false;

            Lav.Visible = false;
            TBav.Visible = false;

            Lnota.Visible = false;
            Nnota.Visible = false;

            Lpresente.Visible = false;
            RBsim.Visible = false;
            RBnao.Visible = false;

            conexao = new MySqlConnection(local_conexao);
        }

        private void AreaProfessor_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pesquisa();
        }

        private void pesquisa()
        {
            string grupo = TBfgrupo.Text;
            string horario = TBfhorario.Text;
            string aluno = TBfaluno.Text;
            string nota = TBfnota.Text;

            if (desejado == "REMARCACAO")
            {
                bool x1 = false;
                bool x2 = false;

                if (aluno != "")
                {
                    x1 = true;
                }

                if (horario != "")
                {
                    x2 = true;
                }
                string mensagem = "Select marcar_aula.data_aula as 'Data da aula', marcar_aula.inicio_aula as 'Inicio', marcar_aula.fim_aula as 'Fim', aluno.nome_aluno as 'Nome do aluno', marcar_aula.aluno_rg as 'RG do aluno', funcionario.nome_funcionario as 'Nome do funcionario', marcar_aula.funcionario_rg as 'RG do funcionario' from marcar_aula, aluno, funcionario WHERE ";
                if (x1 == true && x2 == true)
                {
                    mensagem = mensagem + "marcar_aula.aluno_rg = '" + aluno + "' and inicio_aula = '" + horario + "' and aluno.rg = marcar_aula.aluno_rg and funcionario.rg = marcar_aula.funcionario_rg ";

                }
                else if (x1 == true)
                {
                    mensagem = mensagem + "marcar_aula.aluno_rg = '" + aluno + "' and aluno.rg = marcar_aula.aluno_rg and funcionario.rg = marcar_aula.funcionario_rg ";
                }
                else if (x2 == true)
                {
                    mensagem = mensagem + "inicio_aula = '" + horario + "' and funcionario.rg = marcar_aula.funcionario_rg ";
                }
                else
                {
                    mensagem = "Select marcar_aula.data_aula as 'Data', marcar_aula.inicio_aula as 'Inicio', marcar_aula.fim_aula as 'Fim', aluno.nome_aluno as 'Nome do aluno', marcar_aula.aluno_rg as 'RG do aluno', funcionario.nome_funcionario as 'Nome do funcionario', marcar_aula.funcionario_rg as 'RG do funcionario' from marcar_aula, aluno, funcionario where funcionario.rg = marcar_aula.funcionario_rg and marcar_aula.aluno_rg = aluno.rg ";
                }

                try
                {

                    MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                    DataTable tabela = new DataTable();
                    try
                    {
                        conexao.Close();
                    }
                    catch { }

                    conexao.Open();
                    cmd.ExecuteNonQuery();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(tabela);
                    conexao.Close();
                    try
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = tabela;
                        dataGridView1.Refresh();
                    }
                    catch { }

                }
                catch (Exception k) { erro(k.ToString()); }
            }
            else if (desejado == "NOTAS")
            {
                bool x1 = false;
                bool x2 = false;
               
                if (aluno != "")
                {
                    x1 = true;
                }

                if (grupo != "")
                {
                    x2 = true;
                }

                string mensagem = "Select notas.obs_nota as 'Nome da avaliacao', notas.nota as 'Nota', notas.data as 'Data', aluno.nome_aluno as 'Nome do aluno', notas.aluno_rg as 'RG do aluno' from notas, aluno, escala where ";
                if (x1 == true && x2 == true )
                {

                    mensagem = mensagem + "notas.aluno_rg = '" + aluno + "' and escala.sala = '" + grupo + "' and aluno.rg = notas.aluno_rg";
                }

                else if (x1 == true)
                {

                    mensagem = mensagem + "notas.aluno_rg = '" + aluno + "' and aluno.rg = notas.aluno_rg ";
                }

                else if (x2 == true)
                {
                    mensagem = mensagem + " escala.sala = '" + grupo + "' ";

                }
                else
                {
                    mensagem = "Select aluno.nome_aluno as 'Nome do aluno', notas.nota as 'Nota', notas.obs_nota as 'Nome da avaliacao', notas.data as 'Data', notas.aluno_rg as 'RG do aluno' from notas, aluno where notas.aluno_rg = aluno.rg";
                }

                try
                {
                    try
                    {
                        conexao.Close();
                    }
                    catch { }

                    MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                    DataTable tabela = new DataTable();
                    try { conexao.Close(); }
                    catch { }
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                    conexao.Close();

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(tabela);
                    try
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = tabela;
                        dataGridView1.Refresh();
                    }
                    catch { }


                }
                catch (Exception j) { erro(j.ToString()); }


            }

            else if (desejado == "PRESENCA")
            {
                bool x1 = false;
                bool x2 = false;

                if (aluno != "")
                {
                    x1 = true;
                }
                if (grupo != "")
                {
                    x2 = true;
                }




                string mensagem = "Select  aluno.nome_aluno as 'Nome do aluno', presenca.aluno_rg as 'RG do aluno', presenca.ano as 'Ano', presenca.mes as 'Mes', presenca.faltas as 'Faltas', presenca.presencas as 'Presencas' from presenca, aluno, escala where ";
                if (x1 == true && x2 == true)
                {

                    mensagem = mensagem + "presenca.aluno_rg = '" + aluno + "' and aluno.rg = presenca.aluno_rg and escala.classe = '" + grupo + "' ";
                }
                else if (x1 == true)
                {
                    mensagem = mensagem + "presenca.aluno_rg = '" + aluno + "' and aluno.rg = presenca.aluno_rg";
                }
                else if (x2 == true)
                {
                    mensagem = mensagem + " escala.classe = '" + grupo + "' ";
                }
                else
                {
                    //corrigir select, colocar nome do aluno
                    mensagem = "Select ano as 'Ano', mes as 'Mes', faltas as 'Faltas', presencas as 'Presencas' from presenca";
                }

                try
                {
                    try
                    {
                        conexao.Close();
                    }
                    catch { }

                    MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                    DataTable tabela = new DataTable();
                    try { conexao.Close(); }
                    catch { }
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                    conexao.Close();

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(tabela);
                    try
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = tabela;
                        dataGridView1.Refresh();
                    }
                    catch { }


                }
                catch (Exception j) { erro(j.ToString()); }
            }
            else if (desejado == "ESCALA")
            {
                string mensagem = "select a.nome_aluno, e.dia_semana, e.inicio, e.fim, e.sala from escala as e join aluno as a on e.aluno_rg = a.rg join funcionario as f on e.funcionario_rg = f.rg where e.funcionario_rg = '"  + RG_logado + "' ";
                
                try
                {
                    try
                    {
                        conexao.Close();
                    }
                    catch { }

                    MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                    DataTable tabela = new DataTable();
                    try { conexao.Close(); }
                    catch { }
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                    conexao.Close();

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(tabela);
                    try
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = tabela;
                        dataGridView1.Refresh();
                    }
                    catch { }


                }
                catch (Exception j) { erro(j.ToString()); }
            }
        }

        private void BTsalvar_Click(object sender, EventArgs e)
        {
            if (desejado == "REMARCACAO")
            {

                string[] vetor = dateTimePicker1.Text.Split('/');
                string dia = vetor[2] + "-" + vetor[1] + "-" + vetor[0];
                prof.setar_marcar_aula(dia, CBinicio.Text, CBfim.Text, TBaluno_rg.Text, RG_logado);
                prof.checagem_remarcacao("SALVAR");
            }

            else if (desejado == "NOTAS")
            {
                string[] vetor = dateTimePicker1.Text.Split('/');
                string dia = vetor[2] + "-" + vetor[1] + "-" + vetor[0];
                prof.setar_data_para_atualizar(dia);
                prof.setar_notas(TBaluno_rg.Text, TBav.Text, Convert.ToDouble(Nnota.Value), dia);
                prof.checagem_notas("SALVAR");
            }
            else if (desejado == "PRESENCA")
            {
                string t = "";
                int dia = DateTime.Now.Day;
                if (RBsim.Checked == true)
                {
                    t = "sim";
                }
                else if (RBnao.Checked == true)
                {
                    t = "nao";
                }
                prof.presenca(dia.ToString(), TBaluno_rg.Text, t);
         
            }

            else 
            {
                MessageBox.Show("Selecione uma função");
            }
        }

        private void erro(string e)
        {
            MessageBox.Show("Devido a algum erro não foi possível efetuar o cadastro: \n\n" + e); 
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Home home = new Home(Nome_pessoa_logada, RG_logado);
            home.Show();
        }

        private void BTatualizar_Click(object sender, EventArgs e)
        {
            if (desejado == "REMARCACAO")
            {

                string[] vetor = dateTimePicker1.Text.Split('/');
                string dia = vetor[2] + "-" + vetor[1] + "-" + vetor[0];
                prof.setar_data_para_atualizar(dia);
                prof.setar_marcar_aula(dia, CBinicio.Text, CBfim.Text, TBaluno_rg.Text, RG_logado);
                prof.checagem_remarcacao("ATUALIZAR");
            }

            else if (desejado == "NOTAS")
            {
                string[] vetor = dateTimePicker1.Text.Split('/');
                string dia = vetor[2] + "-" + vetor[1] + "-" + vetor[0];
                prof.setar_data_para_atualizar(dia);
                prof.setar_notas(TBaluno_rg.Text, TBav.Text, Convert.ToDouble(Nnota.Value), dia);
                prof.checagem_notas("ATUALIZAR");
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            pesquisa();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == "REMARCACAO")
            {
                desejado = "REMARCACAO";
                Lnome.Visible = true;
                TBaluno_rg.Visible = true;

                Lgrupo.Visible = true;
                TBgrupo.Visible = true;

                Ldata.Visible = true;
                dateTimePicker1.Visible = true;

                Linicio.Visible = true;
                CBinicio.Visible = true;
                Lfim.Visible = true;
                CBfim.Visible = true;

                TBgrupo.Visible = false;
                Lgrupo.Visible = false;

                if (TBaluno_rg.Text.Length > 5 && TBgrupo.Text.Length > 0 && CBinicio.Text.Length > 2)
                {
                    //função de cadastro no banco
                }

                Lav.Visible = false;
                TBav.Visible = false;
                Lnota.Visible = false;
                Nnota.Visible = false;
                Lpresente.Visible = false;
                RBnao.Visible = false;
                RBsim.Visible = false;

                TBfnota.Enabled = false;
                TBfnota.Text = null;

                TBfgrupo.Enabled = false;
                TBfgrupo.Text = null;

                TBfhorario.Enabled = true;
                TBfaluno.Enabled = true;
                panel1.Enabled = true;
            }

            else if (listBox1.SelectedItem == "NOTAS")
            {
                desejado = "NOTAS";
                Lnome.Visible = true;
                TBaluno_rg.Visible = true;


                Lgrupo.Visible = true;
                TBgrupo.Visible = true;

                Ldata.Visible = true;
                dateTimePicker1.Visible = true;

                Linicio.Visible = false;
                CBinicio.Visible = false;
                Lfim.Visible = false;
                CBfim.Visible = false;


                Lav.Visible = true;
                TBav.Visible = true;


                Lnota.Visible = true;
                Nnota.Visible = true;

                Lpresente.Visible = false;
                RBnao.Visible = false;
                RBsim.Visible = false;

                TBfnota.Enabled = false;
                TBfnota.Text = null;
                TBfgrupo.Enabled = true;
                TBfhorario.Enabled = false;
                TBfhorario.Text = null;
                TBfaluno.Enabled = true;
                panel1.Enabled = true;
            }
            else if (listBox1.SelectedItem == "PRESENCA")
            {
                panel1.Enabled = true;
                desejado = "PRESENCA";
                Lnome.Visible = true;
                TBaluno_rg.Visible = true;

                Lgrupo.Visible = true;
                TBgrupo.Visible = true;

                Ldata.Visible = true;
                dateTimePicker1.Visible = true;

                Lpresente.Visible = true;
                RBnao.Visible = true;
                RBsim.Visible = true;

                Lav.Visible = false;
                TBav.Visible = false;

                Lnota.Visible = false;
                Nnota.Visible = false;

                Linicio.Visible = false;
                CBinicio.Visible = false;
            }
            else if (listBox1.SelectedItem == "ESCALA")
            {
                desejado = "ESCALA";
                panel1.Enabled = false;
            }
        }

        private void TBaluno_rg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) == true)
            {

                switch (TBaluno_rg.TextLength)
                {
                    case 2:
                        TBaluno_rg.Text = TBaluno_rg.Text + ".";
                        TBaluno_rg.SelectionStart = 3;
                        break;
                    case 6:
                        TBaluno_rg.Text = TBaluno_rg.Text + ".";
                        TBaluno_rg.SelectionStart = 7;
                        break;

                    case 10:
                        TBaluno_rg.Text = TBaluno_rg.Text + "-";
                        TBaluno_rg.SelectionStart = 11;
                        break;

                }
            }
        }

        private void TBfaluno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) == true)
            {

                switch (TBfaluno.TextLength)
                {
                    case 2:
                        TBfaluno.Text = TBfaluno.Text + ".";
                        TBfaluno.SelectionStart = 3;
                        break;
                    case 6:
                        TBfaluno.Text = TBfaluno.Text + ".";
                        TBfaluno.SelectionStart = 7;
                        break;

                    case 10:
                        TBfaluno.Text = TBfaluno.Text + "-";
                        TBfaluno.SelectionStart = 11;
                        break;

                }
            }
        }

        private void CBfim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (CBfim.Text.Length)
                {
                    case 2:
                        CBfim.Text = CBfim.Text + ":";
                        CBfim.SelectionStart = 4;
                        break;
                }
            }
            else
            {
                CBfim.Text = null;
            }
        }

        private void CBinicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (CBinicio.Text.Length)
                {
                    case 2:
                        CBinicio.Text = CBinicio.Text + ":";
                        CBinicio.SelectionStart = 4;
                        break;
                }
            }
            else
            {
                CBinicio.Text = null;
            }
        }

        
    }
}
