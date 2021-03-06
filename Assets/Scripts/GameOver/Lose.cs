using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{

    public AudioSource AudioSource1;
    public AudioClip AuLose;
    public static Lose sharedInstance;
    public TextMeshProUGUI username;
    public TextMeshProUGUI CopasPerdidas;
    public int copas;
    public int copasPerdidas;

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
        CopasPerdidas.text = "-" + copas;
    }
    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void SaveUserOptions()
    {
        DataPersistence.sharedInstance.Copas -= copas;
        DataPersistence.sharedInstance.Data();
    }

    public void ApplyUserOptions()
    {
        username.text = DataPersistence.sharedInstance.saveName;
    }
}
