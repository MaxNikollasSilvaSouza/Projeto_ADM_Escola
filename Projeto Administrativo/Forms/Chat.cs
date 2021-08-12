using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projeto_Administrativo
{
    public partial class Chat : Form
    {
        string checagem;
        private string Nome_Pessoa_Logada;
        MySqlDataAdapter adapter;
        private string usuario;
        private string senha;
        private string RG;
        private string local_conexao = "server=localhost;user=root;database=mydb";
        MySqlConnection conexao;
        MySqlCommand cmd;

        public Chat(string Nome_Pessoa_Logada,string rg)
        {
            InitializeComponent();
            this.Nome_Pessoa_Logada = Nome_Pessoa_Logada;
            Dia.Text = DateTime.Now.Day.ToString();
            Mes.Text = DateTime.Now.Month.ToString();
            Ano.Text = DateTime.Now.Year.ToString();
            RG = rg;
            conexao = new MySqlConnection(local_conexao);
            select_msg_semana();
            

        }
        

        private void Chat_Load(object sender, EventArgs e)
        {
           
        }

        public void receber(string direcionamento, string assunto, string mensagem, string dia, string mes, string ano)
        {
            TB_direcionamento.Text = direcionamento;
            TB_assunto.Text = assunto;
            Mensagem.Text = mensagem;
            Dia.Text = dia;
            Mes.Text = mes;
            Ano.Text = ano;
        }
        public void enviar()
        {
            try
            {
                string mensagem = "INSERT INTO notificacao (assunto, mensagem, data_notificacao, direcionamento,visto) values(@assunto, @mensagem, @data_notificacao, @direcionamento,@visto)";

                cmd = new MySqlCommand(mensagem, conexao);
                conexao.Open();
                cmd.Parameters.AddWithValue("assunto", TB_assunto.Text);
                cmd.Parameters.AddWithValue("mensagem", Mensagem.Text);
                cmd.Parameters.AddWithValue("data_notificacao", Ano.Text + "-" + Mes.Text + "-" + Dia.Text);
                cmd.Parameters.AddWithValue("direcionamento", TB_direcionamento.Text);
                cmd.Parameters.AddWithValue("visto", "F");
                cmd.ExecuteNonQuery();
                conexao.Close();
                MessageBox.Show("Mensagem enviada");
            }
            catch
            {
                MessageBox.Show("Devido a algum erro a mensagem não pôde ser enviada.");
            }

        }

        private void Bresponder_Click(object sender, EventArgs e)
        {
            enviar();
        }

        private void TB_direcionamento_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) == true)
            {

                switch (TB_direcionamento.TextLength)
                {
                    case 2:
                        TB_direcionamento.Text = TB_direcionamento.Text + ".";
                        TB_direcionamento.SelectionStart = 3;
                        break;
                    case 6:
                        TB_direcionamento.Text = TB_direcionamento.Text + ".";
                        TB_direcionamento.SelectionStart = 7;
                        break;

                    case 10:
                        TB_direcionamento.Text = TB_direcionamento.Text + "-";
                        TB_direcionamento.SelectionStart = 11;
                        break;

                }
            }
        }

        private void select_msg_semana()
        {
            try
            {

                string comando = "SELECT direcionamento as 'Direcionamento', assunto as 'Assunto', mensagem as 'Mensagem', data_notificacao as 'Data'  FROM notificacao WHERE direcionamento = '" + RG + "' AND visto = 'V' ORDER BY data_notificacao desc";
                MySqlCommand cmd = new MySqlCommand(comando, conexao);

                try
                {
                    conexao.Close();
                }
                catch { }
                //conectar com o banco
                conexao.Open();


                //executar comando                
                cmd.ExecuteNonQuery();

                conexao.Close();

                adapter = new MySqlDataAdapter(cmd);
                DataTable tabela_retorno = new DataTable();
                adapter.Fill(tabela_retorno);
                try
                {
                    checagem = tabela_retorno.Rows[0][1].ToString();

                    if (checagem != null && checagem != "")
                    {
                        string direcionamento = tabela_retorno.Rows[0][0].ToString();
                        string assunto = tabela_retorno.Rows[0][1].ToString();
                        string mensagem = tabela_retorno.Rows[0][2].ToString();
                        string[] data = tabela_retorno.Rows[0][3].ToString().Split('/');
                        string[] anopuro = data[2].Split(' ');

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = tabela_retorno;
                        dataGridView1.Refresh();
                    }

                }
                catch { }
            }
            catch { }
        }




    }
}
