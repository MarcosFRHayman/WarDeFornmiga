using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar
{
    public class TerritoriosBehaviourFactory : BehaviourFactory
    {
        public TerritoriosBehaviourFactory(ObjetivoPorTerritorio objetivo) : base(objetivo)
        {
        }

        public override ObjetivoBehaviour criaBehaviour(int dificuldade)
        {
            return new TerritorioBehaviour((ObjetivoPorTerritorio)objetivo, dificuldade);
        }
    }
}
