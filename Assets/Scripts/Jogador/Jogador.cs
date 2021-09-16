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
        public List<Continente> continentes { get; protected set; } = new List<Continente>();
        public Objetivo objetivo;
        protected List<Carta> mao;
        public int reservas; // qtd de tropas para a fase de fortificacao

        public void AddCarta(Carta c)
        {
            mao.Add(c);
        }

        public void CalcularReservas()
        {
            foreach(TerritorioDisplay t in Territorios)
            {
                
                //Debug.Log(t.Territorio);
                reservas += 2; // TODO: Checar quantas tropas por territorio
            }
        }


    }
}