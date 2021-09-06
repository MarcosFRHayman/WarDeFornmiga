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
                    bool ganhou = true; // nao precisa usar esse if
                    if(ganhou)
                    {
                        tdDefensor.ConquistaTerritorio(TurnoManager.GetJogadorDaVez());
                        
                        st.tdSaida = tdAtacante;
                        st.AbrirSeletor(tdDefensor);
                    }
                    else
                    {

                    }
                    tdAtacante = null;
                    tdDefensor = null;
                    panel.SetActive(false);
                }
                
            }

            public void AbrirRolador(TerritorioDisplay t)
            {
                if(tdAtacante.NumTropas == 1)
                {
                    Debug.Log("Não se pode atacar com um exercito no territorio");
                }
                else
                {
                    tdDefensor = t;
                    panel.SetActive(true);
                    btnConfirmaText.text = "Rolar";                
                }
            }

    }
}
