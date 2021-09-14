using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    public class BaralhoDeCartas
    {
        private List<Carta> cartas = new List<Carta>();
        public Carta PuxarCarta() //metodo retorna uma carta e tira esta carta do baralho
        {
            Carta cartaPuxada = cartas[(int)Random.Range(0, cartas.Count)];
            cartas.Remove(cartaPuxada);
            return cartaPuxada;
        }
        public void Inicializar(List<Territorio> territorios)
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
