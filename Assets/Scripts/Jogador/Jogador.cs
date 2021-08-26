using System.Collections;
using System.Collections.Generic;
using FormigaWar.Territorios;
using UnityEngine;

namespace FormigaWar.Jogadores
{
    public abstract class Jogador
    {
        private Color cor;
        public Color Cor { get; internal set; }
        public List<TerritorioDisplay> Territorios { get; protected set; } = new List<TerritorioDisplay>();
        public List<Continente> continentes { get; protected set; }
        public Objetivo objetivo;
        protected List<Carta> mao;
    }
}