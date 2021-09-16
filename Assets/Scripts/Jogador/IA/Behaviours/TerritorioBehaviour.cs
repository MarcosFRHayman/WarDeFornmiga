using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Jogadores.IA
{
    public class TerritorioBehaviour : GenericObjetivoBehaviour<ObjetivoPorTerritorio>
    {
        public TerritorioBehaviour(ObjetivoPorTerritorio objetivo, int dificuldade) : base(objetivo, dificuldade)
        {
        }

        protected override void PintarTerritorios()
        {
            throw new System.NotImplementedException();
        }
    }
}
