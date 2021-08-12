using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;


namespace Projeto_Administrativo
{
    public class Areaporofessor
    {
        private string local_conexao = "server=localhost;user=root;database=mydb";
        MySqlConnection conexao;
        string RG_logado;
        private MySqlDataAdapter adapter;
        private string Nome_Pessoa_Logada;
        private string Data_Pessoa_logada = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
        
        public Areaporofessor(string quem_esta_logado, string RG_logadoo)
        {
            conexao = new MySqlConnection(local_conexao); this.Nome_Pessoa_Logada = quem_esta_logado;
            this.RG_logado = RG_logadoo;
        }

        string data, data_para_atualizar;
        string inicio_aula, fim_aula, aluno_rg, funcionario_rg;

        public void setar_data_para_atualizar(string atualizar)
        {
            data_para_atualizar = atualizar;
        }
        public void setar_marcar_aula(string dataa, string inicio, string fim, string aluno_rgg, string funcionario_rgg)
        {
            data = dataa;
            inicio_aula = inicio;
            fim_aula = fim;
            aluno_rg = aluno_rgg;
            funcionario_rg = funcionario_rgg;
        }
        private void Salvar_remarcacao()
        {
            try
            {
                try
                {
                    conexao.Close();
                }
                catch { }

                conexao.Open();
                string mensagem = "INSERT INTO marcar_aula (data_aula, inicio_aula, fim_aula, aluno_rg, funcionario_rg) values (@data_aula, @inicio_aula, @fim_aula, @aluno_rg, @funcionario_rg)";
                MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                cmd.Parameters.AddWithValue("@data_aula", data);
                cmd.Parameters.AddWithValue("@inicio_aula", inicio_aula);
                cmd.Parameters.AddWithValue("@fim_aula", fim_aula);
                cmd.Parameters.AddWithValue("@aluno_rg", aluno_rg);
                cmd.Parameters.AddWithValue("@funcionario_rg", RG_logado);
                cmd.ExecuteNonQuery();
                conexao.Close();
      

            }
            catch (Exception e) { erro(e.ToString()); }

        }

        private void Atualizar_remarcacao()
        {
            try
            {
                try
                {
                    conexao.Close();
                }
                catch { }
                

                string mensagem = "UPDATE marcar_aula SET data_aula = '" + data + "', inicio_aula = '" + inicio_aula + "', fim_aula = '" + fim_aula + "' WHERE aluno_rg = '" + aluno_rg+"' and funcionario_rg = '" + funcionario_rg+ "' and data_aula = '" + data_para_atualizar + "' ";
                MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                conexao.Open();
                cmd.ExecuteNonQuery();
                conexao.Close();

            }
            catch (Exception e) { erro(e.ToString()); }

        }


        public void checagem_remarcacao(string desejado)
        {
            if (desejado == "SALVAR")
            {
                Salvar_remarcacao();
            }
            else if (desejado == "ATUALIZAR")
            {
                Atualizar_remarcacao();
            }


           
        }

        string grupo;
        string obs_av;
        double nota_av;
       
        public void setar_notas(string aluno_rgg, string n_avv, double notaa, string dataa)
        {
            aluno_rg = aluno_rgg;  obs_av = n_avv; nota_av = notaa; data = dataa;
        }

        public void checagem_notas(string desejado)
        {
            if (desejado == "SALVAR")
            {
                Salvar_notas();
            }

            else if (desejado == "ATUALIZAR")
            {
                Atualizar_notas();
            }
        }

        private void Salvar_notas()
        {
            try
            {
                try
                {
                    conexao.Close();
                }
                catch { }

                conexao.Open();
                string mensagem = "INSERT INTO notas (nota, obs_nota, data, aluno_rg) values (@nota, @obs_nota, @data, @aluno_rg)";
                MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                cmd.Parameters.AddWithValue("@nota", nota_av);
                cmd.Parameters.AddWithValue("@obs_nota", obs_av);
                cmd.Parameters.AddWithValue("@data", data);
                cmd.Parameters.AddWithValue("@aluno_rg", aluno_rg);             
                cmd.ExecuteNonQuery();
                conexao.Close();


            }
            catch (Exception e) { erro(e.ToString()); }
        }

        private void Atualizar_notas()
        {
            try
            {
                try
                {
                    conexao.Close();
                }
                catch { }


                string mensagem = "UPDATE notas SET nota = " + nota_av + ", obs_nota = '" + obs_av + "' WHERE aluno_rg = '" + aluno_rg + "' and data = '" + data + "'";
                MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                conexao.Open();
                cmd.ExecuteNonQuery();
                conexao.Close();

            }
            catch (Exception e) { erro(e.ToString()); }
        }

