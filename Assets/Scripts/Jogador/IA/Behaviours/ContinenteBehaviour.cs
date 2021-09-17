using System.Linq;
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
            foreach (var continente in objetivo.Continentes)
            {
                PreencheContinente(continente);
            }
            var continenteStrategy = new ContinenteComMaisTropaStrategy((JogadorIA)objetivo.jogador);
            for (int i = 0; i < objetivo.ContinenteAEscolha; i++)
            {
                PreencheContinente(continenteStrategy.EncontraProximo());
            }
        }
    }
}
