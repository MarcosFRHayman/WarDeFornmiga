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
            RoladorDeDados.onCaptura += AlteraPrioridade;
        }
        private void AlteraPrioridade(Jogador jogador, TerritorioDisplay display)
        {
            if (jogador.Equals(objetivo.nemesis))
                UpdatePrioridade(display, dificuldade);
            else if (PrioridadesMap[display] == dificuldade)
                UpdatePrioridade(display, 1);
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
