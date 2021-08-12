using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Projeto_Administrativo
{
    class GastosDiversos
    {
        private string con = "server=localhost; user=root; database=mydb";
        private MySqlConnection conexao;
        private MySqlDataAdapter busca;
        private MySqlCommand comando;
        public string id = "";
       
        public void DeclararGasto(string data, string descricao, string preco, string func_rg)
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

                cmd = "insert into gastos_diversos values(default, @data, @descricao, @preco, @funcionario_rg)";
                comando = new MySqlCommand(cmd, conexao);

                comando.Parameters.AddWithValue("@data", data);
                comando.Parameters.AddWithValue("@descricao", descricao);
                comando.Parameters.AddWithValue("@preco", preco);
                comando.Parameters.AddWithValue("@funcionario_rg", func_rg);

                comando.ExecuteNonQuery();
                conexao.Close();

                System.Windows.Forms.MessageBox.Show("Declaração de gasto realizada com sucesso!");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Não foi possível realizar a declaração de gasto \n" + ex.ToString());
            }
        }

        public DataTable MostrarGasto()
        {
            DataTable retorno = new DataTable();
            conexao = new MySqlConnection(con);

            string select = "select gd.id_gasto as 'ID',f.nome_funcionario as 'Funcionario', gd.data_declaracao as 'Data de declaracao', gd.descricao as 'Descricao', gd.preco as 'Preco' from gastos_diversos as gd join funcionario as f on gd.funcionario_rg = f.rg";
            busca = new MySqlDataAdapter(select, con);
            try
            {
                conexao.Close();
            }
            catch { }
            conexao.Open();
            busca.Fill(retorno);
            conexao.Close();

            return retorno;
        }

        public void deletar(string id)
        {
            id = "'" + id + "'";
            string cmd = "delete from gastos_diversos where id_gasto = " + id;
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

        public void atualizar(string id, string data, string descricao, string preco)
        {
            id = "'" + id + "'";
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
                cmd = "update gastos_diversos set data_declaracao = @data, descricao = @descricao, preco = @preco where id_gasto = " + id;
                comando = new MySqlCommand(cmd, conexao);

                comando.Parameters.AddWithValue("@data", data);
                comando.Parameters.AddWithValue("@descricao", descricao);
                comando.Parameters.AddWithValue("@preco", preco);

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
