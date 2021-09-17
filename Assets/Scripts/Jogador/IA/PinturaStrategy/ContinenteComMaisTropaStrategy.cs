using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;
using FormigaWar.Jogadores.IA;

namespace FormigaWar
{
    public class ContinenteComMaisTropaStrategy
    {
        private readonly JogadorIA ia;
        private readonly List<Continente> continentes;
        private int vezes = 0;
        public ContinenteComMaisTropaStrategy(JogadorIA ia)
        {
            this.ia = ia;
            var tabuleiro = ia.objetivo.tabuleiro;
            continentes =
                tabuleiro.Continentes
                    .Where(continente => ia.continentes.Contains(continente))
                    .OrderBy(continente =>
                        continente
                            .GetTerritorios()
                            .Count(territorio => tabuleiro
                                .TerritoriosInstanciados
                                .FirstOrDefault(display => display.Territorio.Equals(territorio))
                                .Jogador.Equals(ia)
                                )
                    ).ToList();
        }
        /// <exception cref="IndexOutOfBoundsException">caso chame uma quantidade maior de vezes que há continentes controlados</exception>
        public Continente EncontraProximo()
        {
            var continente = continentes[vezes];
            vezes++;
            return continente;
        }

    }
}
