using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using MySql.Data.MySqlClient;
//using System.IO;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using MySql.Data.MySqlClient;
//using System.IO;
//using System.Data;
//using System.Runtime.InteropServices;
//using System.Windows.Forms;

namespace Projeto_Administrativo
{
    public partial class Login : Form
    {
        //string p1 = "max";
        //string p2 = "0000";
        //string p3 = "99.999.999-9";
        bool identidade_confirmada = false;
        ClasseTLogin mensagens;
        //string Local;
        public Login()
        {
            InitializeComponent();
            mensagens = new ClasseTLogin();
            identidade_confirmada = false;
           //Local = "server=localhost;user=root;database=mydb";
        }
        
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    MySqlConnection conexao = new MySqlConnection(Local);

            //   // string mensagem = "INSERT INTO login (usuario, senha, funcionario_rg)values(@usuario, @senha, @funcionario_rg)";
            //    string mensagem = "INSERT INTO login (usuario, senha)values(@usuario, @senha)";


            //    MySqlCommand cmd = new MySqlCommand(mensagem, conexao);


            //    conexao.Open();

            //    cmd.Parameters.AddWithValue("@usuario", this.p1);
            //    cmd.Parameters.AddWithValue("@senha", this.p2);
            //   // cmd.Parameters.AddWithValue("@funcionario_rg", this.p3);

            //    cmd.ExecuteNonQuery();
            //    //desconectar
            //    conexao.Close();
            //}
            //catch (Exception o) { MessageBox.Show(o.ToString()); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (identidade_confirmada == true)
            {
               
                mensagens.verificar_chat();
            }
        }

        private void Bconectar_Click(object sender, EventArgs e)
        {
            identidade_confirmada = mensagens.verificar_usuario(TB_usuario.Text, TB_senha.Text);
            if (identidade_confirmada == true)
            {
                string nome_da_pessoa = mensagens.getNome_Logado;
                string rg = mensagens.getRG;
                Home cadastro = new Home(nome_da_pessoa,rg);
              
                this.Hide();
                timer1.Enabled = true;
                cadastro.Show();
            }
        }
    }
}
