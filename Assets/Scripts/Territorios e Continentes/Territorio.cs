using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Territorio", fileName = "newTerritorio")]
    public class Territorio : ScriptableObject
    {

        //atributos de classe
        [SerializeField] private string nome;
        [SerializeField] private List<Fronteira> fronteiras;
        [SerializeField] private CartaTerritorio cartaterritorio;
        [SerializeField] private Continente continente;

        public string Nome { get => nome; private set => this.nome = value; }
        public List<Fronteira> Fronteiras { get => fronteiras; private set => this.fronteiras = value; }
        public CartaTerritorio Carta { get => cartaterritorio; private set => this.cartaterritorio = value; }
        public Continente Continente { get => continente; internal set { this.continente = value; } }

        //public Territorio(string nome, List<Fronteira> fronteiras, Carta cartaterritorio, int numtropas, Continente continente) // construtor basico
        //{
        //    this.nome = nome;
        //    this.fronteiras = fronteiras;
        //    this.cartaterritorio = cartaterritorio;
        //    this.numtropas = numtropas;
        //    this.continente = continente; // talvez colocar isso na hora de fazer o continente?
        //}


    }
}
