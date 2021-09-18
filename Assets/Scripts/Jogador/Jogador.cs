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
        public Mesa mesa;
        public List<TerritorioDisplay> Territorios { get; protected set; } = new List<TerritorioDisplay>();
        public List<Continente> continentes { get; protected set; } = new List<Continente>();
        public Objetivo objetivo;
        protected List<Carta> mao = new List<Carta>();
        public Carta[] GetMao() => mao.ToArray();
        public int reservas = 0; // qtd de tropas para a fase de fortificacao

        public void AddCarta(Carta c)
        {
            mao.Add(c);
            //Debug.Log("Mão do jogador agora tem " + mao.Count + " cartas");
        }

        public void CalcularReservas(int TropaContinente)
        {
            if (TurnoManager.faseAtual == 0) reservas = TropaContinente;
            else
            {
                reservas = (int)Territorios.Count / 2;
                if (reservas < 3) reservas = 3;
            }
        }

        protected void Fortificar(int tropas, TerritorioDisplay destino)
        {
            destino.NumTropas += tropas;
            destino.AtualizarNumTropas();
            // TurnoManager.AvancarTurno()
        }
        protected bool Atacar(TerritorioDisplay tdAtacante, TerritorioDisplay tdDefensor)
        {/*
            List<int> dadosatacantes = new List<int>();
            List<int> dadosdefensores = new List<int>();
            
            for(int i = 0; i < 3; i++) // Rolando os dados
            {
                if ((tdAtacante.NumTropas - 1) >= (i + 1))
                {
                    dadosatacantes.Add(Random.Range(1, 6));
                    dadosatacantes.Sort();
                }
                if ((tdDefensor.NumTropas - 1) >= i)
                {
                    dadosdefensores.Add(Random.Range(1, 6));
                    dadosdefensores.Sort();
                }
            }

            dadosatacantes.Reverse();
            dadosdefensores.Reverse();

            if (dadosatacantes.Count <= dadosdefensores.Count) // Comparando os dados
            {
                for (int i = 0; i < dadosatacantes.Count; i++)
                {
                    if (dadosatacantes[i] > dadosdefensores[i])
                    {
                        tdDefensor.NumTropas -= 1;
                        tdDefensor.AtualizarNumTropas();
                    }
                    else
                    {
                        tdAtacante.NumTropas -= 1;
                        tdAtacante.AtualizarNumTropas();
                    }
                }
            }
            if(tdDefensor.NumTropas == 0) // Calculando o resultado
            {
                tdDefensor.ConquistaTerritorio(this);
                return true;
            }
            else */return false;
            // TurnoManager.AvancarTurno()
        }
        protected void Mover(int tropas, TerritorioDisplay partida, TerritorioDisplay destino)
        {
            partida.NumTropas -= tropas;
            destino.numtropas_to_move += tropas;
            partida.AtualizarNumTropas();
            destino.AtualizarNumTropas();
            // TurnoManager.AvancarTurno()
        }
        public virtual void recebeObjetivo(Objetivo objetivo)
        {
            objetivo.jogador = this;
            this.objetivo = objetivo;
            objetivo.jogador = this;
        }


    }
}