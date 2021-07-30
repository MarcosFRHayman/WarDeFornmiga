using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    public class Territorio : MonoBehaviour
    {
        // atributos que apontam para outras classes
        [SerializeField] private TextMesh numtropas_txt;
        [SerializeField] private SeletorTropas seletortropas;
        [SerializeField] private SpriteRenderer spriteRenderer;

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
            seletortropas = GameObject.Find("Canvas").GetComponent<SeletorTropas>();
        }

        private void AtualizarNumTropas()
        {
            numtropas_txt.text = numtropas.ToString();
        }

        public void AtualizaEstado(string estado)
        {
            if (estado == "selecionado") // talvez tenha um jeito melhor de fazer isso
            {
                spriteRenderer.color = Color.yellow;
            }
            else if (estado == "normal")
            {
                spriteRenderer.color = Color.white;
            }
            else if (estado == "indisponivel")
            {
                spriteRenderer.color = Color.gray;
            }
            else
            {
                Debug.Log("AtualizaEstado foi chamado mas com um estado não identificado");
            }
        }

        void OnMouseDown() // quando o territorio for clicado...
        {

            AtualizaEstado("selecionado"); //colocar territorio como selecionado
            seletortropas.AbrirSeletor(this);
        }
    }
}
