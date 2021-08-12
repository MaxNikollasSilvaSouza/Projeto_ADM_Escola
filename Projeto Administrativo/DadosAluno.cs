using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Administrativo
{
    public class DadosAluno
    {
        protected string nome;
        protected string tipoaula;
        protected string rg;

        public DadosAluno(string nn, string ta, string rr)
        {
            nome = nn;
            tipoaula = ta;
            rg = rr;
        }

        public string NOME { get { return nome; } }
        public string TIPOAULA { get { return tipoaula; } }
        public string RG { get { return rg; } }

        public override string ToString()
        {
            return nome;
        }
    }
}
