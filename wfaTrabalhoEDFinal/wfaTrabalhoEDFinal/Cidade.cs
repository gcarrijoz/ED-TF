using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfaTrabalhoEDFinal
{
    internal class Cidade
    {
        public string Nome { get; set; }
        public Dictionary<Cidade, int> Vizinhos { get; set; }

        public Cidade(string nome)
        {
            Nome = nome;
            Vizinhos = new Dictionary<Cidade, int>();
        }

        public void AdicionarVizinho(Cidade vizinho, int distancia)
        {
            Vizinhos.Add(vizinho, distancia);
        }
    }
}
