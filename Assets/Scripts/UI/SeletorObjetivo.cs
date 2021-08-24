using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FormigaWar.Jogadores;

namespace FormigaWar
{
    public class SeletorObjetivo : MonoBehaviour
    {

        // variaveis que apontam para outras classes
        public GameObject panel;
        private Jogador j;

        // botoes sao as cartas
        public Button btncartaesq;
        public Button btncartadir;

        //Objetivos para o jogador escolher (1 esq, 2 dir)
        Objetivo obj1; 
        Objetivo obj2;

        // Start is called before the first frame update
        void Start()
        {
            btncartaesq.onClick.AddListener(BtnCartaEsq);
            btncartadir.onClick.AddListener(BtnCartaDir);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void BtnCartaEsq()
        {
            j.objetivo = obj1;
            BaralhoDeObjetivo.BotarDeVolta(obj2);
            panel.SetActive(false);
        }

        void BtnCartaDir()
        {
            j.objetivo = obj2;
            BaralhoDeObjetivo.BotarDeVolta(obj1);
            panel.SetActive(false);
        }

        public void abrirSeletor(Jogador jogador)
        {
            panel.SetActive(true);
            obj1 = BaralhoDeObjetivo.PuxarCarta();
            obj2 = BaralhoDeObjetivo.PuxarCarta();
        }
    }
}
