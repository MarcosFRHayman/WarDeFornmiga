using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    public interface Carta
    {
        string simbolo {get; set;}
        bool TemSimbolo(string simbolo);
    }
}