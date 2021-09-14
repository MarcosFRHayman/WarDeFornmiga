using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FormigaWar.Territorios;
using FormigaWar.Jogadores;

namespace FormigaWar
{

    public class RoladorDeDados : MonoBehaviour
    {
            // Atributos que apontam para outras classes
            public GameObject panel;
            public Button btnConfirma;
            public Text btnConfirmaText;     
            private SeletorTropas st;
            //private Mesa mesa; // talvez necessario pois ao dar merge na main baralhoDeTerritorios nao sera mais static

            // Atributos dos territorioDisplay manipulados
            public TerritorioDisplay tdAtacante;
            public TerritorioDisplay tdDefensor;

            void Start()
            {
                //mesa = GetComponent<Mesa>();
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
                                Debug.Log("Atacante Venceu");
                                tdDefensor.NumTropas -= 1;
                                tdDefensor.AtualizarNumTropas();
                            }
                            else
                            {
                                tdAtacante.NumTropas -= 1;
                                tdAtacante.AtualizarNumTropas();
                                Debug.Log("Atacante Perdeu, agora tem " + tdAtacante.NumTropas.ToString() + "Tropas");
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dadosdefensores.Count; i++)
                        {
                            if (dadosatacantes[i] > dadosdefensores[i])
                            {
                                Debug.Log("Atacante Venceu");
                                tdDefensor.NumTropas -= 1;
                                tdDefensor.AtualizarNumTropas();
                            }
                            else
                            {
                                tdAtacante.NumTropas -= 1;
                                tdAtacante.AtualizarNumTropas();
                                Debug.Log("Atacante Perdeu, agora tem " + tdAtacante.NumTropas.ToString() + "Tropas");
                            }
                        }
                    }
                    if ((tdDefensor.NumTropas <= 0)||( tdAtacante.NumTropas == 1)){
                        btnConfirmaText.text = "Fechar";
                    }
                    dadosatacantes.Clear();
                    dadosdefensores.Clear();
                }
                else
                {
                    
                    if(tdDefensor.NumTropas <= 0) // este eh o if que diz se ganhou ou nao
                    {
                        tdDefensor.ConquistaTerritorio(TurnoManager.GetJogadorDaVez());
                        
                        // Colocar carta no inventario do jogador caso possa
                        /* Por enquanto, com um baralho de cartas vazio, isso da erro nos nossos testes.
                        if(!TurnoManager.ConquistouUmTerritorio)
                        {
                            Carta c = BaralhoDeCartas.PuxarCarta();
                            TurnoManager.GetJogadorDaVez().AddCarta(c);

                            // esta flag abaixa quando BotaoDeAvancar passa o turno para o proximo jogador
                            TurnoManager.ConquistouUmTerritorio = true;
                        }
                        */                  
                        // Abrir o painel seletor de tropas

                        st.tdSaida = tdAtacante;
                        st.AbrirSeletor(tdDefensor);
                        tdAtacante.AtualizaEstado(TerritorioDisplay.Estado.Normal);
                        tdDefensor.AtualizaEstado(TerritorioDisplay.Estado.Normal);
                    }
                    else
                    {

                        tdAtacante.AtualizaEstado(TerritorioDisplay.Estado.Normal);
                        tdDefensor.AtualizaEstado(TerritorioDisplay.Estado.Indisponivel);
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
