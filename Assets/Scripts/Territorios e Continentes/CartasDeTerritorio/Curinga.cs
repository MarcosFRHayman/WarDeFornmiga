using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    [CreateAssetMenu(menuName = "ScriptableObjects/CartaCuringa", fileName = "newCuringa")]
    public class Curinga : Carta
    {
        public bool TemSimbolo(Simbolo simbolo) => true;
    }
}