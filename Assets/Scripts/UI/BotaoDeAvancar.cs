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
        }
    }
}
