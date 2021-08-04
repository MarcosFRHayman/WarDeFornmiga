using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FormigaWar.Territorios;

namespace FormigaWar
{
    public class SeletorTropas : MonoBehaviour
    {

        [SerializeField] private Text tnum;
        [SerializeField] private TerritorioDisplay t_invoker = null;
        [SerializeField] private GameObject panel;

        // botoes de incremento e decremento
        [SerializeField] private Button btnmais;
        [SerializeField] private Button btnmenos;

        // botoes de confirmacao e cancelamento
        [SerializeField] private Button btnconfirma;
        [SerializeField] private Button btncancela;

        private int number = 0;

        // Start is called before the first frame update
        void Start()
        {          
            tnum = transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
            btnmenos = transform.GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<Button>();
            btnmais = transform.GetChild(0).GetChild(0).GetChild(2).gameObject.GetComponent<Button>();
            btncancela = transform.GetChild(0).GetChild(0).GetChild(3).gameObject.GetComponent<Button>();
            btnconfirma = transform.GetChild(0).GetChild(0).GetChild(4).gameObject.GetComponent<Button>();

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
            if (t_invoker == null) return; // cheque de sanidade, ele foi chamado mas n�o foi dada tropas

            t_invoker.NumTropas = number;
            t_invoker.AtualizaEstado("normal");
            // talvez seja mudado depois, mas para testes isso vai dar
            t_invoker = null;
            panel.SetActive(false);
        }

        void BtnCancelaOnClick()
        {
            //t_invoker.AtualizaEstado("normal");
            t_invoker = null;
            panel.SetActive(false);
        }

        public void AbrirSeletor(TerritorioDisplay t_invoker)
        {
            this.t_invoker = t_invoker;
            panel.SetActive(true);
        }
    }
}