using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;
using FormigaWar.Jogadores.IA;
using FormigaWar.Jogadores;

namespace FormigaWar
{
    public class ContinenteComMaisTropaStrategy
    {
        private readonly Jogador ia;
        private readonly List<Continente> continentes;
        private int vezes = 0;
        public ContinenteComMaisTropaStrategy(Jogador ia)
        {
            this.ia = ia;
            var tabuleiro = ia.objetivo.tabuleiro;
            continentes =
                tabuleiro.Continentes
                    .Where(continente => ia.continentes.Contains(continente))
                    .OrderBy(continente =>
                        (float)continente
                            .GetTerritorios()
                            .Count(territorio => tabuleiro
                                .TerritoriosInstanciados
                                .FirstOrDefault(display => display.Territorio.Equals(territorio))
                                .Jogador.Equals(ia)
                                ) / (float)continente.GetTerritorios().Count
                    ).ToList();
        }
        /// <exception cref="IndexOutOfBoundsException">caso chame uma quantidade maior de vezes que há continentes controlados</exception>
        public Continente EncontraProximo()
        {
            Debug.Log("continentes.Count: "+continentes.Count +" | vezes: " + vezes);
            var continente = continentes[vezes];
            vezes++;
            return continente;
        }

    }
}