        public void presenca(string dia, string rg, string t)
        {
            string tipo = "";
            string existe = "";
            int mes = DateTime.Today.Month, ano = DateTime.Today.Year;
            string cmd = "select faltas, presencas, mes, ano from presenca where aluno_rg = '" + rg + "' and mes = '" + mes.ToString() + "' and ano = '" + ano.ToString() + "'";
            DataTable dados = new DataTable();
            MySqlDataAdapter busca = new MySqlDataAdapter(cmd, local_conexao);
            conexao = new MySqlConnection(local_conexao);

            try
            {
                conexao.Close();
            }
            catch { }
            conexao.Open();

            try
            {
                busca.Fill(dados);
            }
            catch { }

            try
            {
                string v = dados.Rows[0]["ano"].ToString();
                existe = "s";
            }
            catch { existe = "n"; }
            if (existe == "n")
            {
                tipo = "insert";
            }
            else if (existe == "s")
            {
                tipo = "update";
            }

            conexao.Close();

            if (tipo == "insert")
            {
                try
                {
                    if (t == "sim")
                    {
                        cmd = "insert into presenca values(default, @faltas, @presencas, @mes, @ano, @aluno_rg)";
                        MySqlCommand comando = new MySqlCommand(cmd, conexao);

                        try
                        {
                            conexao.Close();
                        }
                        catch { }
                        conexao.Open();

                        comando.Parameters.AddWithValue("@faltas", "");
                        comando.Parameters.AddWithValue("@presencas", dia.ToString());
                        comando.Parameters.AddWithValue("@mes", mes.ToString());
                        comando.Parameters.AddWithValue("@ano", ano.ToString());
                        comando.Parameters.AddWithValue("@aluno_rg", rg);

                        comando.ExecuteNonQuery();

                        conexao.Close();

                    }
                    else if (t == "nao")
                    {
                        cmd = "insert into presenca values(default, @faltas, @presencas, @mes, @ano, @aluno_rg)";
                        MySqlCommand comando = new MySqlCommand(cmd, conexao);

                        try
                        {
                            conexao.Close();

                        }
                        catch { }
                        conexao.Open();

                        comando.Parameters.AddWithValue("@faltas", dia.ToString());
                        comando.Parameters.AddWithValue("@presencas", "");
                        comando.Parameters.AddWithValue("@mes", mes.ToString());
                        comando.Parameters.AddWithValue("@ano", ano.ToString());
                        comando.Parameters.AddWithValue("@aluno_rg", rg);

                        comando.ExecuteNonQuery();

                        conexao.Close();
                    }
                }
                catch (Exception k)
                {
                    errour(k.ToString());
                }

            }
            else if (tipo == "update")
            {
                string csv;
                cmd = "select faltas, presencas, mes, ano from presenca where aluno_rg = '" + rg + "' and mes = '" + mes.ToString() + "' and ano = '" + ano.ToString() + "' ";
                MySqlDataAdapter buscarUP = new MySqlDataAdapter(cmd, local_conexao);
                conexao = new MySqlConnection(local_conexao);

                try
                {
                    conexao.Close();
                }
                catch { }
                conexao.Open();
                buscarUP.Fill(dados);

                if (t == "sim")
                {
                    csv = dados.Rows[0]["presencas"].ToString();
                    if (csv == "")
                    {
                        csv = dia.ToString();
                    }
                    else
                    {
                        csv = csv + "," + dia.ToString();
                    }
                    cmd = "update presenca set presencas = '" + csv + "' where mes = '" + mes.ToString() + "' and ano = '" + ano.ToString() + "' and aluno_rg = '" + rg + "'";
                }
                else if (t == "nao")
                {
                    csv = dados.Rows[0]["faltas"].ToString();
                    if (csv == "")
                    {
                        csv = dia.ToString();
                    }
                    else
                    {
                        csv = csv + "," + dia.ToString();
                    }
                    cmd = "update presenca set faltas = '" + csv + "' where mes = '" + mes.ToString() + "' and ano = '" + ano.ToString() + "' and aluno_rg = '" + rg + "'";
                }
                conexao.Close();

                conexao.Open();
                MySqlCommand comando = new MySqlCommand(cmd, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }

        }


        private void errour(string e)
        {
            MessageBox.Show(e);
        }

        private void erro(string e)
        {
            MessageBox.Show("Devido a algum erro não foi possível realizar uma tarefa: " + e);
        }

    }
}
