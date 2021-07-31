using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;
using FormigaWar;

public class Tabuleiro : MonoBehaviour
{
    [SerializeField] private SeletorTropas seletortropas;
    [SerializeField] private List<Continente> continentes; // talvez tabuleiro guarde apenas os continentes?
    [SerializeField] private List<Territorio> territorios;
    [SerializeField] private List<Fronteira> fronteiras;

    void Start()
    {
        seletortropas = GameObject.Find("Canvas").GetComponent<SeletorTropas>();
    }

    public void InicializarTabuleiro() // pode ser util caso tenhamos que testar multiplos tabuleiros
    { 

    }
    
    public void SelecionarTerritorio(Territorio territorio)
    {

        // TODO: Mudar para switch
        if (territorio.estado == "normal")
        {
            for (int i = 0; i < territorios.Count; i++)
            {
                territorios[i].AtualizaEstado("normal");
            }

            for (int j = 0; j < territorio.GetFronteiras().Count; j++)
            {
                Fronteira f = territorio.GetFronteiras()[j];
                f.OtherTerritorio(territorio).AtualizaEstado("selecionavel");
            }

            territorio.AtualizaEstado("selecionado");
        }
        else if (territorio.estado == "selecionavel")
        {
            // abrir o painel seletor e blá
            seletortropas.AbrirSeletor(territorio);
        }
        
    }

    public void DesabilitarContinentesMenosUm() // para fase de fortificacao, quando o jogador tiver conquistado um continente
    { 
    
    }
}
