using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;
using FormigaWar.jogador;


namespace FormigaWar
{
    public class ObjetivoPorExercito : Objetivo
    {
        private Jogador nemesis;
        private bool nemesisDerrotado;
        public override bool Checar()
        {
            if(nemesisDerrotado)
            {
                if(jogador.territorioDisplay.Count >= 24)return true;
            }
            else
            {
                //checar se o nemesis tem 0 territorios // como esta funcao eh chamada logo apos um territorio eh conquistado
                //se o nemesis tem 0 territorios
                //return true;
            }
            
            return false;
        }

        public void MudarObjetivo()
        {
            nemesisDerrotado = true;
        }
    }
}
