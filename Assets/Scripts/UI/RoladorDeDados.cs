using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FormigaWar.Territorios;

namespace FormigaWar
{

    public class RoladorDeDados : MonoBehaviour
    {
            // Atributos que apontam para outras classes
            public GameObject panel;
            public Button btnConfirma;
            public Text btnConfirmaText;
            private SeletorTropas st; // talvez seja desnecessario

            // Atributos dos territorioDisplay manipulados

            public TerritorioDisplay tdAtacante;
            public TerritorioDisplay tdDefensor;

            // Demais atributos

            void Start()
            {
                st = GetComponent<SeletorTropas>();
                btnConfirma.onClick.AddListener(BtnConfirma);
            }

            void BtnConfirma()
            {
                
                if(btnConfirmaText.text == "Rolar")
                {
                    // fazer a parte de rolador aqui   
                    btnConfirmaText.text = "Fechar";
                }
                else
                {
                    // depois de rolado, o mesmo botao fecha e prossegue com o jogo
                    tdAtacante = null;
                    tdDefensor = null;
                    panel.SetActive(false);
                }
                
            }

            public void AbrirRolador(TerritorioDisplay t)
            {
                tdDefensor = t;
                panel.SetActive(true);
                btnConfirmaText.text = "Rolar";                
            }

    }
}
