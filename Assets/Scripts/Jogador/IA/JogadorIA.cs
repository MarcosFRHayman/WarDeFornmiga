using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Jogadores.IA
{
    public class JogadorIA : Jogador
    {
        private readonly int dificuldade;
        private ObjetivoBehaviour behaviour;

        public JogadorIA() { }
        public void recebeObjetivo(Objetivo objetivo)
        {
            this.objetivo = objetivo;
            behaviour = objetivo.behaviourFactory.criaBehaviour(dificuldade);
        }
        public void JogaTurno() { }
    }

}