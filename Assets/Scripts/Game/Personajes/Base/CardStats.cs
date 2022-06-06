using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardStats
{
    //Con esto asignamos las bases de nuestra carta, su nombre, imagen, coste y la unidad a instanciar
    [SerializeField]
    private int index;

    [SerializeField]
    private string name;

    [SerializeField]
    private Sprite icon;

    [SerializeField]
    private int cost;

    [SerializeField]
    private GameObject prefab;

    public int Index
    {
        get { return index; }
        set { index = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Sprite Icon
    {
        get { return icon; }
        set { icon = value; }
    }

    public int Cost
    {
        get { return cost; }
        set { cost = value; }
    }

    public GameObject Prefab
    {
        get { return prefab; }
        set { prefab = value; }
    }

}
