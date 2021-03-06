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
        // Botoes
        public Button btnConfirma;
        public Text btnConfirmaText;
        public Button btnFechar;
        
        // Atributos que apontam para outras classes
        public GameObject panel;
        public BaralhoDeCartas baralhoDeCartas = null;
        private SeletorTropas st;
        private DialogoMsg dialogoMsg;
        
        // Dados
        public GameObject Dadodef;
        public GameObject Dadoataq;
        private List<GameObject> DadoA = new List<GameObject>();
        private List<GameObject> DadoD = new List<GameObject>();
        private Vector3 posdef = new Vector3(7.75f, 3.6f, 0);
        private Vector3 posataq = new Vector3(-7.75f, 3.6f, 0);

        // Atributos dos territorioDisplay manipulados
        public TerritorioDisplay tdAtacante;
        public TerritorioDisplay tdDefensor;

        // Action
        public static System.Action<Jogador, TerritorioDisplay> onCaptura;

        void Start()
        {
            onCaptura += TurnoManager.ChecarVitoria;

            st = GetComponent<SeletorTropas>();
            dialogoMsg = GetComponent<DialogoMsg>();
            TurnoManager.dialogoMsg = dialogoMsg;

            btnConfirma.onClick.AddListener(BtnConfirma);
            btnFechar.onClick.AddListener(BtnFechar);
        }
        void BtnConfirma()
        {
            List<int> dadosatacantes = new List<int>();
            List<int> dadosdefensores = new List<int>();
            int somatorio = 0;
            if (btnConfirmaText.text == "Rolar")
            {
                while (somatorio < 3)
                {

                    if ((tdAtacante.NumTropas - 1) >= (somatorio + 1))
                    {
                        dadosatacantes.Add(Random.Range(1, 6));
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
                for(int j = 0; j < 3; j++)
                {
                    //Debug.Log(dadosatacantes.Count.ToString());
                    if (dadosdefensores.Count > j)
                        DadoD.Add(Instantiate(Dadodef, new Vector3(posdef.x, posdef.y - (2.1f * j), posdef.z), valor(dadosdefensores[j])));

                    if (dadosatacantes.Count > j)
                        DadoA.Add(Instantiate(Dadoataq, new Vector3(posataq.x, posataq.y - (2.1f * j), posataq.z), valor(dadosatacantes[j])));
                
                }
                if (dadosatacantes.Count <= dadosdefensores.Count)
                {
                    for (int i = 0; i < dadosatacantes.Count; i++)
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
                if ((tdDefensor.NumTropas <= 0) || (tdAtacante.NumTropas == 1))
                {
                    btnConfirmaText.text = "Fechar";
                }
                GameObject temp;
                for(int j = 2; j > -1; j--)
                {
                    if (DadoA.Count - 1 >= (j))
                    {
                        temp = DadoA[j];
                        DadoA.Remove(DadoA[j]);
                        Destroy(temp, 0.7500f);
                    }
                    if (DadoD.Count - 1 >= (j))
                    {
                        temp = DadoD[j];
                        DadoD.Remove(DadoD[j]);
                        Destroy(temp, 0.7500f);
                    }
                }
                DadoA.Clear();
                DadoD.Clear();
                dadosatacantes.Clear();
                dadosdefensores.Clear();
            }
            else
            {

                if (tdDefensor.NumTropas <= 0) // este eh o if que diz se ganhou ou nao
                {
                    tdDefensor.ConquistaTerritorio(TurnoManager.GetJogadorDaVez());

                    // Colocar carta no inventario do jogador caso possa
                    // Por enquanto, com um baralho de cartas vazio, isso da erro nos nossos testes.
                    if (!TurnoManager.ConquistouUmTerritorio)
                    {
                        if (baralhoDeCartas != null)
                        {
                            Carta c = baralhoDeCartas.PuxarCarta();
                            TurnoManager.GetJogadorDaVez().AddCarta(c);
                        }
                        // esta flag abaixa quando BotaoDeAvancar passa o turno para o proximo jogador
                        TurnoManager.ConquistouUmTerritorio = true;
                    }
                    // Abrir o painel seletor de tropas

                    st.tdSaida = tdAtacante;
                    st.AbrirSeletor(tdDefensor);

                    // mudar essa implementacao quando puder, ta feio
                    tdAtacante.Tabuleiro.DeselecionarTodosTerritorios();
                    tdAtacante.AtualizaEstado(TerritorioDisplay.Estado.Indisponivel);
                    onCaptura?.Invoke(TurnoManager.GetJogadorDaVez(), tdDefensor); // Action chamada
                }
                else
                {
                    tdAtacante.Tabuleiro.DeselecionarTodosTerritorios();
                    tdAtacante.Tabuleiro.NormalizarTerritoriosDoJogador(TurnoManager.GetJogadorDaVez());
                }
                tdAtacante = null;
                tdDefensor = null;
                panel.SetActive(false);
            }

        }

        void BtnFechar()
        {
            FecharRolador();
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
            if (tdAtacante.NumTropas == 1)
            {
                dialogoMsg.MostraDiag("N??o se pode atacar com um exercito no territorio");
            }
            else
            {
                tdDefensor = t;
                panel.SetActive(true);
                btnConfirmaText.text = "Rolar";
            }
        }

        public void FecharRolador()
        {
            tdAtacante.Tabuleiro.DeselecionarTodosTerritorios();
            tdAtacante.Tabuleiro.NormalizarTerritoriosDoJogador(TurnoManager.GetJogadorDaVez());

            tdAtacante = null;
            tdDefensor = null;

            panel.SetActive(false);
        }

    }
}
