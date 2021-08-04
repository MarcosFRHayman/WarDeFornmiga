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
        public string estado = "normal";

        // Start is called before the first frame update
        void Start()
        {
            numtropas_txt.text = numtropas.ToString();
            spriteRenderer = GetComponent<SpriteRenderer>();
            tabuleiro = GameObject.Find("EventSystem").GetComponent<Tabuleiro>();
        }

        private void AtualizarNumTropas() => numtropas_txt.text = numtropas.ToString();
        
        public void AtualizaEstado(string novo_estado)
        {
            if (novo_estado == "selecionado") // talvez tenha um jeito melhor de fazer isso
            {
                estado = novo_estado;
                spriteRenderer.color = Color.yellow;
            }
            else if (novo_estado == "selecionavel") // selecionavel se de um territorio pode selecionar este outro
            {
                estado = novo_estado;
                spriteRenderer.color = new Vector4(255f, 0f, 255f, 1f);
            }
            else if (novo_estado == "normal") // selecionavel do primeiro clique
            {
                estado = novo_estado;
                spriteRenderer.color = Color.white;
            }
            else if (novo_estado == "indisponivel")
            {
                estado = novo_estado;
                spriteRenderer.color = Color.gray;
            }
            else
            {
                Debug.Log("AtualizaEstado foi chamado mas com um estado n�o identificado");
            }
        }

        public void SetTerritorio(Territorio t)
        {
            territorio = t;
        }

        void OnMouseDown() // quando o territorio for clicado...
        {
            tabuleiro.DeselecionarTodosTerritorios();
            AtualizaEstado("selecionado");
            
            for (int i = 0; i < fronteirasDisplay.Count; i++)
            {
                fronteirasDisplay[i].AtualizaEstado("selecionavel");
            }
        }
    }
}
