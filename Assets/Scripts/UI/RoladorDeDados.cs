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

            // Demais atributos--

            void Start()
            {
                st = GetComponent<SeletorTropas>();
                btnConfirma.onClick.AddListener(BtnConfirma);
            }

            void BtnConfirma()
            {
            List<int> dadosatacantes = new List<int>();
            List<int> dadosdefensores = new List<int>();
            int somatorio = 0;
            if(btnConfirmaText.text == "Rolar")
            {
                while(somatorio < 3)
                {
                    if ((tdAtacante.NumTropas - 1) >= ( somatorio+1))
                    {
                    dadosatacantes.Add(Random.Range(1,6));
                    dadosatacantes.Sort();
                    }

                    if ((tdDefensor.NumTropas - 1) >= somatorio)
                    {
                    dadosdefensores.Add(Random.Range(1, 6));
                    dadosdefensores.Sort();
                    }
                    somatorio += 1;
                }
                dadosatacantes.Reverse();
                dadosdefensores.Reverse();
                if (dadosatacantes.Count <= dadosdefensores.Count)
                {   
                    for(int i = 0; i<dadosatacantes.Count; i++)
                    {
                        if (dadosatacantes[i] > dadosdefensores[i])
                        {
                            tdDefensor.NumTropas -= 1;
                        }
                        else
                        {
                            tdAtacante.NumTropas -= 1;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < dadosdefensores.Count; i++)
                        {
                        if (dadosatacantes[i] > dadosdefensores[i])
                        {
                            tdDefensor.NumTropas -= 1;
                        }
                    }
                }
                if ((tdDefensor.NumTropas >= 0)||( tdAtacante.NumTropas == 1)){
                    btnConfirmaText.text = "Fechar";
                }
                dadosatacantes.Clear();
                dadosdefensores.Clear();
            }
            else
            {
                if(tdAtacante.NumTropas<=0)
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
