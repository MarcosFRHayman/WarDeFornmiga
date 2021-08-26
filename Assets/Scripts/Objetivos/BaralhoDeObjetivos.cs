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
            
            // como conversao de int ignora a virgula 
            // a ultima carta tem uma chance extremamente pequena de ser puxada
            // e a primeira carta tem cerca de metade da chance de ser puxada
            // para balancear as probabilidades, a range eh ]-1, cartas.Count[
            int i = (int)Random.Range(-0.9999999f, cartas.Count + 0.9999999f);


            Objetivo result = cartas[i];
            cartas.RemoveAt(i);
            descarte.Add(result);
            return result;
        }

        public static void BotarDeVolta(Objetivo obj) => cartas.Add(obj); // util para deixar de volta a carta nao esolhida
    }
}