using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    public class Territorio : MonoBehaviour
    {
        // atributos que apontam para outras classes
        [SerializeField] private TextMesh numtropas_txt;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Tabuleiro tabuleiro;

        //atributo de estado da classe
        public string estado = "normal";

        //atributos de classe
        [SerializeField]private string nome;
        [SerializeField]private List<Fronteira> fronteiras;
        [SerializeField]private Carta cartaterritorio;
        [SerializeField]private int numtropas;
        [SerializeField]private Continente continente;

        //public Territorio(string nome, List<Fronteira> fronteiras, Carta cartaterritorio, int numtropas, Continente continente) // construtor basico
        //{
        //    this.nome = nome;
        //    this.fronteiras = fronteiras;
        //    this.cartaterritorio = cartaterritorio;
        //    this.numtropas = numtropas;
        //    this.continente = continente; // talvez colocar isso na hora de fazer o continente?
        //}

        // Setters
        public void SetNome(string nome) { this.nome = nome; }
        public void SetFronteiras(List<Fronteira> fronteiras) { this.fronteiras = fronteiras; }
        public void SetCarta(Carta cartaterritorio) { this.cartaterritorio = cartaterritorio; }
        public void SetNumTropas(int numtropas) { this.numtropas = numtropas; AtualizarNumTropas(); }
        public void SetContinente(Continente continente) { this.continente = continente; }

        // Getters
        public string GetNome() { return this.nome; }
        public List<Fronteira> GetFronteiras() { return this.fronteiras; }
        public Carta GetCartaTerritorio() { return this.cartaterritorio; }
        public int GetNumTropas() { return this.numtropas; }
        public Continente GetContinente() { return this.continente; }


        void Start() 
        {
            numtropas_txt.text = numtropas.ToString();
            spriteRenderer = GetComponent<SpriteRenderer>();
            tabuleiro = GameObject.Find("EventSystem").GetComponent<Tabuleiro>();
        }

        private void AtualizarNumTropas()
        {
            numtropas_txt.text = numtropas.ToString();
        }

        public void AtualizaEstado(string novo_estado)
        {
            if (novo_estado == "selecionado") // talvez tenha um jeito melhor de fazer isso
            {
                this.estado = novo_estado;
                spriteRenderer.color = Color.yellow;
            }
            else if (novo_estado == "selecionavel") // selecionavel se de um territorio pode selecionar este outro
            {
                this.estado = novo_estado;
                spriteRenderer.color = new Vector4(255f, 0f, 255f, 1f);
            }
            else if (novo_estado == "normal") // selecionavel do primeiro clique
            {
                this.estado = novo_estado;
                spriteRenderer.color = Color.white;
            }
            else if (novo_estado == "indisponivel")
            {
                this.estado = novo_estado;
                spriteRenderer.color = Color.gray;
            }
            else
            {
                Debug.Log("AtualizaEstado foi chamado mas com um estado não identificado");
            }
        }

        void OnMouseDown() // quando o territorio for clicado...
        {
            tabuleiro.SelecionarTerritorio(this);
        }
    }
}
