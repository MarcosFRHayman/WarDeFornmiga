using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    public class TerritorioDisplay : MonoBehaviour
    {
        [SerializeField] private Territorio territorio;
        [SerializeField] private TextMesh numtropas_txt;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Tabuleiro tabuleiro;
        [SerializeField] private int numtropas;

        // fronteiras dadas na inicialização do tabuleiro, sim ta publico
        [SerializeField] public List<TerritorioDisplay> fronteirasDisplay; 
        
        public Territorio Territorio { get => territorio; private set => territorio = value; }
        public int NumTropas { get => numtropas; internal set => this.numtropas = value; }
        //atributo de estado da classe
        public enum Estado 
        {
            Normal = 0, Selecionado = 1, Selecionavel = 2, Indisponivel = 3
        }
        public Estado estado = Estado.Normal;

        // Start is called before the first frame update
        void Start()
        {
            numtropas_txt.text = numtropas.ToString();
            spriteRenderer = GetComponent<SpriteRenderer>();
            tabuleiro = GameObject.Find("Canvas").GetComponent<Tabuleiro>(); // muito cuidado com esta linha de codigo
        }

        private void AtualizarNumTropas() => numtropas_txt.text = numtropas.ToString();
        
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
                    spriteRenderer.color = new Vector4(255f, 0f, 255f, 1f);
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

        public void SetTerritorio(Territorio t)
        {
            territorio = t;
        }

        void OnMouseDown() // quando o territorio for clicado...
        {
            // de inicio esta eh a logica da fase de movimentacao
            //if(estado == Estado.Normal)
            //{
                tabuleiro.DeselecionarTodosTerritorios();
                AtualizaEstado(Estado.Selecionado);
                
                for (int i = 0; i < fronteirasDisplay.Count; i++)
                {
                    fronteirasDisplay[i].AtualizaEstado(Estado.Selecionavel);
                }
            //}

            //if(estado == Estado.Selecionavel)
            //{
            //    var seletorTropas = GameObject.Find("Canvas").GetComponent<SeletorTropas>();
            //    seletorTropas.AbrirSeletor(this);
            //}
            
        }
    }
}
