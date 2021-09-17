using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Jogadores.IA
{
    public class EliminacaoBehaviourFactory : BehaviourFactory
    {
        public EliminacaoBehaviourFactory(ObjetivoPorExercito objetivo) : base(objetivo)
        {
        }

        public override ObjetivoBehaviour criaBehaviour(int dificuldade)
        {
            return new ElimanacaoBehaviour((ObjetivoPorExercito)objetivo, dificuldade);
        }
    }
}
