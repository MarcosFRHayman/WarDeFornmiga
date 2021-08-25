using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;

namespace FormigaWar
{
    public class ObjetivoPorTerritorio : Objetivo
    {
        private int territoriosNecessarios; // quantos territorios eu preciso
        private int exercitosPorTerritorio; // quantos exercitos por exercitos no territorio

        public ObjetivoPorTerritorio() // construtor de testes
        {
            this.descricao = "Este eh um objetivo de testes.";
        }

        public ObjetivoPorTerritorio(int i, int j) // construtor a ser utilizado
        {

        }

        public override bool Checar()
        {
            if(jogador.territorioDisplay.Count >= territoriosNecessarios && exercitosPorTerritorio == 1)return true;
            else
            {
                int counter = 0;
                foreach(TerritorioDisplay t in jogador.territorioDisplay){
                    if(t.NumTropas >= exercitosPorTerritorio)counter++;
                }
                if(counter >= territoriosNecessarios)return true;
            }
            return false;
        }
    }
}
