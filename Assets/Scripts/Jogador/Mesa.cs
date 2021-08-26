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
        [SerializeField] private Jogador[] jogadores;
        public Jogador[] Jogadores {get; set;} // esse get eh usado pelo ObjetivoPorExercito

        void Start()
        {
            tabuleiro?.Inicializa();
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
                jogadores[i].territorioDisplay.Clear();
                //Dá os Territorios que sobraram da divisao para os n primeiros jogadores
                if (sobra > 0)
                {
                    jogadores[i].territorioDisplay.Add(territoriosEmbaralhados[territoriosEmbaralhados.Count - sobra]);
                    sobra--;
                }
                int inicio = i * valorParaCada;
                int fim = (i + 1) * valorParaCada - 1;
                jogadores[i].territorioDisplay.AddRange(territoriosEmbaralhados.GetRange(inicio, fim));
            }
        }
    }
}
