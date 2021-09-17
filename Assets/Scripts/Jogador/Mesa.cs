using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;

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

            tabuleiro.TerritoriosInstanciados[0].ConquistaTerritorio(j);
            tabuleiro.TerritoriosInstanciados[1].ConquistaTerritorio(j);
            tabuleiro.TerritoriosInstanciados[2].ConquistaTerritorio(j);
            tabuleiro.TerritoriosInstanciados[3].ConquistaTerritorio(j);
            tabuleiro.TerritoriosInstanciados[4].ConquistaTerritorio(j);
            tabuleiro.TerritoriosInstanciados[5].ConquistaTerritorio(j);
            tabuleiro.TerritoriosInstanciados[6].ConquistaTerritorio(j);
            tabuleiro.TerritoriosInstanciados[7].ConquistaTerritorio(j);
            tabuleiro.TerritoriosInstanciados[8].ConquistaTerritorio(j);

            //j.objetivo = new ObjetivoPorExercito(k);

            Jogador k = new JogadorHumano(); j.objetivo = new ObjetivoPorExercito(k);
            k.Cor = Color.yellow;

            tabuleiro.TerritoriosInstanciados[9].ConquistaTerritorio(k);
            tabuleiro.TerritoriosInstanciados[10].ConquistaTerritorio(k);
            tabuleiro.TerritoriosInstanciados[11].ConquistaTerritorio(k);

            List<Continente>conts = new List<Continente>(); conts.Add(tabuleiro.Continentes[4]);
            k.objetivo = new ObjetivoPorContinente(conts, 0);

            jogadores = new Jogador[2] { j, k };
            
            InicializaBaralhoComTabuleiro();
            GetComponent<RoladorDeDados>().baralhoDeCartas = baralhoTerritorios;

            TurnoManager.InicializarManager(jogadores);
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
            int valorParaCada = territoriosEmbaralhados.Count / jogadores.Length;
            int sobra = territoriosEmbaralhados.Count % jogadores.Length;
            for (int i = 0; i < jogadores.Length; i++)
            {
                jogadores[i].Territorios.Clear();
                //Dá os Territorios que sobraram da divisao para os n primeiros jogadores
                if (sobra > 0)
                {
                    jogadores[i].Territorios.Add(territoriosEmbaralhados[territoriosEmbaralhados.Count - sobra]);
                    sobra--;
                }
                int inicio = i * valorParaCada;
                int fim = (i + 1) * valorParaCada - 1;
                jogadores[i].Territorios.AddRange(territoriosEmbaralhados.GetRange(inicio, fim));
            }
        }
    }
}
