using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;

namespace FormigaWar
{
    public abstract class ObjetivoPorContinente : Objetivo
    {
        private List<Continente> continentes;
        public override bool Checar()
        {
            //checar territorios do jogador
            //se o jogador tem todos os continentes
            //return true;
            return false;
        }
    }
}
