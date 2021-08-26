using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Jogadores;

namespace FormigaWar
{
    public abstract class Objetivo
    {
        protected string descricao;
        protected Jogador jogador;
        public abstract bool Checar(); // metodo checa se o objetivo foi completado.
    }
}