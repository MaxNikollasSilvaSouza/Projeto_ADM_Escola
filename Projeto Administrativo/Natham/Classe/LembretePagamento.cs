using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Administrativo
{
    public class LembretePagamento
    {
        protected string nome;
        protected double valor;
        protected string rg;
        protected int diap;

        public LembretePagamento(string nn, double vv, string rr, int dd)
        {
            nome = nn;
            valor = vv;
            rg = rr;
            diap = dd;
        }

        public string NOME { get { return nome; } }
        public double VALOR { get { return valor; } }
        public string RG { get { return rg; } }
        public int DIAP { get { return diap; } }

        public override string ToString()
        {
            return nome;
        }
    }
}
