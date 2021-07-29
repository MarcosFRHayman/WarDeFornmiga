using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fronteira
{
    private Territorio territorioA;
    private Territorio territorioB;
    private string tipo;


    public Fronteira(Territorio territorioA, Territorio territorioB, string tipo)
    {
        this.territorioA = territorioA;
        this.territorioB = territorioB;
        this.tipo = tipo;
    }

    Territorio OtherTerritorio(Territorio territorio)
    {
        if (territorio == territorioA) return territorioA;
        else return territorioB;
    }
}
