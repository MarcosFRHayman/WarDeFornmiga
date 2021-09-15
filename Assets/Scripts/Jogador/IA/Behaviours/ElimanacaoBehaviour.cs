using System.Collections;
using System.Collections.Generic;
using FormigaWar.Territorios;
using UnityEngine;

namespace FormigaWar
{
    public class ElimanacaoBehaviour : GenericObjetivoBehaviour<ObjetivoPorExercito>
    {
        public ElimanacaoBehaviour(ObjetivoPorExercito objetivo, int dificuldade)
        : base(objetivo, dificuldade)
        {
        }
        protected override void PintarTerritorios()
        {
            throw new System.NotImplementedException();
        }
    }
}
