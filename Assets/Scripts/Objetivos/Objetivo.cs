using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Jogadores;
using FormigaWar.Jogadores.IA;

namespace FormigaWar
{
    public abstract class Objetivo
    {
        protected string descricao;
        protected Jogador jogador;
        public Tabuleiro tabuleiro { get; private set; }
        public BehaviourFactory behaviourFactory { get; protected set; }
        public abstract bool Checar(); // metodo checa se o objetivo foi completado.
    }
}