using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FormigaWar.Territorios;
using FormigaWar;

namespace FormigaWar
{
    public class MaoUI : MonoBehaviour
    {
        // Variaveis que apontam para outras classes

        public GameObject painel;
        public Button btncancela;
        public Button btnconfirma;

        // Variaveis Listas
        public List<CartaButton> cartas = new List<CartaButton>();    
        public List<CartaButton> cartasSelecionadas = new List<CartaButton>();
        
        // Start is called before the first frame update
        void Start()
        {
            
        }

        public void AddSelected(CartaButton cb)
        {
            cartasSelecionadas.Add(cb);
        }

        void BtnConfirma()
        {
            List<Carta> cartas = new List<Carta>();
            foreach(CartaButton cb in cartasSelecionadas)
            {
                cartas.Add(cb.carta);
            }
            
            cartasSelecionadas.Clear();
        }
        void BtnCacela()
        {
            cartasSelecionadas.Clear();
            painel.SetActive(false);
        }

        void ChecaTrocavel(List<Carta> c)
        {
            
        }
    }
}
