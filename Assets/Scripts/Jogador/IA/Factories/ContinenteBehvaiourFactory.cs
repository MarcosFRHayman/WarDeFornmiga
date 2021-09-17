using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Jogadores.IA
{
    public class ContinenteBehvaiourFactory : BehaviourFactory
    {
        public ContinenteBehvaiourFactory(ObjetivoPorContinente objetivo) : base(objetivo)
        {
        }

        public override ObjetivoBehaviour criaBehaviour(int dificuldade)
        {
            return new ContinenteBehaviour((ObjetivoPorContinente)objetivo, dificuldade);
        }
    }
}
