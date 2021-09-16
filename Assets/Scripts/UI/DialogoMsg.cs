using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FormigaWar
{
    public class DialogoMsg : MonoBehaviour
    {
        public GameObject painel;
        public Text textMsg;

        public Button fechar;

        public void Start()
        {
            fechar.onClick.AddListener(FecharDiag);
        }
        public void MostraDiag(string msg)
        {
            painel.SetActive(true);
            textMsg.text = msg;
        }
        public void FecharDiag()
        {
            painel.SetActive(false);
        }
    }
}
