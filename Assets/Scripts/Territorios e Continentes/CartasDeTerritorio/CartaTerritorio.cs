using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    [CreateAssetMenu(menuName = "ScriptableObjects/CartaDeTerritorio", fileName = "newCartaTerritorio")]
    public class CartaTerritorio : ScriptableObject, Carta
    {
        [SerializeField] private Territorio territorio;
        [SerializeField] private Simbolo simbolo;
        public bool TemSimbolo(Simbolo simbolo) => simbolo.Equals(this.simbolo);
    }
}
