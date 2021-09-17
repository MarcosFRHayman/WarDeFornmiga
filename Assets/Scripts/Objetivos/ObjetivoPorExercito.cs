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
        public System.Action onObjMudou;

        public ObjetivoPorExercito()
        {
            behaviourFactory = new EliminacaoBehaviourFactory(this);
        }

        public ObjetivoPorExercito(Jogador jouer)
        {
            nemesis = jouer;
            behaviourFactory = new EliminacaoBehaviourFactory(this);
        }
        public override bool Checar()
        {
            bool jexiste = false;

            for(int i = 0; i < TurnoManager.jogadoresNaMesa.Length; i++)
                if(TurnoManager.jogadoresNaMesa[i] == nemesis)jexiste = true;

            if(!jexiste)
            {
                MudarObjetivo(); 
            }
            if(nemesis.Territorios.Count == 1)
                return true;
            return false;
        }
        public void MudarObjetivo() // TODO: Usar o RecebeObjetivo() do Jogador
        {
            TurnoManager.GetJogadorDaVez().objetivo = new ObjetivoPorTerritorio(24, 1);
            TurnoManager.GetJogadorDaVez().objetivo.Checar();
        }
    }
}
