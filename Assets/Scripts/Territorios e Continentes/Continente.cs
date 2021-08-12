using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    [System.Serializable]
    public class Continente // essa vai ser a classe que o Tabuleiro vai usar para instanciar e criar o tabuleiro (Prefabs de territorio e TerritorioDisplay)
    {
        [SerializeField] private string nome;
        [SerializeField] private List<Territorio> territorios;

        public Continente(string nome, List<Territorio> territorios)
        {
            this.nome = nome;
            this.territorios = territorios;

        }

        public void AddTerritorio(Territorio territorio)
        {
            territorios.Add(territorio);
            territorio.Continente = this;
        }

        public List<Territorio> GetTerritorios() {return territorios;} // usado pelo tabuleiro para poder ler os territorios


    }
}