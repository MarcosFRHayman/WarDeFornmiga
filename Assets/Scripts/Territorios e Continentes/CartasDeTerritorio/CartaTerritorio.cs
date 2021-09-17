using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    [System.Serializable]
    public class CartaTerritorio : Carta
    {
        public Territorio territorio { get; internal set; }
        [SerializeField] public string simbolo;
        public bool TemSimbolo(string simbolo) => simbolo.Equals(this.simbolo);
    }
}
