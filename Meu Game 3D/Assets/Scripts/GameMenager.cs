using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMenager : MonoBehaviour
{

    public TextMeshProUGUI hud, msgVitoria;
    public int restantes;
    // Start is called before the first frame update
    void Start()
    {
        restantes = FindObjectsOfType<Moeda>().Length;

        hud.text = $"Moedas restantes: {restantes}";
    }


    public void SubtrairMoedas(int valor)
    {
        restantes -= valor;
        hud.text = $"Moedas restantes: {restantes}";

        if(restantes <=0)
        {
            //ganhou o jogo
            msgVitoria.text = "Parabéns!";
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
