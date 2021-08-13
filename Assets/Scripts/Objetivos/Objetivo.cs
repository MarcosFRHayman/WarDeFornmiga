using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar
{
    public abstract class Objetivo
    {
        private string descricao;
        //private Jogador jogador;
        public abstract bool Checar(); // metodo checa se o objetivo foi completado.
    }
}