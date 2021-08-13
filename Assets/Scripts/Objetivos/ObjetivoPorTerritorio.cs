using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;

namespace FormigaWar
{
    public abstract class ObjetivoPorTerritorio : Objetivo
    {
        private int territoriosNecessarios; // quantos territorios eu preciso
        private int exercitosPorTerritorio; // quantos exercitos por exercitos no territorio
        public override bool Checar()
        {
            //checar territorios do jogador
            //se o jogador tem a qtd de territorios com os exercitos pedidos
            //return true;
            return false;
        }
    }
}
