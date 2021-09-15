using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar
{
    public class EliminacaoBehaviourFactory : BehaviourFactory
    {
        public EliminacaoBehaviourFactory(ObjetivoPorExercito objetivo) : base(objetivo)
        {
        }

        public override ObjetivoBehaviour criaBehaviour()
        {
            throw new System.NotImplementedException();
        }
    }
}
