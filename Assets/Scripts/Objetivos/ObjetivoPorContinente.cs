using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;

namespace FormigaWar
{
    public class ObjetivoPorContinente : Objetivo
    {
        private List<Continente> continentes;
        public Continente[] Continentes { get => continentes.ToArray(); }
        private int continenteAEscolha;

        public ObjetivoPorContinente()
        {
            behaviourFactory = new ContinenteBehvaiourFactory(this);
        }

        public int ContinenteAEscolha { get => continenteAEscolha; }


        public override bool Checar()
        {

            int counter = continentes.Count;
            foreach (Continente c in continentes)
            {
                if (jogador.continentes.Contains(c)) counter--;
            }

            //se o jogador tem todos os continentes e mais os continentes a escolha, retorne true.
            if (jogador.continentes.Count >= (continentes.Count + continenteAEscolha) && counter == 0) return true;

            return false;
        }
    }
}
