using System.Collections;
using System.Collections.Generic;
using FormigaWar.Territorios;
using UnityEngine;

namespace FormigaWar.jogador
{
    public abstract class Jogador
    {
        private Color cor;
        public Color Cor { get; internal set; }
        private List<TerritorioDisplay> territorioDisplay;
        private List<Continente> continentes;
        private List<Carta> mao;
    }
}