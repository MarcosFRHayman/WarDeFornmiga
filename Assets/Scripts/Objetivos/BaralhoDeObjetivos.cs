using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Jogadores;

namespace FormigaWar
{
    public static class BaralhoDeObjetivo
    {
        public static List<Objetivo> cartas;
        private static List<Objetivo> descarte; // provavel que nao seja necessario, tirar talvez?

        public static Objetivo PuxarCarta()
        {
            if(cartas.Count == 0)return new ObjetivoPorTerritorio();
            int i = (int)Random.Range(0, cartas.Count);


            Objetivo result = cartas[i];
            cartas.RemoveAt(i);
            descarte.Add(result);
            return result;
        }

        public static void BotarDeVolta(Objetivo obj) => cartas.Add(obj); // util para deixar de volta a carta nao esolhida
    }
}