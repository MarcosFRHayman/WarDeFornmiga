using System.Linq;
using System.Collections;
using System.Collections.Generic;
using FormigaWar.Territorios;
using UnityEngine;

namespace FormigaWar.Jogadores.IA
{
    public abstract class GenericObjetivoBehaviour<T> : ObjetivoBehaviour where T : Objetivo
    {

        public readonly T objetivo;
        protected Dictionary<TerritorioDisplay, int> PrioridadesMap;
        protected readonly int dificuldade;

        public GenericObjetivoBehaviour(T objetivo, int dificuldade)
        {
            this.objetivo = objetivo;
            this.dificuldade = dificuldade;
            PrioridadesMap = objetivo.tabuleiro.TerritoriosInstanciados.ToDictionary(k => k, v => 1);
            PrioridadesMap.ToList().ForEach(dic => Debug.Log("Territorio: " + dic.Key.name + "\nPrioridade 1: " + dic.Value));

            PintarTerritorios();
        }
        /// <summary>Determina as prioridades</summary>
        protected abstract void PintarTerritorios();

        public int GetPrioridade(TerritorioDisplay territorio) => PrioridadesMap[territorio];
        /// <summary>Decide o ponto de partida e destino de um ataque</summary>
        /// <returns>(null, null) se não houver alvos disponíveis</returns>
        public virtual (TerritorioDisplay partida, TerritorioDisplay destino) DecideAlvo(List<TerritorioDisplay> candidatos)
        {
            TerritorioDisplay partida = null;
            TerritorioDisplay destino = null;
            partida = candidatos
                .FirstOrDefault(candidato =>
               {
                   var fronteiraMaisPrioritaria =
                    candidato
                   .fronteirasDisplay
                   .Intersect(PrioridadesMap.Keys.ToList())
                   .OrderBy(comum =>
                     PrioridadesMap[comum]
                    )
                    .FirstOrDefault();
                   destino = fronteiraMaisPrioritaria;
                   return destino != default(TerritorioDisplay);
               });
            return (partida, destino);
        }

        public virtual IOrderedEnumerable<KeyValuePair<TerritorioDisplay, List<TerritorioDisplay>>> DecideAlvos(List<TerritorioDisplay> candidatos)
        {
            return candidatos
                .Distinct()
                .ToDictionary(k => k, v => v.fronteirasDisplay
                    .Intersect(PrioridadesMap.Keys.ToList())
                    .OrderBy(comum => PrioridadesMap[comum])
                    .ToList()
                )
                .Where(dictionary => dictionary.Value.Count > 0)
                .OrderBy(dicitionary => PrioridadesMap[dicitionary.Value[0]]);
        }

        protected void PreencheContinente(Continente continente)
            => PreencheContinente(continente, dificuldade);

        protected void PreencheContinente(Continente continente, int dificuldade)
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
        protected void UpdatePrioridade(TerritorioDisplay territorio, int novoValor)
        {
            int valorAntigo = PrioridadesMap[territorio];
            PrioridadesMap[territorio] = novoValor;
            if (novoValor > valorAntigo) AumentaPrioridadeRecursivo(territorio);
            if (novoValor < valorAntigo) DiminuiPrioridadeRecursivo(territorio);
        }
        private void AumentaPrioridadeRecursivo(TerritorioDisplay territorio)
        {
            territorio.fronteirasDisplay.ForEach(
                fronteira =>
                {
                    var valorNovo = PrioridadesMap[territorio];
                    if (PrioridadesMap[fronteira] < valorNovo - 1 && valorNovo > 1)
                    {
                        PrioridadesMap[fronteira] = valorNovo - 1;
                        AumentaPrioridadeRecursivo(fronteira);
                    }
                }
            );
        }
        private void DiminuiPrioridadeRecursivo(TerritorioDisplay territorio)
        {
            territorio.fronteirasDisplay.ForEach(
                fronteira =>
                {
                    var valorNovo = PrioridadesMap[territorio];
                    if (!fronteira.fronteirasDisplay.Exists((fronteira2)
                            => fronteira2 != territorio &&
                            PrioridadesMap[fronteira2] >= valorNovo))
                    {
                        PrioridadesMap[fronteira] = valorNovo - 1;
                        DiminuiPrioridadeRecursivo(fronteira);
                    }
                    // if(findPrioridades[fronteira] == valorAntigo - 1)
                    //     UpdatePrioridade(fronteira, findPrioridades[territorio] - 1);
                }
            );
        }
    }
}
