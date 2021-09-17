using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FormigaWar.Territorios;
using FormigaWar.Jogadores;
using FormigaWar;
using System.Linq;

namespace FormigaWar
{
    public class MaoUI : MonoBehaviour
    {
        // Variaveis que apontam para outras classes

        public GameObject painel;
        public Transform grid;
        public Button btncancela;
        public Button btnconfirma;
        public Button btnAbreCarta;
        public Button btnAvancarTurno;
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
            btnAbreCarta.onClick.AddListener(Abrir);
            dialogoMsg = GetComponent<DialogoMsg>();
            /*
            Jogador j = new JogadorHumano(); // ✦ ✹ ❉
            j.AddCarta(new CartaTerritorio() {simbolo =  "✦"});
            j.AddCarta(new CartaTerritorio() {simbolo =  "✹"});
            j.AddCarta(new CartaTerritorio() {simbolo =  "❉"});

            AbrirMao(j);
            */
        }
        public void AddSelected(CartaButton cb)
        {
            cartasSelecionadas.Add(cb);
            List<Carta> c = new List<Carta>();
            foreach(CartaButton bc in cartasSelecionadas)c.Add(bc.carta);
            if(ChecaTrocavel(c)) btnconfirma.interactable = true;
        }
        void BtnConfirma()
        {
            j.reservas += valorDeTroca;
            valorDeTroca += 2;
            LimparMao();
        }
        void BtnCancela()
        {
            LimparMao();
            btnAbreCarta.interactable = true;
            btnAvancarTurno.interactable = true;
            painel.SetActive(false);
        }
        public bool ChecaTrocavel(List<Carta> c)
        {
            if(c.Count != 3)return false;

            List<string> simbolos = new List<string>();
            foreach(Carta carta in c)simbolos.Add(carta.simbolo); // Debug.Log(carta.simbolo);

            int igual = 0;
            int diferente = 0;
            igual = simbolos.Max(simbolo => simbolos.Count(cadaSimbolo => cadaSimbolo.Equals(simbolo) || cadaSimbolo.Equals("✦✹❉")));
            diferente = simbolos.Min(simbolo => simbolos.Count(cadaSimbolo => !cadaSimbolo.Equals(simbolo) || cadaSimbolo.Equals("✦✹❉")));

            //Debug.Log(igual +" "+ diferente);

            if(igual == 3 || diferente == 2)return true;
            else return false;
        }
        public void Abrir()
        {
            AbrirMao(TurnoManager.GetJogadorDaVez());
            btnAvancarTurno.interactable = false;
        }
        public void AbrirMao(Jogador j)
        {
            if(j.GetMao().Length >= 5)btncancela.interactable = false;
            btnconfirma.interactable = false;
            foreach(Carta c in j.GetMao())
            {
                GameObject spawnado = Instantiate(prefabBtnCarta, grid);
                CartaButton cb =  spawnado.GetComponent<CartaButton>();
                cb.carta = c; // passar a carta para o CartaButton
                cb.maoUI = this; // passar o maoUI para o CartaButton 
                cb.texto.text = c.simbolo;
                if(TurnoManager.faseAtual != 1)cb.button.interactable = false;
                cartas.Add(cb);               
            }
            btnAbreCarta.interactable = false;
            painel.SetActive(true);
        }
        void LimparMao()
        {
            foreach(CartaButton cb in cartas)
            {
                Destroy(cb.gameObject);
            }
            cartas.Clear();
        }
    }
}
