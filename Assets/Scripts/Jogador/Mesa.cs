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
        private Jogador[] jogadores;

        void Start()
        {
            tabuleiro?.Inicializa();
            
            // essa parte toda aqui é de testes, pode comentar ou deletar caso nao esteja na branch 2.3
            Jogador j = new JogadorHumano();
            j.Cor = Color.cyan; 
            j.Territorios.Add(tabuleiro.TerritoriosInstanciados[0]);
            j.Territorios.Add(tabuleiro.TerritoriosInstanciados[1]);
            j.Territorios.Add(tabuleiro.TerritoriosInstanciados[2]);
            j.Territorios.Add(tabuleiro.TerritoriosInstanciados[3]);
            j.Territorios.Add(tabuleiro.TerritoriosInstanciados[4]);
            List<TerritorioDisplay> jTerritorios = new List<TerritorioDisplay>(); 
            foreach(TerritorioDisplay t in j.Territorios)
            {
                jTerritorios.Add(t);
            }
            foreach(TerritorioDisplay t in jTerritorios)
            {
                t.ConquistaTerritorio(j);
            }
            jogadores = new Jogador[1] {j};
            // fim da sessão de testes, cuidado com o que apaga abaixo

            TurnoManager.InicializarManager(jogadores);
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
