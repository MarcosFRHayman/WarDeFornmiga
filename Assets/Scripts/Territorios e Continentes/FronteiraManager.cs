using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FormigaWar.Territorios
{
    [System.Serializable]
    public static class FronteiraManager
    {
        private static List<Fronteira> fronteiras = new List<Fronteira>();

        /// <returns>A fronteira entre 2 Territorios, cria uma se não existir</returns>
        public static Fronteira getFronteira(Territorio territorioA, Territorio territorioB)
        {
            if (territorioA.Equals(territorioB)) return null;
            Fronteira novaFronteira = new Fronteira(territorioA, territorioB, "");
            foreach (Fronteira fronteira in territorioA.Fronteiras)
            {
                if (novaFronteira.Equals(fronteira))
                {
                    AdicionaFronteiraSemRepetir(territorioB, fronteira);
                    return fronteira;
                }
            }
            foreach(Fronteira fronteira in territorioB.Fronteiras)
            {
                if (novaFronteira.Equals(fronteira))
                {
                    AdicionaFronteiraSemRepetir(territorioA, fronteira);
                    return fronteira;
                }
            }
            fronteiras.Add(novaFronteira);
            AdicionaFronteiraSemRepetir(territorioA, novaFronteira);
            AdicionaFronteiraSemRepetir(territorioB, novaFronteira);
            Debug.Log("Fronteira entre " + territorioA.Nome + " e " + territorioB.Nome + "Criada");
            return novaFronteira;
        }
        private static void AdicionaFronteiraSemRepetir(Territorio territorio, Fronteira fronteira)
        {
            if (!territorio.Fronteiras.Contains(fronteira))
                territorio.Fronteiras.Add(fronteira);
        }
    }

}