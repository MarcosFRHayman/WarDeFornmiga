using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;
using FormigaWar.Jogadores;
using FormigaWar;

[System.Serializable]
public class Tabuleiro // TODO : Separar os dados desta classe para uma outra classe tabuleiro
{

    [SerializeField] private GameObject territorioprefab;
    // [SerializeField] private SeletorTropas seletortropas;
    [SerializeField] private List<Continente> continentes = new List<Continente>(); // talvez tabuleiro guarde apenas os continentes?
    public Continente[] Continentes => continentes.ToArray();
    [SerializeField] private List<TerritorioDisplay> territoriosInstanciados = new List<TerritorioDisplay>();
    public TerritorioDisplay[] TerritoriosInstanciados => territoriosInstanciados.ToArray();
    // public void setSeletorDeTropasPelaPrimeiraVez(SeletorTropas seletor)
    // {
    //     if (seletortropas == null)
    //         seletortropas = seletor;
    // }
    public void Inicializa()
    {
        SpawnaTerritorios();
    }
    public void InicializaTabuleiro(List<Continente> continentes)
    {
        this.continentes = continentes;
        SpawnaTerritorios();
    }
    // public Tabuleiro(SeletorTropas seletorDeTropas)
    // {
    //     setSeletorDeTropasPelaPrimeiraVez(seletorDeTropas);
    //     InicializarTabuleiro();
    //     InicializaBaralhoComTerritorios();
    // }

    private void SpawnaTerritorios()
    {
        
        for(int i = 0; i < territoriosInstanciados.Count; i++)
        {
            territoriosInstanciados[i].Tabuleiro = this;
            territoriosInstanciados[i].NumTropas = 1;
            territoriosInstanciados[i].AtualizarNumTropas();
        }
        
        Continente c = continentes[0]; // foreach(Continente c in continentes)
        TerritorioDisplay td;

        if(territoriosInstanciados.Count == 0)
        {
            var obj = GameObject.Instantiate(territorioprefab, new Vector3(), Quaternion.identity);
            td = obj.GetComponent<TerritorioDisplay>();
            td.Territorio = c.GetTerritorios()[0];
            td.NumTropas = 1;
            td.Tabuleiro = this;
            territoriosInstanciados.Add(td);
            SpawnaTerritoriosAux(td);
        }
        else
        {
            foreach(TerritorioDisplay t in territoriosInstanciados)
            {
                SpawnaTerritoriosAux(t);
            }
            return;
            
        }
    }

    private void SpawnaTerritoriosAux(TerritorioDisplay td)
    {
        //Debug.Log("Vendo os vizinhos de " +td.Territorio.Nome);
        Vector3 spawnpos = td.transform.position + new Vector3(1.7f, 1f, 0f);
        Quaternion spawnrot = new Quaternion();

        td.NumTropas = 1;
        td.Tabuleiro = this;

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

            if (jexiste)continue;

            var obj = GameObject.Instantiate(territorioprefab, spawnpos, spawnrot);
            TerritorioDisplay td2 = obj.GetComponent<TerritorioDisplay>();
            td2.Territorio = tadd;
            td2.NumTropas = 1;
            td.fronteirasDisplay.Add(td2);
            td2.fronteirasDisplay.Add(td);
            territoriosInstanciados.Add(td2);
            SpawnaTerritoriosAux(td2);
        }
    }

    public void DeselecionarTodosTerritorios() // usado quando um territorio eh clicado
    {
        int i = 0;
        for (i = 0; i < territoriosInstanciados.Count; i++)
        {
            territoriosInstanciados[i].AtualizaEstado(TerritorioDisplay.Estado.Indisponivel);
        }
    }

    public void NormalizarTerritoriosDoJogador(Jogador j)
    {
        for (int i = 0; i < j.Territorios.Count; i++)
        {
            j.Territorios[i].AtualizaEstado(TerritorioDisplay.Estado.Normal);
        }
    }

    public void DesabilitarContinentesMenosUm(Continente c) // para fase de fortificacao, quando o jogador tiver conquistado um continente
    {

    }
}
