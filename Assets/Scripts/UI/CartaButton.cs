using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FormigaWar.Territorios;
using FormigaWar;

namespace FormigaWar
{
    public class CartaButton : MonoBehaviour
    {
        // Variaveis que apontam para outras variaveis
        public Button button;
        public Text texto;
        public MaoUI maoUI;

        // Carta

        public Carta carta;

        void Start()
        {
            button.onClick.AddListener(Btn);
        }

        void Btn()
        {
            button.interactable = false;
            maoUI.AddSelected(this);
        }
    }
}
