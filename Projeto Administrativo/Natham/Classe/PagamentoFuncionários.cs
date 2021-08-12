using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Projeto_Administrativo
{
    class PagamentoFuncionários
    {
        private string con = "server=localhost; user=root; database=mydb";
        private MySqlConnection conexao;
        private MySqlDataAdapter busca;
        private MySqlCommand comando;

        public DataTable MostrarFunc()
        {
            DataTable retorno = new DataTable();

            busca = new MySqlDataAdapter("select f.id_funcionario as 'id do funcionario', f.nome_funcionario as 'Nome', f.rg as 'RG', ff.salario as 'Salario' from funcionario as f join funcionario_financa as ff on ff.funcionario_rg = f.rg", con);
            try
            {
                conexao = new MySqlConnection(con);
                try
                {
                    conexao.Close();
                }
                catch { }
                conexao.Open();
                busca.Fill(retorno);
                conexao.Close();
            }
            catch
            {
            }
            return retorno;
        }
        public DataTable filtros(string tipo)
        {
            DataTable retorno = new DataTable();

            if (tipo == "P")
            {
                busca = new MySqlDataAdapter("select p.id_pagamento as 'ID', f.nome_funcionario as 'Nome', p.data_pagamento as 'Data do pagamento', p.situacao as 'Situacao' from pagamento_func as p join funcionario as f on p.funcionario_rg = f.rg where situacao = 'PAGO'", con);
            }
            else if (tipo == "EA")
            {
                busca = new MySqlDataAdapter("select p.id_pagamento as 'ID', f.nome_funcionario as 'Nome', p.data_pagamento as 'Data do pagamento', p.situacao as 'Situacao' from pagamento_func as p join funcionario as f on f.rg = p.funcionario_rg where situacao = 'EM ANDAMENTO'", con);
            }
            try
            {
                conexao = new MySqlConnection(con);
                try
                {
                    conexao.Close();
                }
                catch { }
                conexao.Open();
                busca.Fill(retorno);
                conexao.Close();
            }
            catch
            {
            }

            return retorno;
        }
        public void CorfirmarPagamento(string data, string situacao, string obs, string func_rg)
        {
            string cmd = "";
            conexao = new MySqlConnection(con);

            try
            {
                try
                {
                    conexao.Close();
                }
                catch { }
                conexao.Open();

                cmd = "insert into pagamento_func values(default, @data, @situacao, @obs, @funcionario_rg)";
                comando = new MySqlCommand(cmd, conexao);

                comando.Parameters.AddWithValue("@data", data);
                comando.Parameters.AddWithValue("@situacao", situacao);
                comando.Parameters.AddWithValue("@obs", obs);
                comando.Parameters.AddWithValue("@funcionario_rg", func_rg);

                comando.ExecuteNonQuery();
                conexao.Close();

                System.Windows.Forms.MessageBox.Show("Confirmação realizada com sucesso!");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Não foi possível confirmar o pagamento \n" + ex.ToString());
            }
        }

        public void deletar(string id)
        {
            id = "'" + id + "'";
            string cmd = "delete from pagamento_func where id_pagamento = " + id;
            conexao = new MySqlConnection(con);

            try
            {
                try
                {
                    conexao.Close();
                }
                catch { }
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

        public void atualizar(string id, string data, string situacao, string obs)
        {
            id = "'" + id + "'";
            string cmd = "";
            conexao = new MySqlConnection(con);
            //Colocar o nome de quem ta registrando ex: Registrado por: @nome
            obs = null;

            try
            {
                try
                {
                    conexao.Close();
                }
                catch { }
                conexao.Open();
                cmd = "update pagamento_func set data_pagamento = @data, situacao = @situacao where id_pagamento = " + id;
                comando = new MySqlCommand(cmd, conexao);

                comando.Parameters.AddWithValue("@data", data);
                comando.Parameters.AddWithValue("@situacao", situacao);

                comando.ExecuteNonQuery();
                conexao.Close();
                System.Windows.Forms.MessageBox.Show("Atualização realizada com sucesso!");
            }
            catch
            {
            }
        }
    }
}