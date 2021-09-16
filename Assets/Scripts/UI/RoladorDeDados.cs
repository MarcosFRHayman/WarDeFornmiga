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
            public GameObject Dadodef;
            public GameObject Dadoataq;
            private List<GameObject> DadoA = new List<GameObject>();
            private List<GameObject> DadoD = new List<GameObject>();
            private Vector3 posdef = new Vector3(-10.3299999f, -3.6500001f, 0);
            private Vector3 posataq = new  Vector3(-10.3299999f, -1.22000003f, 0);

            // Atributos dos territorioDisplay manipulados
            public TerritorioDisplay tdAtacante;
            public TerritorioDisplay tdDefensor;

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
                    int j = 0;
                    GameObject temporario = Instantiate(Dadoataq,new Vector3 (posataq.x, posataq.y+(2.13f*j), posataq.z), valor(dadosatacantes[j]));
                    while (j < 3)
                    {
                        if (dadosdefensores.Count>= j) 
                        {
                            DadoA.Add(temporario);
                        }
                        if(dadosatacantes.Count >= j)
                        {
                            DadoD.Add(temporario);
                        }
                    j++;
                    }
                    if (dadosatacantes.Count <= dadosdefensores.Count)
                    {   
                        for(int i = 0; i<dadosatacantes.Count; i++)
                        {
                            if (dadosatacantes[i] > dadosdefensores[i])
                            {
                                //Debug.Log("Atacante Venceu");
                                tdDefensor.NumTropas -= 1;
                                tdDefensor.AtualizarNumTropas();
                            }
                            else
                            {
                                tdAtacante.NumTropas -= 1;
                                tdAtacante.AtualizarNumTropas();
                                //Debug.Log("Atacante Perdeu, agora tem " + tdAtacante.NumTropas.ToString() + "Tropas");
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dadosdefensores.Count; i++)
                        {
                            if (dadosatacantes[i] > dadosdefensores[i])
                            {
                                //Debug.Log("Atacante Venceu");
                                tdDefensor.NumTropas -= 1;
                                tdDefensor.AtualizarNumTropas();
                            }
                            else
                            {
                                tdAtacante.NumTropas -= 1;
                                tdAtacante.AtualizarNumTropas();
                                //Debug.Log("Atacante Perdeu, agora tem " + tdAtacante.NumTropas.ToString() + "Tropas");
                            }
                        }
                    }
                    if ((tdDefensor.NumTropas <= 0)||( tdAtacante.NumTropas == 1)){
                        btnConfirmaText.text = "Fechar";
                    }
                    GameObject temp;
                    j = 2;
                    while (j >-1)
                    {
                        if (DadoA.Count-1 <= (j))
                        {
                            temp = DadoA[j];
                            DadoA.Remove(DadoA[j]);
                            DestroyObject(temp, 500f);
                        }
                        if (DadoD.Count-1 <= (j))
                        {
                        temp = DadoD[j];
                        DadoD.Remove(DadoD[j]);
                        DestroyObject(temp, 500f);
                        }
                    j--;
                    }
                    DadoA.Clear();
                    DadoD.Clear();
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

                        // mudar essa implementacao quando puder, ta feio
                        tdAtacante.Tabuleiro.DeselecionarTodosTerritorios();
                        tdAtacante.Tabuleiro.NormalizarTerritoriosDoJogador(TurnoManager.GetJogadorDaVez());
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

         
            private Quaternion valor(int i)
        {
            switch (i)
            {
                case 1:
                    return new Quaternion(1, 0, 0, 0);
                case 2:
                    return new Quaternion(0.707106829f, 0, 0, 0.707106829f);
                case 3:
                    return new Quaternion(0, 0.707106829f, 0, 0.707106829f);
                case 4:
                    return new Quaternion(0, -0.707106829f, 0, 0.707106829f);
                case 5:
                    return new Quaternion(-0.707106829f, 0, 0, 0.707106829f);
                default:
                    return new Quaternion(0, 0, 0, 1);
                
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
