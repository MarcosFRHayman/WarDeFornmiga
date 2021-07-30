using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    public class Territorio : MonoBehaviour
    {
        [SerializeField] private TextMesh numtropas_txt;

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
        }

        private void AtualizarNumTropas()
        {
            numtropas_txt.text = numtropas.ToString();
        }
    }
}
