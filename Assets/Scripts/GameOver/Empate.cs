using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Empate : MonoBehaviour
{
    public AudioSource AudioSource1;
    public AudioClip AuLose;
    public static Empate sharedInstance;
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
    }
    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void ApplyUserOptions()
    {
        username.text = DataPersistence.sharedInstance.saveName;
    }

}
