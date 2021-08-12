using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace Projeto_Administrativo
{
    public partial class BuscarPorNome : Form
    {
        private bool selecionado = false;
        string valor;
         [DllImport("user32.dll")]
        static extern bool BlockInput(bool fBlockIt);
        private static Timer _timer = new Timer();

        static BuscarPorNome()
        {
            _timer.Tick +=new EventHandler(_timer_Tick);
        }

        private static void _timer_Tick(object sender, EventArgs e)
        {

        }

        public static void BlockInput(int ms)
        {
            BlockInput(true);
        }

        private string Nome_Pessoa_Logada;
        private string local_conexao = "server=localhost;user=root;database=mydb";
        MySqlConnection conexao; 
        private MySqlDataAdapter adapter;

        public BuscarPorNome(string Nome_Pessoa_Logada)
        {

            InitializeComponent();
            conexao = new MySqlConnection(local_conexao);
            selecionado = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //19/07/2020 - Tava fazendo algo aqui para retornar o rg da pessoa, mas nao me lembro o que eu estava fazendo.
            int i = e.ColumnIndex;
            int j = e.RowIndex;

            if (i == 0 && j == 0)
            {
                valor = dataGridView1[i, j].Value.ToString();
                Buscarrg(valor);
                
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                busca_nome(textBox1.Text);
            }
        }

        private void BuscarPorNome_Load(object sender, EventArgs e)
        {

        }

        public bool escolheu { get { return selecionado; } }

        public void fechar()
        {
          //  Home home = new Home();
            //home.Show();
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != null && textBox2.Text.Length > 5)
            {
                Buscarrg(textBox2.Text);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) == true)
            {

                switch (textBox2.TextLength)
                {
                    case 2:
                        textBox2.Text = textBox2.Text + ".";
                        textBox2.SelectionStart = 3;
                        break;
                    case 6:
                        textBox2.Text = textBox2.Text + ".";
                        textBox2.SelectionStart = 7;
                        break;

                    case 10:
                        textBox2.Text = textBox2.Text + "-";
                        textBox2.SelectionStart = 11;
                        break;

                }
            }
        }

      

        private void Buscarrg(string rg)
        {
            if(comboBox1.Text == "ALUNO")
            {
                try
                {
                    BlockInput(true);

                    string mensagem = "SELECT rg, nome_aluno, cpf, telefones, email, aulas_inicio, endereco, cep, numero_endereco,complemento, sexo, dia_pagamento, nascimento,tipo_aula, mensalidade, responsavel_rg  FROM aluno WHERE rg = '" + rg + "'";
                    MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                    //Aqui ele faz um SELECT e joga para o DataTable as informações do aluno          
                    try
                    {
                        conexao.Close();
                    }
                    catch { }
                    conexao.Open();

                    DataTable tabela_retorno = new DataTable();
                    cmd.ExecuteNonQuery();
                    //Aqui ele adapta o comando no DataTable (joga as informações que não tinham onde ficar na tablea pra a gente poder usar)
                    adapter = new MySqlDataAdapter(cmd);

                    adapter.Fill(tabela_retorno);
                    conexao.Close();
                    string teste = textBox2.Text;
                    try
                    {
                    pictureBox1.Load(@"C:\\Foto\\" + teste + ".jpg");
                    }
                    catch
                    {
                     MessageBox.Show("foto de estudante não encontrada.");
                    }
                    //Seta as informações do aluno
                    //tabela_retorno.Columns[0].DefaultValue = null;
                   // pictureBox1.Dispose();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = tabela_retorno;
                    BlockInput(false);

                    BlockInput(false);
                }
                catch
                {
                    BlockInput(false);
                    MessageBox.Show("Registro não encontrado.");
                    
                }
             }
            else if (comboBox1.Text == "FUNCIONARIO")
            {
                try
                {
                    BlockInput(true);

                    string mensagem = "SELECT funcionario.rg, funcionario.nome_funcionario, info_trabalho.dia_semana, info_trabalho.entrada,info_trabalho.inicio_intervalo, info_trabalho.fim_intervalo, info_trabalho.saida,    funcionario.cpf, funcionario.pdc, funcionario.n_carteira, funcionario.sigla, funcionario.telefones, funcionario.email, funcionario.endereco, funcionario.numero_endereco, funcionario.cep, funcionario.complemento, funcionario.nascimento, funcionario.funcao, funcionario.setor, funcionario.sexo, funcionario.quem_registro, funcionario.quando_registro, funcionario.quem_atualizou, funcionario.quando_atualizou, funcionario_financa.pis,  funcionario_financa.agencia,  funcionario_financa.n_conta,  funcionario_financa.banco,  funcionario_financa.salario, ocorrencias_func.motivo, ocorrencias_func.registrado, ocorrencias_func.descricao   FROM funcionario, funcionario_financa, info_trabalho WHERE funcionario.rg = '" + rg + "' and funcionario_financa.funcionario_rg = funcionario.rg and info_trabalho.funcionario_rg = funcionario.rg and ocorrencias_func.funcionario_rg = funcionario.rg";
                    MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                    //Aqui ele faz um SELECT e joga para o DataTable as informações do funcionario  
                    try
                    {
                        conexao.Close();
                    }
                    catch { }
                    conexao.Open();

                    DataTable tabela_retorno = new DataTable();
                    cmd.ExecuteNonQuery();
                    //Aqui ele adapta o comando no DataTable (joga as informações que não tinham onde ficar na tablea pra a gente poder usar)
                    adapter = new MySqlDataAdapter(cmd);

                    adapter.Fill(tabela_retorno);
                    conexao.Close();
                    string teste = textBox2.Text;
                    try
                    {
                        pictureBox1.Load(@"C:\\Foto\\" + teste + ".jpg");
                    }
                    catch
                    {
                        MessageBox.Show("foto de estudante não encontrada.");
                    }
                    //Seta as informações do aluno
                    //tabela_retorno.Columns[0].DefaultValue = null;
                    // pictureBox1.Dispose();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = tabela_retorno;
                    
                    BlockInput(false);

                    BlockInput(false);
                }
                catch(Exception e)
                {
                    BlockInput(false);
                    MessageBox.Show("Registro não encontrado.");

                }
            }
            else if (comboBox1.Text == "RESPONSAVEL")
            {
                try
                {
                    BlockInput(true);

                    string mensagem = "SELECT responsavel.rg, nome_responsavel, cpf, telefones, email, parentesco, endereco, numero_endereco, cep, complemento, dia_pagamento, mensalidade, quem_registro, quando_registro, quem_atualizou, quando_atualizou FROM responsavel WHERE rg = '" + rg + "'";
                    MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                    //Aqui ele faz um SELECT e joga para o DataTable as informações do responsavel
                    try
                    {
                        conexao.Close();
                    }
                    catch { }
                    conexao.Open();

                    DataTable tabela_retorno = new DataTable();
                    cmd.ExecuteNonQuery();
                    //Aqui ele adapta o comando no DataTable (joga as informações que não tinham onde ficar na tablea pra a gente poder usar)
                    adapter = new MySqlDataAdapter(cmd);

                    adapter.Fill(tabela_retorno);
                    conexao.Close();
                    string teste = textBox2.Text;
                    try
                    {
                        pictureBox1.Load(@"C:\\Foto\\" + teste + ".jpg");
                    }
                    catch
                    {
                        MessageBox.Show("foto de estudante não encontrada.");
                    }
                    //Seta as informações do aluno
                    //tabela_retorno.Columns[0].DefaultValue = null;
                    // pictureBox1.Dispose();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = tabela_retorno;

                    BlockInput(false);

                    BlockInput(false);
                }
                catch
                {
                    BlockInput(false);
                    MessageBox.Show("Registro não encontrado.");

                }
            }
            else
            {
                MessageBox.Show("Selecione um opção válida para ser buscado.");
            }
        }


        private void busca_nome(string nome)
        {
            if(comboBox1.Text == "ALUNO")
            {
                try
                {

                    BlockInput(true);
                    string verifica = "SELECT rg as 'RG', nome_aluno as 'Nome', cpf as 'CPF', telefones as 'Telefone', email as 'E-mail', aulas_inicio as 'Data de inicio', endereco as 'Endereco', cep as 'CEP', numero_endereco as 'Numero da casa',complemento as 'Complemento', sexo as 'Sexo Biologico', dia_pagamento as 'Data Limite para Pagamento', aluno.nascimento as 'Data de Nascimento',aluno.tipo_aula as 'Tipo de Aula', aluno.mensalidade as 'Valor da Mensalidade', responsavel_rg as 'RG do Responsavel' FROM aluno WHERE nome_aluno like '%" + textBox1.Text + "%'";
                    MySqlCommand cmd = new MySqlCommand(verifica, conexao);
                    BlockInput(true);
                    //conectar com o banco
                    try
                    {
                        conexao.Close();
                    }
                    catch { }
                    conexao.Open();


                    //executar comando                
                    cmd.ExecuteNonQuery();

                    conexao.Close();

                    adapter = new MySqlDataAdapter(cmd);
                    DataTable tabela_retorno = new DataTable();
                    adapter.Fill(tabela_retorno);


                    //tabela_retorno.Columns[0].DefaultValue = null;

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = tabela_retorno;
                    BlockInput(false);

                    //try
                    //{
                    //    pictureBox1.Load(@"C:\\Foto\\" + tabela_retorno.Rows[0][0].ToString() + ".jpg");
                    //    // pictureBox1.Dispose();
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("foto de estudante não encontrada.");
                    //}
                }
                catch (Exception f)
                {
                    erro(f.ToString());
                    BlockInput(false);
                }
            }
            else if (comboBox1.Text == "RESPONSAVEL")
            {
                try
                {

                    BlockInput(true);
                    string verifica = "SELECT rg as 'RG', nome_responsavel as 'Nome', cpf as 'CPF', telefones as 'Telefone', email as 'E-mail', parentesco as 'Parentesco', endereco as 'Endereco', cep as 'CEP', numero_endereco as 'Numero da casa',complemento as 'Complemento', mensalidade as 'Mensalidade', dia_pagamento as 'Data Limite para Pagamento', quem_registro as 'Quem registrou', quando_registro as 'Quando registrou', quem_atualizou 'Quem atualizou', quando_atualizou as 'Quando atualizou'  FROM responsavel WHERE nome_responsavel like '%" + textBox1.Text + "%'";
                    MySqlCommand cmd = new MySqlCommand(verifica, conexao);
                    BlockInput(true);
                    //conectar com o banco
                    try
                    {
                        conexao.Close();
                    }
                    catch { }
                    conexao.Open();


                    //executar comando                
                    cmd.ExecuteNonQuery();

                    conexao.Close();

                    adapter = new MySqlDataAdapter(cmd);
                    DataTable tabela_retorno = new DataTable();
                    adapter.Fill(tabela_retorno);


                    //tabela_retorno.Columns[0].DefaultValue = null;

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = tabela_retorno;
                    BlockInput(false);

                    //try
                    //{
                    //    pictureBox1.Load(@"C:\\Foto\\" + tabela_retorno.Rows[0][0].ToString() + ".jpg");
                    //    // pictureBox1.Dispose();
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("foto de estudante não encontrada.");
                    //}
                }
                catch (Exception f)
                {
                    erro(f.ToString());
                    BlockInput(false);
                }
            }

            else if (comboBox1.Text == "FUNCIONARIO")
            {
                try
                {

                    BlockInput(true);
                    string verifica = "SELECT funcionario.rg as 'RG', funcionario.nome_funcionario as 'Nome', info_trabalho.dia_semana as 'Dia da semana', info_trabalho.entrada as 'Entrada',info_trabalho.inicio_intervalo as 'Inicio do intervalo', info_trabalho.fim_intervalo as 'Fim do intervalo', info_trabalho.saida as 'Fim do expediente', funcionario.cpf as 'CPF', funcionario.pdc as 'PCD', funcionario.n_carteira as 'Numero da carteira de trabalho', funcionario.sigla as 'Sigla', funcionario.telefones as 'Telefones', funcionario.email as 'Email', funcionario.endereco as 'Endereco', funcionario.numero_endereco as 'Numero da residencia', funcionario.cep as 'CEP', funcionario.complemento as 'Complemento', funcionario.nascimento as 'Nascimento', funcionario.funcao as 'Funcao', funcionario.setor as 'Setor', funcionario.sexo as 'Sexo', funcionario.quem_registro as 'Quem registrou', funcionario.quando_registro as 'Quando registrou', funcionario.quem_atualizou as 'Quem atualizou', funcionario.quando_atualizou as 'Quando atualizou' FROM funcionario, info_trabalho WHERE nome_funcionario like '%" + textBox1.Text + "%' and info_trabalho.funcionario_rg = funcionario.rg";
                    MySqlCommand cmd = new MySqlCommand(verifica, conexao);
                    BlockInput(true);
                    //conectar com o banco
                    try
                    {
                        conexao.Close();
                    }
                    catch { }
                    conexao.Open();


                    //executar comando                
                    cmd.ExecuteNonQuery();

                    conexao.Close();

                    adapter = new MySqlDataAdapter(cmd);
                    DataTable tabela_retorno = new DataTable();
                    adapter.Fill(tabela_retorno);


                    //tabela_retorno.Columns[0].DefaultValue = null;

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = tabela_retorno;
                    BlockInput(false);

                    try
                    {
                        pictureBox1.Load(@"C:\\Foto\\" + tabela_retorno.Rows[0][0].ToString() + ".jpg");
                        // pictureBox1.Dispose();
                    }
                    catch
                    {
                        MessageBox.Show("foto de estudante não encontrada.");
                    }
                }
                catch (Exception f)
                {
                    erro(f.ToString());
                    BlockInput(false);
                }
            }
            else { }
        }

        private void erro(string e)
        {
            MessageBox.Show("Não executado pelo seguinte erro: " + e.ToString());
        }




        }
    }

