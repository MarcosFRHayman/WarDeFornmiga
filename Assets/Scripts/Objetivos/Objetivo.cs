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
        public Jogador jogador { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }
        public BehaviourFactory behaviourFactory { get; protected set; }
        public abstract bool Checar(); // metodo checa se o objetivo foi completado.
    }
}