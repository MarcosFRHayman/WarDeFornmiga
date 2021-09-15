using System.Collections;
using System.Collections.Generic;
using FormigaWar.Territorios;
using UnityEngine;

namespace FormigaWar
{
    public class Prioridade
    {
        public readonly int Valor;
        public readonly List<TerritorioDisplay> territorios;
        public Prioridade(int valor, List<TerritorioDisplay> territorios)
        {
            this.Valor = valor;
            this.territorios = territorios;
        }
    }
}
