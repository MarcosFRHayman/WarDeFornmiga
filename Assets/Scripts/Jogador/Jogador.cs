using System.Collections;
using System.Collections.Generic;
using FormigaWar.Territorios;
using UnityEngine;

namespace FormigaWar.Jogador
{
    public abstract class Jogador
    {
        private Color cor;
        public Color Cor { get; internal set; }
        protected List<TerritorioDisplay> territorioDisplay;
        protected List<Continente> continentes;
        protected List<Carta> mao;
        public List<TerritorioDisplay> Territorios => territorioDisplay;
    }
}