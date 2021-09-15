using System.Collections;
using System.Collections.Generic;
using FormigaWar.Territorios;
using UnityEngine;

namespace FormigaWar
{
    public class ContinenteBehaviour : GenericObjetivoBehaviour<ObjetivoPorContinente>
    {
        private ObjetivoPorContinente objetivoContinent { get => (ObjetivoPorContinente)objetivo; }
        public ContinenteBehaviour(ObjetivoPorContinente objetivo, int dificuldade)
        : base(objetivo, dificuldade)
        {
        }
        protected override void PintarTerritorios()
        {
            List<TerritorioDisplay> territoriosNosContinentes = new List<TerritorioDisplay>();
            foreach (var continente in objetivoContinent.Continentes)
            {

            }

        }
    }
}
