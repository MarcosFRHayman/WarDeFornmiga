using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;
using FormigaWar.Jogadores.IA;

namespace FormigaWar
{
    public class ObjetivoPorTerritorio : Objetivo
    {
        public int territoriosNecessarios { get; private set; } // quantos territorios eu preciso
        private int exercitosPorTerritorio; // quantos exercitos por exercitos no territorio
        public ObjetivoPorTerritorio()
        {
            behaviourFactory = new TerritoriosBehaviourFactory(this);
        }
        public override bool Checar()
        {
            if (jogador.Territorios.Count >= territoriosNecessarios && exercitosPorTerritorio == 1) return true;
            else
            {
                int counter = 0;
                foreach (TerritorioDisplay t in jogador.Territorios)
                {
                    if (t.NumTropas >= exercitosPorTerritorio) counter++;
                }
                if (counter >= territoriosNecessarios) return true;
            }
            return false;
        }
    }
}
