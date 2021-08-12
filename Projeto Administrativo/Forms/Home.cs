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
    public partial class Home : Form
    {
        private string RG_Logado;
        private string Nome_Pessoa_Logada;
        public Home(String pessoa_Logada, string rg)
        {
            try
            {
                InitializeComponent();
                Nome_Pessoa_Logada = pessoa_Logada;
                RG_Logado = rg;
                label2.Text = Nome_Pessoa_Logada;
                try
                {
                    pictureBox1.Load(@"C:\\Foto\\" + rg + ".jpg");
                }
                catch { MessageBox.Show("Imagem do funcionário não encontrada."); pictureBox1.Dispose(); }
                //pictureBox1.Dispose();
            }
            catch
            {
                
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Cadastro cadastro = new Cadastro(Nome_Pessoa_Logada,RG_Logado);
            cadastro.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Funcionario funcionario = new Funcionario(Nome_Pessoa_Logada,RG_Logado);
            funcionario.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BuscarPorNome busca = new BuscarPorNome(Nome_Pessoa_Logada);
            busca.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Chat conversa = new Chat(Nome_Pessoa_Logada,RG_Logado);
            conversa.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Área_Financeira gastodiverso = new Área_Financeira(RG_Logado, Nome_Pessoa_Logada);
            gastodiverso.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            AreaProfessor professor = new AreaProfessor(Nome_Pessoa_Logada, RG_Logado);
            professor.Show(); 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Escala escala = new Escala(RG_Logado, Nome_Pessoa_Logada);
            escala.Show();
        }

        

        

       
    }
}
