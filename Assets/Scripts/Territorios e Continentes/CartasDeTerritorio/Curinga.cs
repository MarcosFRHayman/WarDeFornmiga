using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    [System.Serializable]
    public class Curinga : Carta
    {
        public bool TemSimbolo(string simbolo) => true;
        public Curinga()
        {
            simbolo = "✦✹❉";
        }
    }
}