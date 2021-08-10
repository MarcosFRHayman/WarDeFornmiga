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
        public TerritorioDisplay t_invoker = null; // primeiro territorio clicado, para fase de movimentacao eh de onde saem as tropas
        [SerializeField] private TerritorioDisplay t_invoker2 = null; 
        [SerializeField] private GameObject panel;

        // botoes de incremento e decremento
        [SerializeField] private Button btnmais;
        [SerializeField] private Button btnmenos;

        // botoes de confirmacao e cancelamento
        [SerializeField] private Button btnconfirma;
        [SerializeField] private Button btncancela;
        private int number = 0;
        void Start()
        {          
            tnum = transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
            btnmenos = transform.GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<Button>();
            btnmais = transform.GetChild(0).GetChild(0).GetChild(2).gameObject.GetComponent<Button>();
            btncancela = transform.GetChild(0).GetChild(0).GetChild(3).gameObject.GetComponent<Button>();
            btnconfirma = transform.GetChild(0).GetChild(0).GetChild(4).gameObject.GetComponent<Button>();

            AtualizaNumTxt();
            btnmais.onClick.AddListener(BtnMaisOnClick);
            btnmenos.onClick.AddListener(BtnMenosOnClick);
            btnconfirma.onClick.AddListener(BtnConfirmaOnClick);
            btncancela.onClick.AddListener(BtnCancelaOnClick);
        }
        void AtualizaNumTxt()
        {
            if(t_invoker == null) return;
            tnum.text = number.ToString() + " / " + (t_invoker.NumTropas -1).ToString();
        }
        void BtnMenosOnClick()
        {
            if(number <= 0) return;
            number--;
            AtualizaNumTxt();
        }
        void BtnMaisOnClick()
        {
            if(number >= (t_invoker.NumTropas -1))return;
            number++;
            AtualizaNumTxt();
        }
        void BtnConfirmaOnClick()
        {
            if (t_invoker == null) return; // cheque de sanidade, ele foi chamado mas n�o foi dada tropas

            t_invoker.NumTropas -= number;
            t_invoker.AtualizarNumTropas();
            t_invoker2.numtropas_to_move += number;// talvez seja mudado depois, mas para testes isso vai dar
            t_invoker2.AtualizarNumTropas();
            t_invoker2 = null;
            number = 0;
            panel.SetActive(false);
        }
        void BtnCancelaOnClick()
        {
            //t_invoker.AtualizaEstado("normal");
            t_invoker2 = null;
            number = 0;
            panel.SetActive(false);
        }
        public void AbrirSeletor(TerritorioDisplay t_invoker) // usado pelo territorio quando ele eh selecionado
        {
            this.t_invoker2 = t_invoker;
            AtualizaNumTxt();
            panel.SetActive(true);
        } 
        public void FecharSeletor() // usado pelo territorio quando ele eh deselecionado
        {
            t_invoker = null;
            t_invoker2 = null;
            number = 0;
            panel.SetActive(false);
        }
    }
}