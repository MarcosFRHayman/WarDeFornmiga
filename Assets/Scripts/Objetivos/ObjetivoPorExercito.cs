using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;
using FormigaWar.Jogadores;


namespace FormigaWar
{
    public class ObjetivoPorExercito : Objetivo
    {
        private Color nemesisCor; // destrua o exercito de cor X 
        public Jogador[] jogadoresNaMesa; // isso deve ser passado para ca com =, assim a variavel aponta para os jogadores de fato
        public override bool Checar()
        {
            Jogador nemesis = null;
            foreach(Jogador j in jogadoresNaMesa)
            {
                if(j.Cor == nemesisCor)
                {
                    nemesis = j;
                }
            }
            // este if assume que se o jogador nao esta no array da mesa, ele nao esta atualmente jogando ou foi derrotado
            if(nemesis == null && jogador.territorioDisplay.Count >= 24)return true;
            else if(nemesis.territorioDisplay.Count <= 0) // nunca vai ser menor que zero ja que eh um .Count, mas nunca se sabe
            {
                // se o seu nemesis tem 0 territorios, cumpriu o objetivo
                return true;
            }

            return false;
        }
    }
}
