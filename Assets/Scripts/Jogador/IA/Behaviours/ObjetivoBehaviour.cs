using System.Collections;
using System.Collections.Generic;
using FormigaWar.Territorios;
using UnityEngine;

namespace FormigaWar
{
    public interface ObjetivoBehaviour
    {
        (TerritorioDisplay partida, TerritorioDisplay destino) DecideAlvo(TerritorioDisplay[] candidatos);
    }
}
