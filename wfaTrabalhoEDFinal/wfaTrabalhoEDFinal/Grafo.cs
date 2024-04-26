using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfaTrabalhoEDFinal
{
    internal class Grafo
    {
        public List<Cidade> Cidades { get; set; }

        public Grafo()
        {
            Cidades = new List<Cidade>();
        }

        public void AdicionarCidade(Cidade cidade)
        {
            Cidades.Add(cidade);
        }
        public Tuple<int, List<Cidade>> MenorCaminhoDijkstra(Cidade origem, Cidade destino)
        {
            // Implementação do algoritmo de Dijkstra para encontrar o caminho mais curto
            // entre a cidade de origem e a cidade de destino
            var distancias = new Dictionary<Cidade, int>();
            var anterior = new Dictionary<Cidade, Cidade>();
            var naoVisitadas = new List<Cidade>(Cidades);

            // Inicializa as distâncias com infinito, exceto para a cidade de origem
            foreach (Cidade cidade in naoVisitadas)
            {
                distancias[cidade] = int.MaxValue;
            }
            distancias[origem] = 0;

            while (naoVisitadas.Count != 0)
            {
                // Escolhe a cidade não visitada com a menor distância
                Cidade cidadeAtual = null;
                int menorDistancia = int.MaxValue;
                foreach (Cidade cidade in naoVisitadas)
                {
                    if (distancias[cidade] < menorDistancia)
                    {
                        cidadeAtual = cidade;
                        menorDistancia = distancias[cidade];
                    }
                }

                if (cidadeAtual == null)
                {
                    break;
                }

                naoVisitadas.Remove(cidadeAtual);

                // Atualiza as distâncias para as cidades vizinhas
                if (cidadeAtual.Vizinhos != null)
                {
                    foreach (KeyValuePair<Cidade, int> vizinho in cidadeAtual.Vizinhos)
                    {
                        if (naoVisitadas.Contains(vizinho.Key))
                        {
                            int distancia = menorDistancia + vizinho.Value;
                            if (distancia < distancias[vizinho.Key])
                            {
                                distancias[vizinho.Key] = distancia;
                                anterior[vizinho.Key] = cidadeAtual;
                            }
                        }
                    }
                }
            }
            // Se existir caminho entre as cidades
            if (anterior.ContainsKey(destino))
            {
                // Reconstrói o caminho mais curto
                List<Cidade> caminhoEncontrado = new List<Cidade>();
                Cidade c = destino;
                while (c != origem)
                {
                    caminhoEncontrado.Add(c);
                    c = anterior[c];
                }
                caminhoEncontrado.Reverse();

                int distanciaMinima = distancias[destino];

                return new Tuple<int, List<Cidade>>(distanciaMinima, caminhoEncontrado);
            }
            else
            {
                // caso não exista caminho entre as cidades
                return new Tuple<int, List<Cidade>>(int.MaxValue, null);
            }
        }
    }
}
