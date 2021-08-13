using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    [System.Serializable]
    public class CartaTerritorio : Carta
    {
        public Territorio territorio { get; internal set; }
        [SerializeField] private Simbolo simbolo;
        public bool TemSimbolo(Simbolo simbolo) => simbolo.Equals(this.simbolo);
    }
}
