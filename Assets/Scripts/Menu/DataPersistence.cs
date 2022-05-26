using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence sharedInstance;

    public string saveName;
    public int Copas;


    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
            DontDestroyOnLoad(sharedInstance);
        }
        else
        {
            Destroy(this);
        }
    }

    public void Data()
    {
        PlayerPrefs.SetString("NOMBRE", saveName);
        PlayerPrefs.SetInt("COPAS", Copas);
    }
}
