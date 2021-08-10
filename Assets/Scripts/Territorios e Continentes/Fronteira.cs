using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    [System.Serializable]
    public class Fronteira
    {
        [SerializeField] private Territorio territorioA;
        [SerializeField] private Territorio territorioB;
        [SerializeField] private string tipo;


        public Fronteira(Territorio territorioA, Territorio territorioB, string tipo)
        {
            this.territorioA = territorioA;
            this.territorioB = territorioB;
            this.tipo = tipo;
        }

        public Territorio OtherTerritorio(Territorio territorio)
        {
            if (territorio == territorioA) return territorioB;
            else return territorioB;
        }

        public bool Equals(Fronteira obj)
        {
            return (territorioA == obj.territorioA && territorioB == obj.territorioB)
                    || (territorioA == obj.territorioB && territorioB == obj.territorioA);
        }
    }
}