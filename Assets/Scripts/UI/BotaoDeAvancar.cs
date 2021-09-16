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
        public Text btntxt;

        private void Start()
        {
            avancar.onClick.AddListener(Taskavanca);
            TurnoManager.bda = this;
        }

        private void Taskavanca()
        {
            TurnoManager.AvancarTurno();
            AtualizaTexto(); 
        }

        public void AtualizaTexto()
        {
            btntxt.text = "FaseAtual: " + TurnoManager.faseAtual.ToString();
        }
    }
}
