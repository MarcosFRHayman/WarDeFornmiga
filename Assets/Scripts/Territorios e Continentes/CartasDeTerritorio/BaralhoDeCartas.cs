using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    public static class BaralhoDeCartas
    {
        private static List<Carta> cartas = new List<Carta>();
        public static Carta PuxarCarta() //metodo retorna uma carta e tira esta carta do baralho
        {
            Carta cartaPuxada = cartas[(int)Random.Range(0, cartas.Count)];
            cartas.Remove(cartaPuxada);
            return cartaPuxada;
        }
        public static void Inicializar(List<Territorio> territorios)
        {
            cartas.Add(new Curinga());
            cartas.Add(new Curinga());
            foreach (Territorio territorio in territorios)
            {
                cartas.Add(territorio.Carta);
            }
        }

    }
}
