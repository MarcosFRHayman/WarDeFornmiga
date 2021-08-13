using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;

namespace FormigaWar.jogador
{
    public class Mesa
    {
        public readonly Tabuleiro tabuleiro;
        public readonly Jogador[] jogadores;
        public Mesa(Tabuleiro tabuleiro, Jogador[] jogadores)
        {
            this.tabuleiro = tabuleiro;
            this.jogadores = jogadores;
        }
        public void DistribuiTerritorios()
        {
            List<TerritorioDisplay> territoriosEmbaralhados = EmbaralhaTerritorios();
            DistribuiParaJogadores(territoriosEmbaralhados);
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
    }
}
