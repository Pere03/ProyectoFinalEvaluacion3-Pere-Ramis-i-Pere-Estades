using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject ReyBarbaro_Menu;
    public GameObject Ejercito_Menu;
    public GameObject MiniPekka_Menu;
    public GameObject Duendes_Menu;
    public GameObject Leñador_Menu;
    public GameObject Peepo_Menu;
    public GameObject Pekka_Menu;
    public GameObject ReyDuende_Menu;

    void Start()
    {
        ReyBarbaro_Menu.SetActive(false);
        Ejercito_Menu.SetActive(false);
        MiniPekka_Menu.SetActive(false);
        Duendes_Menu.SetActive(false);
        Leñador_Menu.SetActive(false);
        Peepo_Menu.SetActive(false);
        Pekka_Menu.SetActive(false);
        ReyDuende_Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rey_Barbaro()
    {
        ReyBarbaro_Menu.SetActive(true);
    }

    public void Ejercito()
    {
        Ejercito_Menu.SetActive(true);
    }

    public void MiniPekka()
    {
        MiniPekka_Menu.SetActive(true);
    }

    public void Duendes()
    {
        Duendes_Menu.SetActive(true);
    }

    public void Leñador()
    {
        Leñador_Menu.SetActive(true);
    }

    public void Peepo()
    {
        Peepo_Menu.SetActive(true);
    }

    public void Pekka()
    {
        Pekka_Menu.SetActive(true);
    }

    public void ReyDuende()
    {
        ReyDuende_Menu.SetActive(true);
    }

    public void Close()
    {
    ReyBarbaro_Menu.SetActive(false);
    Ejercito_Menu.SetActive(false);
    MiniPekka_Menu.SetActive(false);
    Duendes_Menu.SetActive(false);
    Leñador_Menu.SetActive(false);
    Peepo_Menu.SetActive(false);
    Pekka_Menu.SetActive(false);
    ReyDuende_Menu.SetActive(false);
    }
}
