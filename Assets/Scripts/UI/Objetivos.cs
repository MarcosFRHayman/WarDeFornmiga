using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using FormigaWar.Territorios;
using FormigaWar.Jogadores;
using FormigaWar;
using System.Linq;
using UnityEngine;

namespace FormigaWar
{
    public class Objetivos : MonoBehaviour
    {
        public GameObject painel;
        public Button abreobjetivo;
        public Button btncancela;
        public Jogador j = null;
        public Text texto;
        public void Start()
        {
            abreobjetivo.onClick.AddListener(Abrir);
            btncancela.onClick.AddListener(BtnCancela);
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        void BtnCancela()
        {
            texto.text = "";
            painel.SetActive(false);
        }
        public void Abrir()
        {
            AbrirObjetivo(TurnoManager.GetJogadorDaVez());
           
        }
        public void AbrirObjetivo(Jogador jog)
        {
            this.j = jog;
            texto.text = j.objetivo.ToString();
            painel.SetActive(true);
           
        }
    }
}
