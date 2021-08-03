using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;
using FormigaWar;

public class Tabuleiro : MonoBehaviour
{
    [SerializeField] private SeletorTropas seletortropas;
    [SerializeField] private List<Continente> continentes; // talvez tabuleiro guarde apenas os continentes?
    [SerializeField] private List<TerritorioDisplay> territorios;

    void Start()
    {
        seletortropas = GameObject.Find("Canvas").GetComponent<SeletorTropas>();
    }

    public void InicializarTabuleiro() // pode ser util caso tenhamos que testar multiplos tabuleiros
    {

    }

    public void SelecionarTerritorio(TerritorioDisplay display)
    {

        // TODO: Mudar para switch
        if (display.estado == "normal")
        {
            for (int i = 0; i < territorios.Count; i++)
            {
                territorios[i].AtualizaEstado("normal");
            }

            for (int j = 0; j < display.Territorio.Fronteiras.Count; j++)
            {
                Fronteira f = display.Territorio.Fronteiras[j];
                // f.OtherTerritorio(display.Territorio).Display.AtualizaEstado("selecionavel");
            }

            display.AtualizaEstado("selecionado");
        }
        else if (display.estado == "selecionavel")
        {
            // abrir o painel seletor e bl�
            seletortropas.AbrirSeletor(display);
        }

    }

    public void DesabilitarContinentesMenosUm() // para fase de fortificacao, quando o jogador tiver conquistado um continente
    {

    }
}
