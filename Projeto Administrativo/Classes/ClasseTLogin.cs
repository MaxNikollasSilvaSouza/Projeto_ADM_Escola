using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Projeto_Administrativo
{
    public class ClasseTLogin
    {
       
        bool Usuario_veridico = false;
        string checagem;
        MySqlDataAdapter adapter;
        private string usuario;
        private string senha;
        private string RG;
        private string local_conexao =  "server=localhost;user=root;database=mydb";
        MySqlConnection conexao;
        string dia = DateTime.Now.Day.ToString();
        string mes = DateTime.Now.Month.ToString();
        string ano = DateTime.Now.Year.ToString();
        string Nome_Funcionario_Logado;
        public ClasseTLogin() {conexao = new MySqlConnection(local_conexao);}

        public bool verificar_usuario(string usuario, string senha)
        {
            if (usuario != null && usuario != "" && senha != null && senha != "")
            {
                try
                {
                    DataTable tabela_retorno = new DataTable();
                    string verifica = "SELECT usuario, senha, funcionario_rg FROM login WHERE usuario = '" + usuario + "' AND senha = '" + senha + "' ";
                    MySqlCommand cmd = new MySqlCommand(verifica, conexao);

                    //conectar com o banco
                    conexao.Open();


                    //executar comando                
                    cmd.ExecuteNonQuery();

                    conexao.Close();

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(tabela_retorno);
                    RG = tabela_retorno.Rows[0][2].ToString();

                    //if (RG != "" && RG != null)
                    //{
                    //    Usuario_veridico = true;
                    //}
                    if (RG != "" && RG != null)
                    {
                        Usuario_veridico = true;

                        tabela_retorno = new DataTable();
                        string mensagem = "SELECT nome_funcionario FROM funcionario WHERE rg = '" + RG + "' ";
                        cmd = new MySqlCommand(mensagem, conexao);

                        //conectar com o banco
                        conexao.Open();


                        //executar comando                
                        cmd.ExecuteNonQuery();

                        conexao.Close();

                        adapter = new MySqlDataAdapter(cmd);
                        tabela_retorno.Clear();
                        adapter.Fill(tabela_retorno);
                        Nome_Funcionario_Logado = tabela_retorno.Rows[0][0].ToString();
                    }
                }
                catch
                {
                    MessageBox.Show("Usuário ou senha incorretos, incapaz de continuar.");
                    Usuario_veridico = false;
                }
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos, incapaz de continuar.");
                Usuario_veridico = false;
            }
        
            return Usuario_veridico;
        }
        int semana_passado;
        public void verificar_chat()
        {
            try
            {

                string verifica = "SELECT direcionamento, assunto, mensagem, data_notificacao, id_notificacao  FROM notificacao WHERE direcionamento = '" + RG + "' AND visto = 'F' ";
                MySqlCommand cmd = new MySqlCommand(verifica, conexao);

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
                    checagem = tabela_retorno.Rows[0][3].ToString();

                    if (checagem != null && checagem != "")
                    {
                        string direcionamento = tabela_retorno.Rows[0][0].ToString();
                        string assunto = tabela_retorno.Rows[0][1].ToString();
                        string mensagem = tabela_retorno.Rows[0][2].ToString();
                        string[] data = tabela_retorno.Rows[0][3].ToString().Split('/');
                        string[] anopuro = data[2].Split(' ');
                        Chat receber = new Chat(Nome_Funcionario_Logado,RG);
                        receber.receber(direcionamento, assunto, mensagem, data[0], data[1], anopuro[0]);
                        receber.Show();

                        string verifica2 = "UPDATE notificacao SET visto = 'V' WHERE id_notificacao = "+ Convert.ToInt16(tabela_retorno.Rows[0][4].ToString())+ " AND direcionamento = '" + RG + "' ";
                        MySqlCommand cmd2 = new MySqlCommand(verifica2, conexao);

                        try
                        {
                            conexao.Close();
                        }
                        catch { }
                        //conectar com o banco
                        conexao.Open();


                        //executar comando                
                        cmd2.ExecuteNonQuery();

                        conexao.Close();

                        if (Convert.ToInt16(dia) <= 7)
                        {
                            if (Convert.ToInt16(dia) == 1)
                            {
                                 semana_passado = 24;
                            }
                            else if (Convert.ToInt16(dia) == 2)
                            {
                                 semana_passado = 25;
                            }
                            else if (Convert.ToInt16(dia) == 3)
                            {
                                 semana_passado = 26;
                            }
                            else if (Convert.ToInt16(dia) == 4)
                            {
                                 semana_passado = 27;
                            }
                            else if (Convert.ToInt16(dia) == 5)
                            {
                                 semana_passado = 28;
                            }
                            else if (Convert.ToInt16(dia) == 6)
                            {
                                 semana_passado = 29;
                            }
                            else if (Convert.ToInt16(dia) == 7)
                            {
                                 semana_passado = 30;
                            }
                            
                        }
                        else
                        {
                            semana_passado = Convert.ToInt16(dia) - 7;
                        }






                        
                        string deleta = "DELETE FROM notificacao WHERE direcionamento = '" + direcionamento + "' AND data_notificacao <"+ano+"-"+mes+"-"+semana_passado.ToString() ;
                         cmd = new MySqlCommand(deleta, conexao);
                       
                        //conectar com o banco
                        conexao.Open();


                        //executar comando                
                        cmd.ExecuteNonQuery();

                        conexao.Close();
                        
                    }
                }
                catch 
                {                   
                    checagem = null;
                }
            }
            catch { }
        }
        public string getRG { get { return RG; } }
        public string getNome_Logado { get { return Nome_Funcionario_Logado; } }

    }
}
