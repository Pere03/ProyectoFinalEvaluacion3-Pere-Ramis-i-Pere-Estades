using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeElixir : MonoBehaviour
{
    public float Elixir;
    public Image visualElixir;
    public Text Textaco;
    public float elixir;
    void Start()
    {
        Elixir = 0;
        StartCoroutine(tiempo());
    }

    
    void Update()
    {
        elixir = Elixir * 10;
        Textaco.text = elixir.ToString();
        visualElixir.GetComponent<Image>().fillAmount = Elixir;
    }

    IEnumerator tiempo()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            if (Elixir < 1)
            {
                Elixir += 0.01f;
            }
        }
    }

    public void Damage()
    {
        Elixir -= 0.1f;
    }
}
