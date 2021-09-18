using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;
using FormigaWar.Jogadores.IA;

namespace FormigaWar.Jogadores
{
    public class Mesa : MonoBehaviour
    {
        [SerializeField] private Tabuleiro tabuleiro = new Tabuleiro();
        private BaralhoDeCartas baralhoTerritorios;
        private Jogador[] jogadores;

        // #if UNITY_EDITOR
        void Start()
        {
            tabuleiro?.Inicializa();
            TurnoManager.tabuleiro = tabuleiro; // o turnomanager precisa do tabuleiro para aplicar o movimento nas tropas

            // essa parte toda aqui é de testes, pode comentar ou deletar caso nao esteja na branch 2.3

            Jogador j = new JogadorHumano();
            j.Cor = Color.cyan;

            Jogador k = new JogadorHumano();
            k.Cor = Color.yellow;

            Jogador l = new JogadorHumano();
            l.Cor = Color.red;

            Jogador m = new JogadorIA(1);
            m.Cor = Color.green;

            jogadores = new Jogador[4] { j, k, l, m };
            TurnoManager.InicializarManager(jogadores);

            BaralhoDeObjetivo.InicializaBaralho(
                tabuleiro, jogadores,     // tabuleiro e jogadores
                tabuleiro.Continentes[1], // N
                tabuleiro.Continentes[0], // NO e NOO
                tabuleiro.Continentes[2], // NL
                tabuleiro.Continentes[4], // SO
                tabuleiro.Continentes[5], // SL
                tabuleiro.Continentes[3]  // C
            );


            // tabuleiro.TerritoriosInstanciados[0].ConquistaTerritorio(j);
            // tabuleiro.TerritoriosInstanciados[1].ConquistaTerritorio(j);
            // tabuleiro.TerritoriosInstanciados[2].ConquistaTerritorio(j);
            // tabuleiro.TerritoriosInstanciados[3].ConquistaTerritorio(j);
            // tabuleiro.TerritoriosInstanciados[4].ConquistaTerritorio(j);
            // tabuleiro.TerritoriosInstanciados[5].ConquistaTerritorio(j);
            // tabuleiro.TerritoriosInstanciados[6].ConquistaTerritorio(j);
            // tabuleiro.TerritoriosInstanciados[7].ConquistaTerritorio(j);
            // tabuleiro.TerritoriosInstanciados[8].ConquistaTerritorio(j);

            // tabuleiro.TerritoriosInstanciados[9].ConquistaTerritorio(k);
            // tabuleiro.TerritoriosInstanciados[10].ConquistaTerritorio(k);

            // tabuleiro.TerritoriosInstanciados[11].ConquistaTerritorio(l);
            // tabuleiro.TerritoriosInstanciados[12].ConquistaTerritorio(l);

            // tabuleiro.TerritoriosInstanciados[20].ConquistaTerritorio(m);
            // tabuleiro.TerritoriosInstanciados[21].ConquistaTerritorio(m);
            InicializaBaralhoComTabuleiro();
            DistribuiTerritorios();

            foreach (Jogador jouer in jogadores) jouer.recebeObjetivo(BaralhoDeObjetivo.PuxarCarta());

            GetComponent<RoladorDeDados>().baralhoDeCartas = baralhoTerritorios;
            // fim dos testes
        }

        // #endif
        public void Inicializa(Jogador[] jogadores)
        {
            this.jogadores = jogadores;
            tabuleiro?.Inicializa();
            InicializaBaralhoComTabuleiro();
            DistribuiTerritorios();
        }
        private void InicializaBaralhoComTabuleiro()
        {
            baralhoTerritorios = new BaralhoDeCartas();
            List<Territorio> territorioLista = new List<Territorio>();
            foreach (Continente continente in tabuleiro.Continentes)
                territorioLista.AddRange(continente.GetTerritorios());
            baralhoTerritorios.Inicializar(territorioLista);
        }
        public void DistribuiTerritorios()
        {
            List<TerritorioDisplay> territoriosEmbaralhados = EmbaralhaTerritorios();
            DistribuiParaJogadores(territoriosEmbaralhados);
        }
        private List<TerritorioDisplay> EmbaralhaTerritorios()
        {
            List<TerritorioDisplay> territorios = new List<TerritorioDisplay>();
            territorios.AddRange(tabuleiro.TerritoriosInstanciados);
            List<TerritorioDisplay> territoriosEmbaralhados = new List<TerritorioDisplay>();
            while (territorios.Count > 0)
            {
                TerritorioDisplay escolhido = territorios[(int)UnityEngine.Random.Range(0, territorios.Count)];
                territorios.Remove(escolhido);
                territoriosEmbaralhados.Add(escolhido);
            }

            return territoriosEmbaralhados;
        }
        private void DistribuiParaJogadores(List<TerritorioDisplay> territoriosEmbaralhados)
        {
            Debug.Log(territoriosEmbaralhados.Count);
            int valorParaCada = territoriosEmbaralhados.Count / jogadores.Length;
            int sobra = territoriosEmbaralhados.Count % jogadores.Length;
            for (int i = 0; i < jogadores.Length; i++)
            {
                jogadores[i].Territorios.Clear();
                //Dá os Territorios que sobraram da divisao para os n primeiros jogadores
                if (sobra > 0)
                {
                    territoriosEmbaralhados[territoriosEmbaralhados.Count - sobra].ConquistaTerritorio(jogadores[i]);
                    // jogadores[i].Territorios.Add(territoriosEmbaralhados[territoriosEmbaralhados.Count - sobra]);
                    sobra--;
                }
                int inicio = i * valorParaCada;
                territoriosEmbaralhados
                    .GetRange(inicio, valorParaCada)
                    .ForEach(t => t.ConquistaTerritorio(jogadores[i]));
                // jogadores[i].Territorios.AddRange(territoriosEmbaralhados.GetRange(inicio, fim));
            }
        }
    }
}
