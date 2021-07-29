using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continente
{
    private string nome;
    private List<Territorio> territorios;

    public Continente(string nome, List<Territorio> territorios)
    {
        this.nome = nome;
        this.territorios = territorios;
        //talvez um for que coloque o territorio.continente para esse
    }
}
