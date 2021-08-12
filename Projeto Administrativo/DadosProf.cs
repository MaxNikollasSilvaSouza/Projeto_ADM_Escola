using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Administrativo
{
    public class DadosProf
    {
        protected string nome;
        protected string rg;

        public DadosProf(string nn, string rr)
        {
            nome = nn;
            rg = rr;
        }

        public string NOME { get { return nome; } }
        public string RG { get { return rg; } }

        public override string ToString()
        {
            return nome;
        }
    }
}
