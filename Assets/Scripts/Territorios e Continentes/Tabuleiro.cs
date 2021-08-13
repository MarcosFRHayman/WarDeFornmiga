using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;
using FormigaWar;

public class Tabuleiro : MonoBehaviour // TODO : Separar os dados desta classe para uma outra classe tabuleiro
{

    [SerializeField] private GameObject territorioprefab;
    [SerializeField] private SeletorTropas seletortropas;
    [SerializeField] private List<Continente> continentes; // talvez tabuleiro guarde apenas os continentes?
    [SerializeField] private List<TerritorioDisplay> territoriosInstanciados;
    void Start()
    {
        seletortropas = GameObject.Find("Canvas")?.GetComponent<SeletorTropas>();
        InicializarTabuleiro();
        InicializaBaralhoComTerritorios();
    }

    private void InicializaBaralhoComTerritorios()
    {
        List<Territorio> territorioLista = new List<Territorio>();
        foreach (Continente continente in continentes)
            territorioLista.AddRange(continente.GetTerritorios());
        BaralhoDeCartas.Inicializar(territorioLista);
    }

    public void InicializarTabuleiro()
    {
        Continente c = continentes[0]; // foreach(Continente c in continentes)

        var obj = Instantiate(territorioprefab, new Vector3(), Quaternion.identity);
        TerritorioDisplay td = obj.GetComponent<TerritorioDisplay>();

        td.SetTerritorio(c.GetTerritorios()[0]);
        td.NumTropas = 1;
        territoriosInstanciados.Add(td);

        InicializarTabuleiroAux(td);

    }

    private void InicializarTabuleiroAux(TerritorioDisplay td)
    {
        //Debug.Log("Vendo os vizinhos de " +td.Territorio.Nome);
        Vector3 spawnpos = td.transform.position + new Vector3(1.7f, 1f, 0f);
        Quaternion spawnrot = new Quaternion();



        foreach (Fronteira f in td.Territorio.Fronteiras)
        {
            //Debug.Log("Dentro da iteração do foreach, analisando fronteira de "+ td.Territorio.Nome +" com " + f.OtherTerritorio(td.Territorio).Nome);

            Territorio tadd = f.OtherTerritorio(td.Territorio);
            bool jexiste = false;

            foreach (TerritorioDisplay t in territoriosInstanciados) //se o territorio ja existe, nao instancie
            {

                if (t.Territorio == tadd)
                {
                    //Debug.Log(tadd.Nome + " já esta instanciado");
                    if (!td.fronteirasDisplay.Contains(t)) td.fronteirasDisplay.Add(t);
                    jexiste = true;
                }
            }

            if (jexiste) continue;

            var obj = Instantiate(territorioprefab, spawnpos, spawnrot);
            TerritorioDisplay td2 = obj.GetComponent<TerritorioDisplay>();
            td2.SetTerritorio(tadd);
            td2.NumTropas = 1;
            td.fronteirasDisplay.Add(td2);
            td2.fronteirasDisplay.Add(td);
            territoriosInstanciados.Add(td2);
            InicializarTabuleiroAux(td2);
        }
    }

    public void DeselecionarTodosTerritorios() // usado quando um territorio eh clicado
    {
        for (int i = 0; i < territoriosInstanciados.Count; i++)
        {
            territoriosInstanciados[i].AtualizaEstado(TerritorioDisplay.Estado.Normal);
        }
    }

    public void DesabilitarContinentesMenosUm() // para fase de fortificacao, quando o jogador tiver conquistado um continente
    {

    }
}
