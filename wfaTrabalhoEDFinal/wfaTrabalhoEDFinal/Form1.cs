using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaTrabalhoEDFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cidade itumbiara = new Cidade("Itumbiara");
            Cidade centralina = new Cidade("Centralina");
            Cidade capinopolis = new Cidade("Capinópolis");
            Cidade ituiutaba = new Cidade("Ituiutaba");
            Cidade monteAlegre = new Cidade("Monte Alegre de Minas");
            Cidade douradinhos = new Cidade("Douradinhos");
            Cidade tupaciguara = new Cidade("Tupaciguara");
            Cidade uberlandia = new Cidade("Uberlândia");
            Cidade araguari = new Cidade("Araguari");
            Cidade cascalho = new Cidade("Cascalho Rico");
            Cidade grupiara = new Cidade("Grupiara");
            Cidade estrela = new Cidade("Estrela do Sul");
            Cidade romaria = new Cidade("Romaria");
            Cidade saoJuliana = new Cidade("São Juliana");
            Cidade indianopolis = new Cidade("Indianópolis");

            itumbiara.AdicionarVizinho(centralina, 20);
            itumbiara.AdicionarVizinho(tupaciguara, 55);

            centralina.AdicionarVizinho(itumbiara, 20);
            centralina.AdicionarVizinho(capinopolis, 40);
            centralina.AdicionarVizinho(monteAlegre, 75);

            capinopolis.AdicionarVizinho(centralina, 40);
            capinopolis.AdicionarVizinho(ituiutaba, 30);

            ituiutaba.AdicionarVizinho(capinopolis, 30);
            ituiutaba.AdicionarVizinho(monteAlegre, 85);
            ituiutaba.AdicionarVizinho(douradinhos, 90);

            monteAlegre.AdicionarVizinho(centralina, 75);
            monteAlegre.AdicionarVizinho(tupaciguara, 44);
            monteAlegre.AdicionarVizinho(uberlandia, 60);
            monteAlegre.AdicionarVizinho(douradinhos, 28);
            monteAlegre.AdicionarVizinho(ituiutaba, 85);

            tupaciguara.AdicionarVizinho(itumbiara, 55);
            tupaciguara.AdicionarVizinho(monteAlegre, 44);
            tupaciguara.AdicionarVizinho(uberlandia, 60);

            uberlandia.AdicionarVizinho(tupaciguara, 60);
            uberlandia.AdicionarVizinho(monteAlegre, 60);
            uberlandia.AdicionarVizinho(douradinhos, 63);
            uberlandia.AdicionarVizinho(araguari, 30);
            uberlandia.AdicionarVizinho(romaria, 78);
            uberlandia.AdicionarVizinho(indianopolis, 45);

            douradinhos.AdicionarVizinho(uberlandia, 63);
            douradinhos.AdicionarVizinho(monteAlegre, 28);
            douradinhos.AdicionarVizinho(ituiutaba, 90);


            araguari.AdicionarVizinho(uberlandia, 30);
            araguari.AdicionarVizinho(cascalho, 28);
            araguari.AdicionarVizinho(estrela, 34);

            cascalho.AdicionarVizinho(araguari, 28);
            cascalho.AdicionarVizinho(grupiara, 32);

            grupiara.AdicionarVizinho(cascalho, 32);
            grupiara.AdicionarVizinho(estrela, 38);

            estrela.AdicionarVizinho(araguari, 34);
            estrela.AdicionarVizinho(grupiara, 38);
            estrela.AdicionarVizinho(romaria, 27);

            romaria.AdicionarVizinho(estrela, 27);
            romaria.AdicionarVizinho(uberlandia, 78);
            romaria.AdicionarVizinho(saoJuliana, 28);

            saoJuliana.AdicionarVizinho(romaria, 28);
            saoJuliana.AdicionarVizinho(indianopolis, 40);

            indianopolis.AdicionarVizinho(saoJuliana, 40);
            indianopolis.AdicionarVizinho(uberlandia, 45);


            Grafo g = new Grafo();

            g.AdicionarCidade(itumbiara);
            g.AdicionarCidade(centralina);
            g.AdicionarCidade(capinopolis);
            g.AdicionarCidade(ituiutaba);
            g.AdicionarCidade(monteAlegre);
            g.AdicionarCidade(douradinhos);
            g.AdicionarCidade(tupaciguara);
            g.AdicionarCidade(uberlandia);
            g.AdicionarCidade(araguari);
            g.AdicionarCidade(cascalho);
            g.AdicionarCidade(grupiara);
            g.AdicionarCidade(estrela);
            g.AdicionarCidade(romaria);
            g.AdicionarCidade(saoJuliana);
            g.AdicionarCidade(indianopolis);



            // =================================

            Dictionary<string, Cidade> cidades = new Dictionary<string, Cidade>();

            // Adicionando todas as cidades existentes no grafo ao dicionário
            foreach (Cidade cidade in g.Cidades)
            {
                cidades.Add(cidade.Nome, cidade);
            }

            // Obtendo as cidades escolhidas pelo usuário

            
            string nomeCidadeOrigem = PegarCidadeOrigem(); // Obtido do usuário
            string nomeCidadeDestino = PegarCidadeDestino(); // Obtido do usuário

            if (nomeCidadeOrigem == "")
            {
                MessageBox.Show("Nenhuma cidade de origem foi selecionada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            else
            {
                Cidade origem = cidades[nomeCidadeOrigem];

                if (nomeCidadeDestino == "")
                {
                    MessageBox.Show("Nenhuma cidade de destino foi selecionada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Cidade destino = cidades[nomeCidadeDestino];

                    // Obtendo a menor distância e o caminho entre as cidades escolhidas pelo usuário
                    Tuple<int, List<Cidade>> resultado = g.MenorCaminhoDijkstra(origem, destino);
                    tbDistancia.Text = "A menor distância entre as duas cidades é de " + resultado.Item1.ToString() + " km.";


                    Tuple<int, List<Cidade>> resultado2 = g.MenorCaminhoDijkstra(origem, destino);
                    List<Cidade> caminhoEncontrado = resultado2.Item2;
                    if (caminhoEncontrado != null)
                    {
                        string caminho = origem.Nome + " -> ";
                        foreach (Cidade cidade in caminhoEncontrado)
                        {
                            caminho += cidade.Nome + " -> ";
                        }
                        caminho = caminho.Substring(0, caminho.Length - 4);
                        tbCaminho.Text = caminho;
                    }
                    else
                    {
                        tbCaminho.Text = "Não existe caminho entre as cidades selecionadas";
                    }
                }
                
            }
            
            

 


        }

        

        private void MudaBotao01(Button objBotao)
        {
            if (verificaBotao1() == false)
            {
                objBotao.BackColor = Color.Green;
                objBotao.FlatAppearance.MouseOverBackColor = Color.LightGreen;
                objBotao.Text = "1";
            }
        }

        private bool verificaBotao1()
        {
            bool temBotao = false;
            if (btItumbiara.Text == "1" || btCentralina.Text == "1" || btCapinopolis.Text == "1" || btItuiutaba.Text == "1" || btMonteAlegre.Text == "1" || btTupaciguara.Text == "1" || btDouradinhos.Text == "1" || btUberlandia.Text == "1" || btAraguari.Text == "1" || btCascalho.Text == "1"
                || btGrupiara.Text == "1" || btEstrela.Text == "1" || btRomaria.Text == "1" || btSaoJuliana.Text == "1" || btIndianopolis.Text == "1")
            {
                temBotao = true;
            }
            return temBotao;
        }

        private bool verificaBotao2()
        {
            bool temBotao = false;
            if (btItumbiara.Text == "2" || btCentralina.Text == "2" || btCapinopolis.Text == "2" || btItuiutaba.Text == "2" || btMonteAlegre.Text == "2" || btTupaciguara.Text == "2" || btDouradinhos.Text == "2" || btUberlandia.Text == "2" || btAraguari.Text == "2" || btCascalho.Text == "2"
                || btGrupiara.Text == "2" || btEstrela.Text == "2" || btRomaria.Text == "2" || btSaoJuliana.Text == "2" || btIndianopolis.Text == "2")
            {
                temBotao = true;
            }
            return temBotao;
        }

        private void MudaBotao02(Button objBotao)
        {
            if (verificaBotao2() == false & verificaBotao1() == true)
            {
                objBotao.BackColor = Color.Green;
                objBotao.FlatAppearance.MouseOverBackColor = Color.LightGreen;
                objBotao.Text = "2";
            }

        }

        private void ReiniciaBotao(Button objBotao)
        {
            objBotao.BackColor = Color.DodgerBlue;
            objBotao.FlatAppearance.MouseOverBackColor = Color.LightSkyBlue;
            objBotao.Text = "";
        }

        

        private void btReiniciar_Click(object sender, EventArgs e)
        {
            ReiniciaBotao(btItumbiara);
            ReiniciaBotao(btCentralina);
            ReiniciaBotao(btCapinopolis);
            ReiniciaBotao(btItuiutaba);
            ReiniciaBotao(btMonteAlegre);
            ReiniciaBotao(btDouradinhos);
            ReiniciaBotao(btTupaciguara);
            ReiniciaBotao(btUberlandia);
            ReiniciaBotao(btAraguari);
            ReiniciaBotao(btCascalho);
            ReiniciaBotao(btGrupiara);
            ReiniciaBotao(btEstrela);
            ReiniciaBotao(btRomaria);
            ReiniciaBotao(btSaoJuliana);
            ReiniciaBotao(btIndianopolis);
            tbCaminho.Text = "";
            tbDistancia.Text = "";
        }

        private string PegarCidadeOrigem()
        {
            string origem = "";

            if(btAraguari.Text == "1")
            {
                origem = "Araguari";
                return origem;
            }
            if (btItuiutaba.Text == "1")
            {
                origem = "Ituiutaba";
                return origem;
            }
            if (btItumbiara.Text == "1")
            {
                origem = "Itumbiara";
                return origem;
            }
            if (btCapinopolis.Text == "1")
            {
                origem = "Capinópolis";
                return origem;
            }
            if (btCentralina.Text == "1")
            {
                origem = "Centralina";
                return origem;
            }
            if (btMonteAlegre.Text == "1")
            {
                origem = "Monte Alegre de Minas";
                return origem;
            }
            if (btDouradinhos.Text == "1")
            {
                origem = "Douradinhos";
                return origem;
            }
            if (btTupaciguara.Text == "1")
            {
                origem = "Tupaciguara";
                return origem;
            }
            if (btUberlandia.Text == "1")
            {
                origem = "Uberlândia";
                return origem;
            }
            if (btCascalho.Text == "1")
            {
                origem = "Cascalho Rico";
                return origem;
            }
            if (btGrupiara.Text == "1")
            {
                origem = "Grupiara";
                return origem;
            }
            if (btEstrela.Text == "1")
            {
                origem = "Estrela do Sul";
                return origem;
            }
            if (btRomaria.Text == "1")
            {
                origem = "Romaria";
                return origem;
            }
            if (btSaoJuliana.Text == "1")
            {
                origem = "São Juliana";
                return origem;
            }
            if (btIndianopolis.Text == "1")
            {
                origem = "Indianópolis";
                return origem;
            }


            return origem;
        }

        private string PegarCidadeDestino()
        {
            string destino = "";
            if(btItumbiara.Text == "2")
            {
                destino = "Itumbiara";
                return destino;
            }
            if (btCentralina.Text == "2")
            {
                destino = "Centralina";
                return destino;
            }
            if (btCapinopolis.Text == "2")
            {
                destino = "Capinópolis";
                return destino;
            }
            if (btItuiutaba.Text == "2")
            {
                destino = "Ituiutaba";
                return destino;
            }
            if (btDouradinhos.Text == "2")
            {
                destino = "Douradinhos";
                return destino;
            }
            if (btMonteAlegre.Text == "2")
            {
                destino = "Monte Alegre de Minas";
                return destino;
            }
            if (btTupaciguara.Text == "2")
            {
                destino = "Tupaciguara";
                return destino;
            }
            if (btUberlandia.Text == "2")
            {
                destino = "Uberlândia";
                return destino;
            }
            if (btAraguari.Text == "2")
            {
                destino = "Araguari";
                return destino;
            }
            if (btIndianopolis.Text == "2")
            {
                destino = "Indianópolis";
                return destino;
            }
            if (btCascalho.Text == "2")
            {
                destino = "Cascalho Rico";
                return destino;
            }
            if (btGrupiara.Text == "2")
            {
                destino = "Grupiara";
                return destino;
            }
            if (btEstrela.Text == "2")
            {
                destino = "Estrela do Sul";
                return destino;
            }
            if (btRomaria.Text == "2")
            {
                destino = "Romaria";
                return destino;
            }
            if (btSaoJuliana.Text == "2")
            {
                destino = "São Juliana";
                return destino;
            }
            return destino;
        }

        private void btAraguari_Click(object sender, EventArgs e)
        {
            MudaBotao01(btAraguari);
            if (btAraguari.Text == "")
            {
                MudaBotao02(btAraguari);
            }
        }

        private void btItumbiara_Click(object sender, EventArgs e)
        {
            MudaBotao01(btItumbiara);
            if (btItumbiara.Text == "")
            {
                MudaBotao02(btItumbiara);
            }
        }
        private void btItuiutaba_Click(object sender, EventArgs e)
        {
            MudaBotao01(btItuiutaba);
            if (btItuiutaba.Text == "")
            {
                MudaBotao02(btItuiutaba);
            }

        }

        private void btCentralina_Click(object sender, EventArgs e)
        {
            MudaBotao01(btCentralina);
            if (btCentralina.Text == "")
            {
                MudaBotao02(btCentralina);
            }
        }

        private void btCapinopolis_Click(object sender, EventArgs e)
        {
            MudaBotao01(btCapinopolis);
            if (btCapinopolis.Text == "")
            {
                MudaBotao02(btCapinopolis);
            }


        }

        private void btDouradinhos_Click(object sender, EventArgs e)
        {
            MudaBotao01(btDouradinhos);
            if (btDouradinhos.Text == "")
            {
                MudaBotao02(btDouradinhos);
            }
        }

        private void btMonteAlegre_Click(object sender, EventArgs e)
        {
            MudaBotao01(btMonteAlegre);
            if (btMonteAlegre.Text == "")
            {
                MudaBotao02(btMonteAlegre);
            }
        }

        private void btTupaciguara_Click(object sender, EventArgs e)
        {
            MudaBotao01(btTupaciguara);
            if (btTupaciguara.Text == "")
            {
                MudaBotao02(btTupaciguara);
            }
        }

        private void btUberlandia_Click(object sender, EventArgs e)
        {
            MudaBotao01(btUberlandia);
            if (btUberlandia.Text == "")
            {
                MudaBotao02(btUberlandia);
            }
        }

        private void btCascalho_Click(object sender, EventArgs e)
        {
            MudaBotao01(btCascalho);
            if (btCascalho.Text == "")
            {
                MudaBotao02(btCascalho);
            }
        }

        private void btGrupiara_Click(object sender, EventArgs e)
        {
            MudaBotao01(btGrupiara);
            if (btGrupiara.Text == "")
            {
                MudaBotao02(btGrupiara);
            }
        }

        private void btEstrela_Click(object sender, EventArgs e)
        {
            MudaBotao01(btEstrela);
            if (btEstrela.Text == "")
            {
                MudaBotao02(btEstrela);
            }
        }

        private void btRomaria_Click(object sender, EventArgs e)
        {
            MudaBotao01(btRomaria);
            if (btRomaria.Text == "")
            {
                MudaBotao02(btRomaria);
            }
        }

        private void btSaoJuliana_Click(object sender, EventArgs e)
        {
            MudaBotao01(btSaoJuliana);
            if (btSaoJuliana.Text == "")
            {
                MudaBotao02(btSaoJuliana);
            }
        }

        private void btIndianopolis_Click(object sender, EventArgs e)
        {
            MudaBotao01(btIndianopolis);
            if (btIndianopolis.Text == "")
            {
                MudaBotao02(btIndianopolis);
            }

        }

        
    }
}
