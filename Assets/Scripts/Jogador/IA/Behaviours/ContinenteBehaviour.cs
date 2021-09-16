using System.Collections;
using System.Collections.Generic;
using FormigaWar.Territorios;
using UnityEngine;

namespace FormigaWar.Jogadores.IA
{
    public class ContinenteBehaviour : GenericObjetivoBehaviour<ObjetivoPorContinente>
    {
        public ContinenteBehaviour(ObjetivoPorContinente objetivo, int dificuldade)
        : base(objetivo, dificuldade)
        {
        }
        protected override void PintarTerritorios()
        {
            List<TerritorioDisplay> territoriosNosContinentes = new List<TerritorioDisplay>();
            foreach (var continente in objetivo.Continentes)
            {
                territoriosNosContinentes.AddRange(objetivo.tabuleiro.ContinentesDisplay[continente]);
            }
        }
    }
}
