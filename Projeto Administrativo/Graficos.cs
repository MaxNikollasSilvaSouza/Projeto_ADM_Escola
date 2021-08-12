using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Projeto_Administrativo
{
    public class Graficos
    {
        private string con = "server=localhost; user=root; database=mydb";

        public int quantitativa(string tipo)
        {
            int retorno = 0;
            if (tipo == "total")
            {
                string cmdR = "select count(mensalidade) from responsavel";
                DataTable responsavel = new DataTable();
                MySqlDataAdapter buscaR = new MySqlDataAdapter(cmdR, con);
                MySqlConnection conexao = new MySqlConnection(con);

                try
                {
                    conexao.Open();

                    buscaR.Fill(responsavel);
                    retorno = Convert.ToInt32(responsavel.Rows[0]["count(mensalidade)"]);
                }
                catch { }
                conexao.Close();

                DataTable aluno = new DataTable();
                string cmdA = "select count(mensalidade) from aluno where dia_pagamento like '%%'";
                MySqlDataAdapter buscaA = new MySqlDataAdapter(cmdA, con);
                try
                {
                    conexao.Open();

                    buscaA.Fill(aluno);
                    retorno = retorno + Convert.ToInt32(aluno.Rows[0]["count(mensalidade)"]);
                }
                catch { }
                conexao.Close();
            }
            if (tipo == "pagos")
            {
                int dia = DateTime.Today.Day;
                int mes = DateTime.Today.Month, ano = DateTime.Today.Year;
                string iniciodata = "'" + ano.ToString() + "-" + mes.ToString() + "-" + "01" + "'";
                //ver se nao ha outro modo de pegar o ultimo dia do mes atual
                string finaldata = "'" + ano.ToString() + "-" + mes.ToString() + "-" + "30" + "'";

                string cmdR = "select count(pc.situacao_pagamento) from pagamento_cliente as pc join responsavel as r on r.rg = pc.responsavel_rg where pc.situacao_pagamento = 'PAGO' and pc.data_pagamento between " + iniciodata + " and " + finaldata;
                DataTable responsavel = new DataTable();
                MySqlDataAdapter buscaR = new MySqlDataAdapter(cmdR, con);
                MySqlConnection conexao = new MySqlConnection(con);
                try
                {
                    conexao.Open();
                    buscaR.Fill(responsavel);
                    retorno = Convert.ToInt32(responsavel.Rows[0]["count(pc.situacao_pagamento)"]);
                }
                catch { }
                conexao.Close();

                DataTable aluno = new DataTable();
                string cmdA = "select count(pc.situacao_pagamento) from pagamento_cliente as pc join aluno as a on a.rg = pc.aluno_rg where pc.situacao_pagamento = 'PAGO' and pc.data_pagamento between " + iniciodata + " and " + finaldata;
                MySqlDataAdapter buscaA = new MySqlDataAdapter(cmdA, con);
                try
                {
                    conexao.Open();

                    buscaA.Fill(aluno);
                    retorno = retorno + Convert.ToInt32(aluno.Rows[0]["count(pc.situacao_pagamento)"]);
                }
                catch { }
                conexao.Close();
            }
            return retorno;
        }

        public double monetaria(string tipo)
        {
            double retorno = 0;
            if (tipo == "total")
            {
                string cmdR = "select sum(mensalidade) from responsavel";
                DataTable responsavel = new DataTable();
                MySqlDataAdapter buscaR = new MySqlDataAdapter(cmdR, con);
                MySqlConnection conexao = new MySqlConnection(con);

                try
                {
                    conexao.Open();

                    buscaR.Fill(responsavel);
                    retorno = Convert.ToDouble(responsavel.Rows[0]["sum(mensalidade)"]);
                }
                catch { }
                conexao.Close();

                DataTable aluno = new DataTable();
                string cmdA = "select sum(mensalidade) from aluno where dia_pagamento like '%%'";
                MySqlDataAdapter buscaA = new MySqlDataAdapter(cmdA, con);
                try
                {
                    conexao.Open();

                    buscaA.Fill(aluno);
                    retorno = retorno + Convert.ToDouble(aluno.Rows[0]["sum(mensalidade)"]);
                }
                catch { }
                conexao.Close();
            }
            if (tipo == "pagos")
            {
                int dia = DateTime.Today.Day;
                int mes = DateTime.Today.Month, ano = DateTime.Today.Year;
                string iniciodata = "'" + ano.ToString() + "-" + mes.ToString() + "-" + "01" + "'";
                //ver se nao ha outro modo de pegar o ultimo dia do mes atual
                string finaldata = "'" + ano.ToString() + "-" + mes.ToString() + "-" + "30" + "'";

                string cmdR = "select sum(r.mensalidade) from pagamento_cliente as pc join responsavel as r on r.rg = pc.responsavel_rg where pc.situacao_pagamento = 'PAGO' and pc.data_pagamento between " + iniciodata + " and " + finaldata;
                DataTable responsavel = new DataTable();
                MySqlDataAdapter buscaR = new MySqlDataAdapter(cmdR, con);
                MySqlConnection conexao = new MySqlConnection(con);
                try
                {
                    conexao.Open();
                    buscaR.Fill(responsavel);
                    retorno = Convert.ToDouble(responsavel.Rows[0]["sum(r.mensalidade)"]);
                }
                catch { }
                conexao.Close();

                DataTable aluno = new DataTable();
                string cmdA = "select sum(a.mensalidade) from pagamento_cliente as pc join aluno as a on a.rg = pc.aluno_rg where pc.situacao_pagamento = 'PAGO' and pc.data_pagamento between " + iniciodata + " and " + finaldata;
                MySqlDataAdapter buscaA = new MySqlDataAdapter(cmdA, con);
                try
                {
                    conexao.Open();

                    buscaA.Fill(aluno);
                    retorno = retorno + Convert.ToDouble(aluno.Rows[0]["sum(a.mensalidade)"]);
                }
                catch { }
                conexao.Close();
            }
            return retorno;
        }
    }
}
