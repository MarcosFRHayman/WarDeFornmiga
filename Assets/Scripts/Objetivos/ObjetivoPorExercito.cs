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

        public ObjetivoPorExercito(Jogador jouer)
        {
            nemesis = jouer;
        }
        public override bool Checar()
        {
            if (nemesisDerrotado)
            {
                if (jogador.Territorios.Count >= 24) return true;
            }
            else
            {
                Debug.Log(nemesis.Territorios.Count +" == 0 ?");
                Debug.Log("Be the nemesis null?" +(nemesis == null));
                if(nemesis == null)
                {
                    MudarObjetivo(); 
                    return false;
                }
                if(nemesis.Territorios.Count == 0)return true;
                else return false;
            }

            return false;
        }

        public void MudarObjetivo()
        {
            nemesisDerrotado = true;
        }
    }
}
