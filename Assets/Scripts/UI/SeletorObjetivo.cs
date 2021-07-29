using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeletorObjetivo : MonoBehaviour
{

    public GameObject panel;

    // botoes sao as cartas
    public Button btncartaesq;
    public Button btncartadir;

    //(Futura variável) Objetivo para o jogador

    // Start is called before the first frame update
    void Start()
    {
        btncartaesq.onClick.AddListener(BtnCartaEsq);
        btncartadir.onClick.AddListener(BtnCartaDir);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BtnCartaEsq()
    {
        panel.SetActive(false);
    }

    void BtnCartaDir()
    {
        panel.SetActive(false);
    }

    public void abrirSeletor()
    {
        //abre dialogo
    }
}
