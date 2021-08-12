using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Projeto_Administrativo
{
    public class PagamentoClientes
    {
        private string con = "server=localhost; user=root; database=mydb";
        private MySqlConnection conexao;
        private MySqlDataAdapter busca;
        private MySqlCommand comando;
        public List<LembretePagamento> lembrete;

        public DataTable buscar(string i, string nome, string escolha)
        {
            DataTable retorno = new DataTable();

            nome = "'" + "%" + nome + "%" + "'";

            if (i == "I")
            {
                if (escolha == "A")
                {
                    busca = new MySqlDataAdapter("select nome_aluno as 'Nome',cpf as 'CPF',rg as 'RG', endereco as 'Endereco', cep as 'CEP', complemento as 'Complemento', telefones as 'Telefones', email as 'E-mail', dia_pagamento as 'Dia de pagamento', tipo_aula as 'Tipo da aula' from aluno where nome_aluno like " + nome, con);
                }
                if (escolha == "R")
                {
                    busca = new MySqlDataAdapter("select r.nome_responsavel as 'Nome', r.rg as 'RG', r.cpf as 'CPF', r.endereco as 'Endereco', r.cep as 'CEP', r.complemento as 'Complemento', r.telefones as 'Telefones', r.email as 'E-mail', r.dia_pagamento as 'Dia de pagamento', a.tipo_aula as 'Tipo da aula' from responsavel as r join aluno as a on a.responsavel_rg = r.rg where nome_responsavel like" + nome, con);
                }
            }
            else if (i == "sp")
            {
                if (escolha == "A")
                {
                    busca = new MySqlDataAdapter("select pc.id_pagamento as 'ID', a.nome_aluno as 'Nome', pc.situacao_pagamento as 'Situacao', pc.data_pagamento as 'Data de pagamento', pc.forma_pagamento as 'Forma de pagamento', pc.codigo_boleto as 'Codigo do boleto', pc.codigo_pagamento as 'Codigo do pagamento' from aluno as a join pagamento_cliente as pc on pc.aluno_rg = a.rg where a.nome_aluno like " + nome, con);
                }
                if (escolha == "R")
                {
                    busca = new MySqlDataAdapter("select pc.id_pagamento as 'ID',a.nome_aluno as 'Nome do aluno', r.nome_responsavel as 'Nome do responsavel', pc.situacao_pagamento as 'Situacao', pc.data_pagamento as 'Data de pagamento', pc.forma_pagamento as 'Forma de pagamento', pc.codigo_boleto as 'Codigo do boleto', pc.codigo_pagamento as 'Codigo do pagamento' from responsavel as r  join pagamento_cliente as pc on pc.responsavel_rg = r.rg join aluno as a on a.responsavel_rg = r.rg where r.nome_responsavel like " + nome, con);
                }
            }
            else if (i == "p")
            {
                if (escolha == "A")
                {
                    busca = new MySqlDataAdapter("select pc.id_pagamento as 'ID', a.nome_aluno as 'Nome', pc.situacao_pagamento as 'Situacao', pc.data_pagamento as 'Data de pagamento', pc.forma_pagamento as 'Forma de pagamento', pc.codigo_boleto as 'Codigo do boleto', pc.codigo_pagamento as 'Codigo do pagamento' from aluno as a join pagamento_cliente as pc on pc.aluno_rg = a.rg where pc.situacao_pagamento = 'PAGO'", con);
                }
                else if (escolha == "R")
                {
                    busca = new MySqlDataAdapter("select pc.id_pagamento as 'ID',r.nome_responsavel as 'Nome do responsavel', a.nome_aluno as 'Nome do aluno', pc.situacao_pagamento as 'Situacao', pc.data_pagamento as 'Data de pagamento', pc.forma_pagamento as 'Forma de pagamento', pc.codigo_boleto as 'Codigo do boleto', pc.codigo_pagamento as 'Codigo do pagamento' from responsavel as r  join pagamento_cliente as pc on pc.responsavel_rg = r.rg join aluno as a on a.responsavel_rg = r.rg where pc.situacao_pagamento = 'PAGO'", con);
                }
            }
            else if (i == "np")
            {
                if (escolha == "A")
                {
                    busca = new MySqlDataAdapter("select pc.id_pagamento as 'ID', a.nome_aluno as 'Nome', pc.situacao_pagamento as 'Situacao', a.dia_pagamento as 'Dia do pagamento', pc.forma_pagamento as 'Forma de pagamento', a.tipo_aula as 'Tipo da aula' from aluno as a join pagamento_cliente as pc on pc.aluno_rg = a.rg where pc.situacao_pagamento = 'NÃO PAGO'", con);
                }
                else if (escolha == "R")
                {
                    busca = new MySqlDataAdapter("select pc.id_pagamento as 'ID',a.nome_aluno as 'Nome do aluno', r.nome_responsavel as 'Nome do responsável', pc.situacao_pagamento as 'Situacao', r.dia_pagamento as 'Dia do pagamento', pc.forma_pagamento as 'Forma de pagamento', a.tipo_aula as 'Tipo da aula' from responsavel as r join pagamento_cliente as pc on pc.responsavel_rg = r.rg join aluno as a on a.responsavel_rg = r.rg where pc.situacao_pagamento = 'NÃO PAGO'", con);
                }
            }
            else if (i == "ea")
            {
                if (escolha == "A")
                {
                    busca = new MySqlDataAdapter("select pc.id_pagamento as 'ID', a.nome_aluno as 'Nome', pc.situacao_pagamento as 'Situacao', a.dia_pagamento as 'Dia de pagamento', pc.forma_pagamento 'Forma de pagamento', a.tipo_aula as 'Tipo da aula' from aluno as a join pagamento_cliente as pc on pc.aluno_rg = a.rg where pc.situacao_pagamento = 'EM ANDAMENTO'", con);
                }
                else if (escolha == "R")
                {
                    busca = new MySqlDataAdapter("select pc.id_pagamento as 'ID',a.nome_aluno as 'Nome do aluno', r.nome_responsavel as 'Nome do responsavel', pc.situacao_pagamento as 'Situacao', r.dia_pagamento as 'Dia de pagamento', pc.forma_pagamento as 'Forma de pagamento', a.tipo_aula as 'Tipo da aula' from responsavel as r join pagamento_cliente as pc on pc.responsavel_rg = r.rg join aluno as a on a.responsavel_rg = r.rg where pc.situacao_pagamento = 'EM ANDAMENTO'", con);
                }
            }
            else if (i == "sr")
            {
                if (escolha == "A")
                {
                    busca = new MySqlDataAdapter("select pc.id_pagamento as 'ID', a.nome_aluno as 'Nome', pc.situacao_pagamento as 'Situacao', a.dia_pagamento as 'Dia de pagamento', pc.forma_pagamento as 'Forma de pagamento', a.tipo_aula as 'Tipo da aula' from aluno as a join pagamento_cliente as pc on pc.aluno_rg = a.rg where pc.situacao_pagamento = 'SEM RETORNO'", con);
                }
                else if (escolha == "R")
                {
                    busca = new MySqlDataAdapter("select pc.id_pagamento as 'ID',a.nome_aluno as 'Nome do aluno', r.nome_responsavel as 'Nome do responsavel', pc.situacao_pagamento as 'Situacao', r.dia_pagamento as 'Dia de pagamento', pc.forma_pagamento as 'Forma de pagamento', a.tipo_aula as 'Tipo da aula' from responsavel as r join pagamento_cliente as pc on pc.responsavel_rg = r.rg join aluno as a on a.responsavel_rg = r.rg where pc.situacao_pagamento = 'SEM RETORNO'", con);
                }
            }
            else if (i == "tdsregistros")
            {
                if (escolha == "A")
                {
                    busca = new MySqlDataAdapter("select pc.id_pagamento as 'ID', a.nome_aluno as 'Nome', pc.situacao_pagamento as 'Situacao', a.dia_pagamento as 'Dia de pagamento', pc.forma_pagamento as 'Forma de pagamento', a.tipo_aula as 'Tipo da aula' from aluno as a join pagamento_cliente as pc on pc.aluno_rg = a.rg where pc.situacao_pagamento = '%%'", con);
                }
                else if (escolha == "R")
                {
                    busca = new MySqlDataAdapter("select pc.id_pagamento as 'ID',a.nome_aluno as 'Nome do aluno', r.nome_responsavel as 'Nome do responsavel', pc.situacao_pagamento as 'Situacao', r.dia_pagamento as 'Dia de pagamento', pc.forma_pagamento as 'Forma de pagamento', a.tipo_aula as 'Tipo da aula' from responsavel as r join pagamento_cliente as pc on pc.responsavel_rg = r.rg join aluno as a on a.responsavel_rg = r.rg where pc.situacao_pagamento = '%%'", con);
                }
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
                System.Windows.Forms.MessageBox.Show("Não foi possível realizar a busca");
            }
            return retorno;
        }

        public void pagamento(string forma, string data, string cod_pag, string cod_bol, string sit, string rg_aluno, string rg_resp)
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

                cmd = "insert into pagamento_cliente values(default, @data, @codigo_pag, @codigo_bol, @situacao, @forma_pagamento, @aluno_rg, @resp_rg)";
                comando = new MySqlCommand(cmd, conexao);

                comando.Parameters.AddWithValue("@data", data);
                comando.Parameters.AddWithValue("@codigo_pag", cod_pag);
                comando.Parameters.AddWithValue("@codigo_bol", cod_bol);
                comando.Parameters.AddWithValue("@situacao", sit);
                comando.Parameters.AddWithValue("@aluno_rg", rg_aluno);
                comando.Parameters.AddWithValue("@resp_rg", rg_resp);
                comando.Parameters.AddWithValue("@forma_pagamento", forma);

                comando.ExecuteNonQuery();
                conexao.Close();

                System.Windows.Forms.MessageBox.Show("Confirmação realizada com sucesso!");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Não foi possível confirmar o pagamento \n" + ex.ToString());
            }
        }

        public void atualizar(string id, string data, string boleto, string pagamento, string situacao, string forma)
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
                cmd = "update pagamento_cliente set data_pagamento = @data, codigo_boleto = @boleto, codigo_pagamento = @pagamento, situacao_pagamento = @situacao, forma_pagamento = @forma where id_pagamento = " + id;
                comando = new MySqlCommand(cmd, conexao);

                comando.Parameters.AddWithValue("@data", data);
                comando.Parameters.AddWithValue("@boleto", boleto);
                comando.Parameters.AddWithValue("@pagamento", pagamento);
                comando.Parameters.AddWithValue("@situacao", situacao);
                comando.Parameters.AddWithValue("@forma", forma);

                comando.ExecuteNonQuery();
                conexao.Close();
                System.Windows.Forms.MessageBox.Show("Atualização realizada com sucesso!");
            }
            catch
            {
            }
        }

        public void deletar(string id)
        {
            id = "'" + id + "'";
            string cmd = "delete from pagamento_cliente where id_pagamento = " + id;
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

                if (id != "")
                    System.Windows.Forms.MessageBox.Show("Deletado com sucesso!");
            }
            catch
            {
            }
        }

        public DataTable MostrarPagantes(string nome, string escolha)
        {
            DataTable retorno = new DataTable();

            if (escolha == "A")
            {
                busca = new MySqlDataAdapter("select nome_aluno as Nome, rg as RG from aluno where dia_pagamento like '%%'", con);
            }
            else if (escolha == "R")
            {
                busca = new MySqlDataAdapter("select nome_responsavel as Nome, rg as RG from responsavel", con);
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
                System.Windows.Forms.MessageBox.Show("Não foi possível realizar a busca");
            }
            return retorno;
        }

        public List<LembretePagamento> lembreteDPagamento(string pagante)
        {
            DataTable verificar = new DataTable();
            int dia = DateTime.Today.Day, data_limite;
            int mes = DateTime.Today.Month, ano = DateTime.Today.Year;
            string iniciodata = "'" + ano.ToString() + "-" + mes.ToString() + "-" + "01" + "'";
            //ver se nao ha outro modo de pegar o ultimo dia do mes atual
            string finaldata = "'" + ano.ToString() + "-" + mes.ToString() + "-" + "30" + "'";

            try
            {
                if (pagante == "R")
                {
                    //fazer o algoritmo que verifica se a data do pagamento é o dia de hoje para aluno
                    busca = new MySqlDataAdapter("select nome_responsavel, dia_pagamento, mensalidade, rg from responsavel", con);
                    conexao = new MySqlConnection(con);
                    try
                    {
                        conexao.Close();
                    }
                    catch { }
                    conexao.Open();
                    busca.Fill(verificar);
                    for (int i = 0; i < verificar.Rows.Count; i++)
                    {
                        data_limite = Convert.ToInt32(verificar.Rows[i]["dia_pagamento"]);
                        string rg = verificar.Rows[i]["rg"].ToString();

                        int diafpagamento = (dia - data_limite) * -1;
                        //verificar quantos dia faltam para a data do pagamento, e se passou, quantos dias passaram
                        if (diafpagamento <= 3)
                        {
                            //verificar se pagou com antecedencia
                            rg = "'" + rg + "'";
                            MySqlDataAdapter antecedencia = new MySqlDataAdapter("select situacao_pagamento from pagamento_cliente where responsavel_rg = " + rg + " and situacao_pagamento = 'PAGO' and data_pagamento between " + iniciodata + " and " + finaldata, conexao);
                            DataTable antecev = new DataTable();
                            antecedencia.Fill(antecev);
                            string linha = "";

                            try
                            {
                                linha = antecev.Rows[0]["situacao_pagamento"].ToString();
                            }
                            catch { linha = ""; }
                            if (linha != "PAGO")
                            {
                                lembrete = null;
                                string nome = verificar.Rows[i]["nome_responsavel"].ToString();
                                double mensalidade = Convert.ToDouble(verificar.Rows[i]["mensalidade"]);
                                LembretePagamento novo = new LembretePagamento(nome, mensalidade, rg, diafpagamento);
                                lembrete = new List<LembretePagamento>();
                                lembrete.Add(novo);
                            }
                        }
                    }
                }
                if (pagante == "A")
                {
                    //fazer o algoritmo que verifica se a data do pagamento é o dia de hoje para aluno
                    busca = new MySqlDataAdapter("select nome_aluno, dia_pagamento, mensalidade, rg from aluno", con);
                    conexao = new MySqlConnection(con);
                    try
                    {
                        conexao.Close();
                    }
                    catch { }
                    conexao.Open();
                    busca.Fill(verificar);
                    for (int i = 0; i < verificar.Rows.Count; i++)
                    {
                        data_limite = Convert.ToInt32(verificar.Rows[i]["dia_pagamento"]);
                        string rg = verificar.Rows[i]["rg"].ToString();

                        int diafpagamento = (dia - data_limite) * -1;
                        //verificar quantos dia faltam para a data do pagamento, e se passou, quantos dias passaram
                        if (diafpagamento <= 3)
                        {
                            //verificar se pagou com antecedencia
                            rg = "'" + rg + "'";
                            string cmd = "select situacao_pagamento from pagamento_cliente where aluno_rg = " + rg + " and situacao_pagamento = 'PAGO' and data_pagamento between " + iniciodata + " and " + finaldata;
                            MySqlDataAdapter antecedencia = new MySqlDataAdapter(cmd, conexao);
                            DataTable antecev = new DataTable();
                            antecedencia.Fill(antecev);
                            string linha = "";

                            try
                            {
                                linha = antecev.Rows[0]["situacao_pagamento"].ToString();
                            }
                            catch { linha = ""; }

                            if (linha != "PAGO")
                            {
                                lembrete = null;
                                string nome = verificar.Rows[i]["nome_aluno"].ToString();
                                double mensalidade = Convert.ToDouble(verificar.Rows[i]["mensalidade"]);
                                LembretePagamento novo = new LembretePagamento(nome, mensalidade, rg, diafpagamento);
                                lembrete = new List<LembretePagamento>();
                                lembrete.Add(novo);
                            }
                        }
                    }
                }
            }
            catch { }
            return lembrete;
        }
    }
}