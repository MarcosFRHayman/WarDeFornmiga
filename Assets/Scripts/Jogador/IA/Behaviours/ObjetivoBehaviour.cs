using System.Linq;
using System.Collections;
using System.Collections.Generic;
using FormigaWar.Territorios;
using UnityEngine;

namespace FormigaWar.Jogadores.IA
{
    public interface ObjetivoBehaviour
    {
        (TerritorioDisplay partida, TerritorioDisplay destino) DecideAlvo(List<TerritorioDisplay> candidatos);
        /// <summary>Decide o ponto de partida e destino de um ataque</summary>
        /// <param name="candidatos">lista de territorios que são candidatos para a partida</param>
        /// <returns>Lista de pares chave-valor de partida para destino
        ///     <para>as partidas são territorios que foram filtrados dentre os candidatos</para>
        ///     <para>a lista de destinos possíveis a partir das partidas, ordenadas pelas prioridades</para>
        /// </returns>
        IOrderedEnumerable<KeyValuePair<TerritorioDisplay, List<TerritorioDisplay>>> DecideAlvos(List<TerritorioDisplay> candidatos);
    }
}
