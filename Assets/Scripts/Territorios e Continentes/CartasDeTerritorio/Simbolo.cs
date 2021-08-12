using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Simbolo", fileName = "newSimbolo")]
    public class Simbolo : ScriptableObject
    {
        [SerializeField] private Sprite image;

        public Simbolo() { }
    }
}