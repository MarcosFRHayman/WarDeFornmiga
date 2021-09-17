using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Jogadores;
using FormigaWar.Territorios;

namespace FormigaWar
{
    public static class BaralhoDeObjetivo
    {
        public static List<Objetivo> cartas = new List<Objetivo>();
        //private static List<Objetivo> descarte; // provavel que nao seja necessario, tirar talvez?

        public static Objetivo PuxarCarta()
        {

            // como conversao de int ignora a virgula 
            // a ultima carta tem uma chance extremamente pequena de ser puxada
            // e a primeira carta tem cerca de metade da chance de ser puxada
            // para balancear as probabilidades, a range eh ]-1, cartas.Count[
            int i = (int)Random.Range(-0.9999999f, cartas.Count + 0.9999999f);


            Objetivo result = cartas[i];
            cartas.RemoveAt(i);
            //descarte.Add(result);
            return result;
        }

        public static void BotarDeVolta(Objetivo obj) => cartas.Add(obj); // util para deixar de volta a carta nao esolhida

        public static void InicializaBaralho(
            Jogador[] jogadores,
            Continente N,
            Continente NO,
            Continente NL,
            Continente SO,
            Continente SL,
            Continente C)
        {
            //por territorios
            cartas.Add(new ObjetivoPorTerritorio(24, 1));
            cartas.Add(new ObjetivoPorTerritorio(18, 2));

            //por Continente
            cartas.Add(new ObjetivoPorContinente(
                new List<Continente>(new Continente[] { N, NL }), 0));
            cartas.Add(new ObjetivoPorContinente(
                new List<Continente>(new Continente[] { C, SO }), 1));
            cartas.Add(new ObjetivoPorContinente(
                new List<Continente>(new Continente[] { NO, SL }), 0));
            cartas.Add(new ObjetivoPorContinente(
                new List<Continente>(new Continente[] { NL, SO }), 0));
            cartas.Add(new ObjetivoPorContinente(
                new List<Continente>(new Continente[] { NO, N }), 0));
            cartas.Add(new ObjetivoPorContinente(
                new List<Continente>(new Continente[] { C, NL }), 1));

            //por jogadores
            foreach (var jogador in jogadores)
            {
                cartas.Add(new ObjetivoPorExercito(jogador));
            }

        }
    }
}