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
        [SerializeField] private CartaTerritorio cartaTerritorio;
        [SerializeField] private Continente continente;
        [SerializeField] private List<Fronteira> fronteiras;


        public string Nome { get => nome; }
        public List<Fronteira> Fronteiras { get => fronteiras; protected set => this.fronteiras = value; }
        public CartaTerritorio Carta { get => cartaTerritorio; private set => this.cartaTerritorio = value; }
        public Continente Continente { get => continente; internal set { this.continente = value; } }

        [Tooltip("Arraste um territorio aqui para adicionar como fronteira")]
        [SerializeField] private Territorio adicionarFronteira;

        void OnValidate()
        {
            if (adicionarFronteira != null)
            {
                FronteiraManager.getFronteira(this, adicionarFronteira);
                adicionarFronteira = null;
            }
            cartaTerritorio.territorio = this;
        }
        public static Territorio criaTerritorio(string nome, Continente continente)
        {
            var territorio = ScriptableObject.CreateInstance<Territorio>();
            territorio.nome = nome;
            territorio.Continente = continente;
            return territorio;
        }
    }
}
