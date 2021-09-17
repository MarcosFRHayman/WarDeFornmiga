using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FormigaWar.Territorios;
using FormigaWar.Jogadores;
using FormigaWar;

namespace FormigaWar
{
    public class MaoUI : MonoBehaviour
    {
        // Variaveis que apontam para outras classes

        public GameObject painel;
        public Transform grid;
        public Button btncancela;
        public Button btnconfirma;
        public Jogador j = null;
        public DialogoMsg dialogoMsg;

        // ButtonCarta
        public GameObject prefabBtnCarta;

        // Variaveis Listas
        public List<CartaButton> cartas = new List<CartaButton>();    
        public List<CartaButton> cartasSelecionadas = new List<CartaButton>();

        // Valor de Troca

        public int valorDeTroca = 4;

        public void Start()
        {
            btnconfirma.onClick.AddListener(BtnConfirma);
            btncancela.onClick.AddListener(BtnCancela);
            dialogoMsg = GetComponent<DialogoMsg>();

            Jogador j = new JogadorHumano();


            AbrirMao(j);
        }
        public void AddSelected(CartaButton cb)
        {
            cartasSelecionadas.Add(cb);
            if(cartasSelecionadas.Count == 3) btnconfirma.interactable = true;
        }

        void BtnConfirma()
        {
            List<Carta> cartas = new List<Carta>();
            foreach(CartaButton cb in cartasSelecionadas)
            {
                cartas.Add(cb.carta);
            }
            if(ChecaTrocavel(cartas))
            {
                j.reservas += valorDeTroca;
                valorDeTroca += 2;
                LimparMao();
            }
            else
            {
                dialogoMsg.MostraDiag("Selecione Cartas de 3 simbolos iguais ou 3 símbolos diferentes");
                foreach(CartaButton c in cartasSelecionadas)c.button.interactable = true;
                cartasSelecionadas.Clear();
            }
        }
        void BtnCancela()
        {
            LimparMao();
            
            painel.SetActive(false);
        }

        public bool ChecaTrocavel(List<Carta> c)
        {
            return false;
        }

        public void AbrirMao(Jogador j)
        {
            if(j.GetMao().Length >= 5)
            btnconfirma.interactable = false;
            foreach(Carta c in j.GetMao())
            {
                GameObject spawnado = Instantiate(prefabBtnCarta, grid);
                CartaButton cb =  spawnado.GetComponent<CartaButton>();
                cb.carta = c; // passar a carta para o CartaButton
                cb.maoUI = this; // passar o maoUI para o CartaButton 
                cartas.Add(cb);               
            }

            painel.SetActive(true);
        }

        void LimparMao()
        {
            foreach(CartaButton cb in cartas)
            {
                Destroy(cb.gameObject);
            }
            cartasSelecionadas.Clear();
        }
    }
}
