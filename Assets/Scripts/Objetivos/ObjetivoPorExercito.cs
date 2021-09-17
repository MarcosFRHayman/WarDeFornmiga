using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;
using FormigaWar.Jogadores;
using FormigaWar.Jogadores.IA;


namespace FormigaWar
{
    public class ObjetivoPorExercito : Objetivo
    {
        public Jogador nemesis { get; private set; }
        private bool nemesisDerrotado = false;

        public ObjetivoPorExercito()
        {
            behaviourFactory = new EliminacaoBehaviourFactory(this);
        }
        public override bool Checar()
        {
            if (nemesisDerrotado)
            {
                if (jogador.Territorios.Count >= 24) return true;
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
