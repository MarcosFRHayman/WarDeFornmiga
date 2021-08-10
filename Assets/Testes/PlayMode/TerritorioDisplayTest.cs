using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using FormigaWar.Territorios;

namespace tests
{
    public class TerritorioDisplayTest
    {
        GameObject prefab = (GameObject)Resources.Load("Territorio Interativo");

        [UnityTest]
        public IEnumerator Quando_AtualizaEstado_normal_entao_muda_a_cor_para_branco()
        {

            GameObject gameObject = GameObject.Instantiate(prefab);
            TerritorioDisplay display = gameObject.GetComponent<TerritorioDisplay>();

            display.AtualizaEstado("normal");
            Assert.AreEqual(Color.white, gameObject.GetComponent<SpriteRenderer>().color);

            yield return null;
        }
        [UnityTest]
        public IEnumerator Quando_AtualizaEstado_selecionado_entao_muda_a_cor_para_amarelo()
        {

            GameObject gameObject = GameObject.Instantiate(prefab);
            TerritorioDisplay display = gameObject.GetComponent<TerritorioDisplay>();

            display.AtualizaEstado("selecionado");
            Assert.AreEqual(Color.yellow, gameObject.GetComponent<SpriteRenderer>().color);

            yield return null;
        }
        [UnityTest]
        public IEnumerator Quando_AtualizaEstado_selecionavel_entao_muda_para_cor_desconhecida()
        {

            GameObject gameObject = GameObject.Instantiate(prefab);
            TerritorioDisplay display = gameObject.GetComponent<TerritorioDisplay>();

            display.AtualizaEstado("selecionavel");
            Assert.AreEqual(Color.magenta, gameObject.GetComponent<SpriteRenderer>().color);

            yield return null;
        }
        [UnityTest]
        public IEnumerator Quando_AtualizaEstado_indisponivel_entao_muda_para_cor_desconhecida()
        {

            GameObject gameObject = GameObject.Instantiate(prefab);
            TerritorioDisplay display = gameObject.GetComponent<TerritorioDisplay>();

            display.AtualizaEstado("indisponivel");
            Assert.AreEqual(Color.gray, gameObject.GetComponent<SpriteRenderer>().color);

            yield return null;
        }
    }
}
