using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FormigaWar.Jogadores;

namespace FormigaWar.Territorios
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class TerritorioDisplay : MonoBehaviour
    {
        private SeletorTropas seletorTropas;
        private RoladorDeDados roladorDeDados;
        [SerializeField] private Jogador jogador; // jogador que tem o territorio
        [SerializeField] private Territorio territorio;
        [SerializeField] private TextMesh numtropas_txt;
        [SerializeField] private SpriteRenderer spriteEstado;
        [SerializeField] private SpriteRenderer spriteJogador; // segundo sprite com a cor do jogador
        
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
            seletorTropas = GameObject.Find("Canvas").GetComponent<SeletorTropas>();
            roladorDeDados = GameObject.Find("Canvas").GetComponent<RoladorDeDados>();
            numtropas_txt.text = numtropas.ToString();
        }

        public void AtualizarNumTropas() => numtropas_txt.text = (numtropas + numtropas_to_move).ToString();

        public void ConquistaTerritorio(Jogador j) // metodo usado quando na fase de ataque, alguem conquistar um territorio
        {
            
            if(jogador != null)jogador.Territorios.Remove(this);     // remove o territorio do antigo dono
            jogador = j;                                             // bota o jogador que o conquistou
            j.Territorios.Add(this);                                 // bota o territorio no jogador
            spriteJogador.color = j.Cor;                             // e bota a cor do territorio pra cor do exercito
        }

        public void AtualizaEstado(Estado novo_estado)
        {
            estado = novo_estado;
            switch (novo_estado)
            {
                case Estado.Normal:                   
                    spriteEstado.color = Color.white;
                    break;
                case Estado.Selecionado:
                    spriteEstado.color = Color.yellow;
                    break;
                case Estado.Selecionavel:
                    spriteEstado.color = Color.magenta;
                    break;
                case Estado.Indisponivel:
                    spriteEstado.color = Color.gray;
                    break;
                default:
                    Debug.Log("AtualizaEstado foi chamado mas com um estado n�o identificado");
                    break;
            }

        }

        void OnMouseDown() // quando o territorio for clicado...
        {
            // de inicio esta eh a logica da fase de movimentacao

            switch((int)TurnoManager.faseAtual)
            {
                case 0: // fortificacao continental
                break;
                case 1: // fortificacao
                break;
                case 2: // ataque
                    switch (estado)
                    {
                        case Estado.Normal:
                            Tabuleiro.DeselecionarTodosTerritorios();
                            Tabuleiro.NormalizarTerritoriosDoJogador(TurnoManager.GetJogadorDaVez());
                            roladorDeDados.tdAtacante = this;
                            AtualizaEstado(Estado.Selecionado);
                            
                            
                            for (int i = 0; i < fronteirasDisplay.Count; i++)
                            {
                                TerritorioDisplay t = fronteirasDisplay[i];
                                if(!TurnoManager.GetJogadorDaVez().Territorios.Contains(t))t.AtualizaEstado(Estado.Selecionavel);
                            }
                            break;
                        case Estado.Selecionavel:
                            roladorDeDados.AbrirRolador(this);
                            //seletorTropas.AbrirSeletor(this);
                            break;
                        case Estado.Selecionado:
                            Tabuleiro.DeselecionarTodosTerritorios();
                            Tabuleiro.NormalizarTerritoriosDoJogador(TurnoManager.GetJogadorDaVez());
                            seletorTropas.FecharSeletor();
                            break;
                        case Estado.Indisponivel:
                            break;
                    }
                break;
                case 3: // movimentacao
                    switch (estado)
                    {
                        case Estado.Normal:
                            Tabuleiro.DeselecionarTodosTerritorios();
                            Tabuleiro.NormalizarTerritoriosDoJogador(TurnoManager.GetJogadorDaVez());
                            seletorTropas.tdSaida = this;
                            AtualizaEstado(Estado.Selecionado);
                            
                            
                            for (int i = 0; i < fronteirasDisplay.Count; i++)
                            {
                                TerritorioDisplay t = fronteirasDisplay[i];
                                if(TurnoManager.GetJogadorDaVez().Territorios.Contains(t))t.AtualizaEstado(Estado.Selecionavel);
                            }
                            break;
                        case Estado.Selecionavel:
                            seletorTropas.AbrirSeletor(this);
                            break;
                        case Estado.Selecionado:
                            Tabuleiro.DeselecionarTodosTerritorios();
                            Tabuleiro.NormalizarTerritoriosDoJogador(TurnoManager.GetJogadorDaVez());
                            seletorTropas.FecharSeletor();
                            break;
                        case Estado.Indisponivel:
                            break;
                    }
                break;
                default:
                break;
            }
                
        }
    
        void InteragirTerritorio()
        {

        }
    }
}
