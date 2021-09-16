using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Jogadores.IA
{
    public abstract class BehaviourFactory
    {
        protected readonly Objetivo objetivo;
        public BehaviourFactory(Objetivo objetivo)
        {
            this.objetivo = objetivo;
        }
        public abstract ObjetivoBehaviour criaBehaviour(int dificuldade);
    }
}
