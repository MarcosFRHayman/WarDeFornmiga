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
        protected List<Carta> mao = new List<Carta>();
        public Carta[] GetMao() => mao.ToArray();
        public int reservas; // qtd de tropas para a fase de fortificacao

        public void AddCarta(Carta c)
        {
            mao.Add(c);
            //Debug.Log("Mão do jogador agora tem " + mao.Count + " cartas");
        }

        public void CalcularReservas(int TropaContinente)
        {
            if(TurnoManager.faseAtual == 0) reservas = TropaContinente;
            else reservas = (int)Territorios.Count / 2;
        }

        public void Fortificar()
        {
            // TurnoManager.AvancarTurno()
        }
        public void Atacar()
        {
            // TurnoManager.AvancarTurno()
        }
        public void Mover()
        {
            // TurnoManager.AvancarTurno()
        }


    }
}