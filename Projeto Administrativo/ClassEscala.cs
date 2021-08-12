using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Projeto_Administrativo
{
    public class ClassEscala
    {
        private string con = "server=localhost; user=root; database=mydb";
        private MySqlConnection conexao;
        private MySqlDataAdapter busca;
        private MySqlCommand comando;
        private DadosAluno aluno;
        private DadosProf professor;

        public List<DadosAluno> buscA()
        {
            List<DadosAluno> lista = new List<DadosAluno>();
            string cmd = "select nome_aluno, rg, tipo_aula from aluno";
            DataTable dados = new DataTable();
            busca = new MySqlDataAdapter(cmd, con);
            conexao = new MySqlConnection(con);

            conexao.Open();

            busca.Fill(dados);

            for (int i = 0; i < dados.Rows.Count; i++)
            {
                string nome = dados.Rows[i]["nome_aluno"].ToString();
                string rg = dados.Rows[i]["rg"].ToString();
                string aula = dados.Rows[i]["tipo_aula"].ToString();

                aluno = new DadosAluno(nome, aula, rg);
                lista.Add(aluno);
            }
            conexao.Close();

            return lista;
        }

        public List<DadosProf> buscP()
        {
            List<DadosProf> lista = new List<DadosProf>();
            string cmd = "select nome_funcionario, rg from funcionario where funcao like '%Professor%'";
            DataTable dados = new DataTable();
            busca = new MySqlDataAdapter(cmd, con);
            conexao = new MySqlConnection(con);

            conexao.Open();

            busca.Fill(dados);

            for (int i = 0; i < dados.Rows.Count; i++)
            {
                string nome = dados.Rows[i]["nome_funcionario"].ToString();
                string rg = dados.Rows[i]["rg"].ToString();

                professor = new DadosProf(nome, rg);
                lista.Add(professor);
            }
            conexao.Close();

            return lista;
        }

        public void cadastrar(string hInicio, string hFim, string sala, string dia, string rgP, string rgA)
        {
            string cmd = "";
            conexao = new MySqlConnection(con);

            try
            {
                conexao.Open();

                cmd = "insert into escala values(default, @inicio, @fim, @dia_semana, @sala, @aluno_rg, @funcionario_rg)";
                comando = new MySqlCommand(cmd, conexao);

                comando.Parameters.AddWithValue("@inicio", hInicio);
                comando.Parameters.AddWithValue("@fim", hFim);
                comando.Parameters.AddWithValue("@dia_semana", dia);
                comando.Parameters.AddWithValue("@sala", sala);
                comando.Parameters.AddWithValue("@aluno_rg", rgA);
                comando.Parameters.AddWithValue("@funcionario_rg", rgP);

                comando.ExecuteNonQuery();
                conexao.Close();

                System.Windows.Forms.MessageBox.Show("Cadastro de aula realizado com sucesso!");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Não foi possível fazer o cadastro! \n" + ex.ToString());
            }
        }

        public void deletar(string id)
        {
            id = "'" + id + "'";
            string cmd = "delete from escala where id_escala = " + id;
            conexao = new MySqlConnection(con);

            try
            {
                conexao.Open();
                comando = new MySqlCommand(cmd, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();

                System.Windows.Forms.MessageBox.Show("Deletado com sucesso!");
            }
            catch
            {
            }
        }

        public DataTable buscar(int tipo, string nome)
        {
            DataTable retorno = new DataTable();

            if (tipo == 1)
            {
                busca = new MySqlDataAdapter("select e.id_escala as 'ID', a.nome_aluno as 'NOME', a.tipo_aula as 'TIPO DA AULA', e.inicio as 'INICIO', e.fim as 'FIM', e.dia_semana as 'DIA DA SEMANA', e.sala as 'SALA' from escala as e join aluno as a on a.rg = e.aluno_rg", con);
                try
                {
                    conexao = new MySqlConnection(con);
                    conexao.Open();
                    busca.Fill(retorno);
                    conexao.Close();
                }
                catch
                {
                }
            }
            else if (tipo == 2)
            {
                nome = "'" + "%" + nome + "%" + "'";

                busca = new MySqlDataAdapter("select e.id_escala as 'ID', a.nome_aluno as 'NOME', a.tipo_aula as 'TIPO DA AULA', e.inicio as 'INICIO', e.fim as 'FIM', e.dia_semana as 'DIA DA SEMANA', e.sala as 'SALA' from escala as e join aluno as a on a.rg = e.aluno_rg where a.nome_aluno like " + nome, con);
                try
                {
                    conexao = new MySqlConnection(con);
                    conexao.Open();
                    busca.Fill(retorno);
                    conexao.Close();
                }
                catch
                {
                }
            }

            return retorno;
        }
    }
}
