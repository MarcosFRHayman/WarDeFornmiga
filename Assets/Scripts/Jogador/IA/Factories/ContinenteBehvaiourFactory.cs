using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar
{
    public class ContinenteBehvaiourFactory : BehaviourFactory
    {
        public ContinenteBehvaiourFactory(ObjetivoPorContinente objetivo) : base(objetivo)
        {
        }

        public override ObjetivoBehaviour criaBehaviour()
        {
            return new ContinenteBehaviour((ObjetivoPorContinente)objetivo, 5);
        }
    }
}
