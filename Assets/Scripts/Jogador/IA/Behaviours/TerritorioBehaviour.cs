using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;

namespace FormigaWar.Jogadores.IA
{
    public class TerritorioBehaviour : GenericObjetivoBehaviour<ObjetivoPorTerritorio>
    {
        public TerritorioBehaviour(ObjetivoPorTerritorio objetivo, int dificuldade) : base(objetivo, dificuldade)
        {
        }

        protected override void PintarTerritorios()
        {
            var continenteStrategy = new ContinenteComMaisTropaStrategy((JogadorIA)objetivo.jogador);
            int territoriosEscolhidos = 0;
            while (territoriosEscolhidos < objetivo.territoriosNecessarios)
            {
                var continente = continenteStrategy.EncontraProximo();
                PreencheContinente(continente);
                territoriosEscolhidos += continente.GetTerritorios().Count;
            }
        }
        private void PreencheContinente(Continente continente)
        {
            objetivo.tabuleiro
            .ContinentesDisplay[continente]
            .ForEach(territorio =>
            {
                if (territorio.fronteirasDisplay.Exists(
                    fronteira =>
                    !fronteira.Territorio.Continente.Equals(continente)
                )) UpdatePrioridade(territorio, dificuldade);
                else PrioridadesMap[territorio] = dificuldade;
            });
        }
    }
}
