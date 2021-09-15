using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Jogadores
{
    public class JogadorIA : Jogador
    {
        private ObjetivoBehaviour behaviour;

        public JogadorIA(Objetivo objetivo)
        {
            behaviour = objetivo.behaviourFactory.criaBehaviour();
        }
        public void JogaTurno() { }
    }

}