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
        public TerritorioDisplay tdSaida = null; // primeiro territorio clicado, para fase de movimentacao eh de onde saem as tropas
        [SerializeField] private TerritorioDisplay tdChegada = null;
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
            if (tdSaida == null)
            {
                Debug.Log("tdSaida = null");
                return;
            }
            tnum.text = number.ToString() + " / " + (tdSaida.NumTropas - 1).ToString();
        }
        void BtnMenosOnClick()
        {
            if (number <= 0) return;
            number--;
            AtualizaNumTxt();
        }
        void BtnMaisOnClick()
        {
            if (number >= (tdSaida.NumTropas - 1)) return;
            number++;
            AtualizaNumTxt();
        }
        void BtnConfirmaOnClick()
        {
            if (tdSaida == null) return; // cheque de sanidade, ele foi chamado mas n�o foi dado territorio
            switch(TurnoManager.faseAtual)
            {
                case 0:  // fase de fortificacao continental
                    tdSaida.NumTropas += number;
                break;
                case 1:  // fase de fortificacao
                    tdSaida.NumTropas += number;
                break;
                case 2:  // fase de ataque
                    tdSaida.NumTropas -= number;
                    tdSaida.AtualizarNumTropas();
                    tdChegada.NumTropas += number;
                    tdChegada.AtualizarNumTropas();
                    tdChegada = null;
                break;
                case 3:  // fase de movimentacao
                    tdSaida.NumTropas -= number;
                    tdSaida.AtualizarNumTropas();
                    tdChegada.numtropas_to_move += number;
                    tdChegada.AtualizarNumTropas();
                    tdChegada = null;
                break;
                default: // deu erro
                break;
            }
            number = 0;
            panel.SetActive(false);
        }
        void BtnCancelaOnClick()
        {
            //t_invoker.AtualizaEstado("normal");
            tdChegada = null;
            number = 0;
            panel.SetActive(false);
        }
        public void AbrirSeletor(TerritorioDisplay t_invoker) // usado pelo territorio quando ele eh selecionado
        {
            this.tdChegada = t_invoker;
            AtualizaNumTxt();
            panel.SetActive(true);
        }
        public void FecharSeletor() // usado pelo territorio quando ele eh deselecionado
        {
            tdSaida = null;
            tdChegada = null;
            number = 0;
            panel.SetActive(false);
        }
    }
}