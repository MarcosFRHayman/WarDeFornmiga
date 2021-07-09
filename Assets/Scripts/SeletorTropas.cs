using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeletorTropas : MonoBehaviour
{

    public Text tnum;
    public Button btnmais;
    public Button btnmenos;

    private int number = 0;

    // Start is called before the first frame update
    void Start()
    {
        tnum.text = number.ToString();
        btnmais.onClick.AddListener(BtnMaisOnClick);
        btnmenos.onClick.AddListener(BtnMenosOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BtnMenosOnClick()
    {
        number--;
        tnum.text = (number).ToString();
    }

    void BtnMaisOnClick() 
    {

        number++;
        tnum.text = (number).ToString();
    }
}
