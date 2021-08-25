using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Jogadores;

namespace FormigaWar.Territorios
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class TerritorioDisplay : MonoBehaviour
    {
        [SerializeField] private Jogador jogador; // jogador que tem o territorio
        [SerializeField] private Territorio territorio;
        [SerializeField] private TextMesh numtropas_txt;
        [SerializeField] private SpriteRenderer spriteRenderer;
        public Tabuleiro Tabuleiro { get; set; }
        [SerializeField] private int numtropas = 1; // numero atual de tropas
        public int numtropas_to_move = 0; // numero de tropas disponiveis para mover (importante para fase de movimento)

        // fronteiras dadas na inicialização do tabuleiro, sim ta internal
        internal List<TerritorioDisplay> fronteirasDisplay = new List<TerritorioDisplay>();

        public Territorio Territorio { get => territorio; internal set => territorio = value; }
        public int NumTropas { get => numtropas; internal set => this.numtropas = value; }

        //atributo de estado da classe
        public enum Estado
        {
            Normal = 0, Selecionado = 1, Selecionavel = 2, Indisponivel = 3
        }
        public Estado estado = Estado.Normal;

        void Start()
        {
            numtropas_txt.text = numtropas.ToString();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void AtualizarNumTropas() => numtropas_txt.text = (numtropas + numtropas_to_move).ToString();

        public void ConquistaTerritorio(Jogador j) // metodo usado quando na fase de ataque, alguem conquistar um territorio
        {
            jogador = j;                    // bota o jogador que o conquistou
            spriteRenderer.color = j.Cor;   // e bota a cor do territorio pra cor do exercito
        }

        public void AtualizaEstado(Estado novo_estado)
        {
            switch (novo_estado)
            {
                case Estado.Normal:
                    estado = novo_estado;
                    spriteRenderer.color = Color.white;
                    break;
                case Estado.Selecionado:
                    estado = novo_estado;
                    spriteRenderer.color = Color.yellow;
                    break;
                case Estado.Selecionavel:
                    estado = novo_estado;
                    spriteRenderer.color = Color.magenta;
                    break;
                case Estado.Indisponivel:
                    estado = novo_estado;
                    spriteRenderer.color = Color.gray;
                    break;
                default:
                    Debug.Log("AtualizaEstado foi chamado mas com um estado n�o identificado");
                    break;
            }

        }

        void OnMouseDown() // quando o territorio for clicado...
        {
            var seletorTropas = GameObject.Find("Canvas").GetComponent<SeletorTropas>();
            // de inicio esta eh a logica da fase de movimentacao

            switch (estado)
            {
                case Estado.Normal:
                    Tabuleiro.DeselecionarTodosTerritorios();
                    seletorTropas.t_invoker = this;
                    AtualizaEstado(Estado.Selecionado);

                    for (int i = 0; i < fronteirasDisplay.Count; i++)
                    {
                        fronteirasDisplay[i].AtualizaEstado(Estado.Selecionavel);
                    }
                    break;
                case Estado.Selecionavel:
                    seletorTropas.AbrirSeletor(this);
                    break;
                case Estado.Selecionado:
                    Tabuleiro.DeselecionarTodosTerritorios();
                    seletorTropas.FecharSeletor();
                    break;
                case Estado.Indisponivel:
                    break;
            }
        }
    }
}
