using System.Collections;
using System.Collections.Generic;
using FormigaWar.Territorios;
using UnityEngine;

namespace FormigaWar
{
    public abstract class GenericObjetivoBehaviour<T> : ObjetivoBehaviour where T : Objetivo
    {

        public readonly T objetivo;
        public Prioridade[] prioridades { get; protected set; }
        protected readonly int dificuldade;

        public GenericObjetivoBehaviour(T objetivo, int dificuldade)
        {
            this.objetivo = objetivo;
            this.dificuldade = dificuldade;
            prioridades = new Prioridade[dificuldade];
            PintarTerritorios();
        }
        /// <summary>Decide o ponto de partida e destino de um ataque</summary>
        /// <returns>(null, null) se não houver alvos disponíveis</returns>
        public virtual (TerritorioDisplay partida, TerritorioDisplay destino) DecideAlvo(TerritorioDisplay[] candidatos)
        {
            TerritorioDisplay partida = null;
            TerritorioDisplay destino = null;
            foreach (Prioridade prioridade in prioridades)
            {
                prioridade.territorios.ForEach((territorio) =>
                {
                    foreach (var candidato in candidatos)
                    {
                        if (candidato.fronteirasDisplay.Contains(territorio))
                        {
                            partida = candidato;
                            destino = territorio;
                            return;
                        }
                    }
                });
                if (partida != null) break;
            }
            return (partida, destino);
        }
        /// <summary>Determina as prioridades</summary>
        protected abstract void PintarTerritorios();
    }
}
