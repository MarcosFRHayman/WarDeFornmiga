using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FormigaWar
{
    public class SeletorTropas : MonoBehaviour
    {

        public Text tnum;

        public GameObject panel;

        // botoes de incremento e decremento
        public Button btnmais;
        public Button btnmenos;

        // botoes de confirmacao e cancelamento
        public Button btnconfirma;
        public Button btncancela;

        private int number = 0;

        // Start is called before the first frame update
        void Start()
        {
            tnum.text = number.ToString();
            btnmais.onClick.AddListener(BtnMaisOnClick);
            btnmenos.onClick.AddListener(BtnMenosOnClick);
            btnconfirma.onClick.AddListener(BtnConfirmaOnClick);
            btncancela.onClick.AddListener(BtnCancelaOnClick);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void BtnMenosOnClick()
        {
            number--;
            tnum.text = (number).ToString();
        }

        void BtnMaisOnClick()
        {
            number++;
            tnum.text = (number).ToString();
        }

        void BtnConfirmaOnClick()
        {

        }

        void BtnCancelaOnClick()
        {

        }

        public int abrirSeletor()
        {
            //abre dialogo
            return number;
        }
    }
}