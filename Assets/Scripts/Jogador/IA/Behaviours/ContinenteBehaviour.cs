using System;
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
    // public class Pair<T>
    // {
    //     public T primeiro;
    //     public T segundo;
    //     public Pair(T primeiro, T segundo)
    //     {
    //         this.primeiro = primeiro;
    //         this.segundo = segundo;
    //     }
    // }
    // public static class IEnumerableExtension
    // {
    //     public static Pair<IEnumerable<T>> DivideOn<T>(this IEnumerable<T> enumerable, Func<T, bool> condicao)
    //     {
    //         return new Pair<IEnumerable<T>>(enumerable.Where(condicao),
    //          enumerable.Where(item => condicao.Invoke(item)));
    //     }
    // }
}
