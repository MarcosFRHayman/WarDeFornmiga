using System.Collections;
using System.Collections.Generic;
using FormigaWar.Territorios;
using UnityEngine;

namespace FormigaWar.Jogadores.IA
{
    public class ElimanacaoBehaviour : GenericObjetivoBehaviour<ObjetivoPorExercito>
    {
        public ElimanacaoBehaviour(ObjetivoPorExercito objetivo, int dificuldade)
        : base(objetivo, dificuldade)
        {
        }
        protected override void PintarTerritorios()
        {
            var continenteStrategy = new ContinenteComMaisTropaStrategy((JogadorIA)objetivo.jogador);
            PreencheContinente(continenteStrategy.EncontraProximo(), dificuldade / 2);
            PreencheContinente(continenteStrategy.EncontraProximo(), dificuldade / 2);
            objetivo.nemesis.Territorios.ForEach(
                territorio =>
                    UpdatePrioridade(territorio, dificuldade)
            );
        }
    }
}
