using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    public static class BaralhoDeTerritorios
    {
        public static List<Carta> cartas;

        public static Carta PuxarCarta() //metodo retorna uma carta e tira esta carta do baralho
        {
            Carta cartaPuxada = cartas[(int)Random.Range(0, cartas.Count)];
            cartas.Remove(cartaPuxada);
            return cartaPuxada;
        }

    }
}
