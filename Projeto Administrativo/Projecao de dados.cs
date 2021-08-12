using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Projeto_Administrativo
{
    public partial class Projecao_de_dados : Form
    {
        Graficos novo;
        Series serie;
        string nome_logado;
        string rg_logado;
        public Projecao_de_dados(string nome, string rg)
        {
            InitializeComponent();
            nome_logado = nome;
            rg = rg_logado;
        }
        public void quantitativa()
        {
            novo = new Graficos();
            serie = new Series();
            grafico.Series.Clear();
            grafico.ResetAutoValues();
            int total = novo.quantitativa("total");
            int pagos = novo.quantitativa("pagos");
            int anaop = total - pagos;
            string[] series = { "Total", "Pagas", "Ainda não pagas" };
            int[] mostrar = { total, pagos, anaop };

            grafico.Palette = ChartColorPalette.Pastel;

            for (int i = 0; i < series.Length; i++)
            {
                serie = grafico.Series.Add(series[i]);

                serie.Label = mostrar[i].ToString();

                serie.Points.Add(mostrar[i]);
            }
        }

        public void monetaria()
        {
            novo = new Graficos();
            serie = new Series();
            grafico.Series.Clear();
            grafico.ResetAutoValues();
            double total = novo.monetaria("total");
            double pagos = novo.monetaria("pagos");
            double anaop = total - pagos;
            string[] series = { "Total", "Pagas", "Ainda não pagas" };
            double[] mostrar = { total, pagos, anaop };

            grafico.Palette = ChartColorPalette.Pastel;

            for (int i = 0; i < series.Length; i++)
            {
                serie = grafico.Series.Add(series[i]);

                serie.Label = mostrar[i].ToString();

                serie.Points.Add(mostrar[i]);
            }
        }

        private void Projecao_de_dados_Load(object sender, EventArgs e)
        {
            quantitativa();
            grafico.Titles.Add("Projeção de dados sobre mensalidades");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Projeção quantitativa")
            {
                quantitativa();
            }
            else if (comboBox1.SelectedItem == "Projeção monetária")
            {
                monetaria();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Área_Financeira financa = new Área_Financeira(rg_logado, nome_logado);
            financa.Show();
        }
    }
}
