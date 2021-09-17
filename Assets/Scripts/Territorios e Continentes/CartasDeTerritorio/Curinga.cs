using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    public class Curinga : Carta
    {
        public string simbolo;
        public bool TemSimbolo(string simbolo) => true;
        public Curinga()
        {
            simbolo = "✦✹❉";
        }
    }
}