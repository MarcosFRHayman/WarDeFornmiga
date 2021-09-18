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
  
        public Jogador j = null;
        public Text texto;
        public void Start()
        {
            abreobjetivo.onClick.AddListener(Abrir);
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }

       
        public void Abrir()
        {
            AbrirObjetivo(TurnoManager.GetJogadorDaVez());
           
        }
        public void AbrirObjetivo(Jogador jog)
        {
            if (painel.activeSelf==false) { 
            this.j = jog;
            texto.text = j.objetivo.ToString();
            painel.SetActive(true);
            }
            else
            {
                painel.SetActive(false);
            }
        }
    }
}
