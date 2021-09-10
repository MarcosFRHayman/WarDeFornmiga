using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FormigaWar
{
    public class BotaoDeAvancar : MonoBehaviour
    {
        // Start is called before the first frame update
        public Button avancar;

        private void Start()
        {
            avancar.onClick.AddListener(Taskavanca);
        }

        private void Taskavanca()
        {
            TurnoManager.AvancarTurno();
            TurnoManager.faseAtual += 1;
            if (TurnoManager.faseAtual >= 4) // se esta eh a ultima fase do turno, vai para o proximo jogador
            {
                TurnoManager.ConquistouUmTerritorio = false;
                
                TurnoManager.faseAtual = 0;
                TurnoManager.jogadorDaVez += 1;
                //Debug.Log("final!!!!!!");
                //Debug.Log(TurnoManager.faseAtual);
                //Debug.Log(TurnoManager.jogadorDaVez);
                if (TurnoManager.jogadorDaVez >= TurnoManager.jogadoresNaMesa.Length) // se este eh o ultimo jogador na mesa, volte para o primeiro
                {
                    TurnoManager.jogadorDaVez = 0;
                }
            }
            //Debug.Log(TurnoManager.jogadorDaVez);
            //Debug.Log(TurnoManager.faseAtual);
        }
    }
}
