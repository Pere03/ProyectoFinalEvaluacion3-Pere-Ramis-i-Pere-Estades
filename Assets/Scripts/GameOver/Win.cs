using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Win : MonoBehaviour
{

    public GameObject wLose;
    public AudioSource AudioSource1;
    public AudioClip AuLose;
    public static Win sharedInstance;
    public TextMeshProUGUI CopasGanadas;
    public TextMeshProUGUI username;
    public int copas;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        AudioSource1 = GetComponent<AudioSource>();
        AudioSource1.PlayOneShot(AuLose);
        ApplyUserOptions();
        copas = Random.Range(25, 31);
        CopasGanadas.text = "+" + copas;
    }
    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void SaveUserOptions()
    {
        DataPersistence.sharedInstance.Copas += copas;
        DataPersistence.sharedInstance.Data();
    }

    public void ApplyUserOptions()
    {
        username.text = DataPersistence.sharedInstance.saveName;
    }

}
