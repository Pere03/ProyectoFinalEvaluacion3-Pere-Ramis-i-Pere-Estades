using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emotes : MonoBehaviour
{
    public GameObject EmotesOne;
    public GameObject EmotesMenu;
    public GameObject JiJiJiJa;
    public GameObject Grrrr;
    public GameObject TaBien;
    public GameObject Lloros;

    public AudioClip Audio_JiJiJiJa;
    public AudioClip Audio_Grrr;
    public AudioClip Audio_TaBien;
    public AudioClip Audio_Lloros;

    private AudioSource PlayerAudioSource;

    void Start()
    {
        PlayerAudioSource = GetComponent<AudioSource>();
        EmotesMenu.SetActive(false);
    }

    
    void Update()
    {
        
    }


    public void EmotesMenuFuncion()
    {
        EmotesOne.SetActive(false);
        EmotesMenu.SetActive(true);
    }

    //Con esto hacemos que aparezca un emoticono, y vuelve al menu inicial de los emoticonos
    public void EmotesJiJiJiJa()
    {
        GameObject newEmote = Instantiate(JiJiJiJa, new Vector3(726, -222, 0), transform.rotation) as GameObject;
        newEmote.transform.SetParent(GameObject.FindGameObjectWithTag("Emotes").transform,false);
        EmotesMenu.SetActive(false);
        EmotesOne.SetActive(true);
    }

    //Con esto hacemos que aparezca un emoticono, y vuelve al menu inicial de los emoticonos
    public void EmotesGrrr()
    {
        GameObject newEmote1 = Instantiate(Grrrr, new Vector3(726, -222, 0), transform.rotation) as GameObject;
        newEmote1.transform.SetParent(GameObject.FindGameObjectWithTag("Emotes").transform, false);
        EmotesMenu.SetActive(false);
        EmotesOne.SetActive(true);
    }

    //Con esto hacemos que aparezca un emoticono, y vuelve al menu inicial de los emoticonos
    public void EmotesLloros()
    {
        GameObject newEmote2 = Instantiate(Lloros, new Vector3(726, -222, 0), transform.rotation) as GameObject;
        newEmote2.transform.SetParent(GameObject.FindGameObjectWithTag("Emotes").transform, false);
        EmotesMenu.SetActive(false);
        EmotesOne.SetActive(true);
    }

    //Con esto hacemos que aparezca un emoticono, y vuelve al menu inicial de los emoticonos
    public void EmotesTaBien()
    {
        GameObject newEmote3 = Instantiate(TaBien, new Vector3(726, -222, 0), transform.rotation) as GameObject;
        newEmote3.transform.SetParent(GameObject.FindGameObjectWithTag("Emotes").transform, false);
        EmotesMenu.SetActive(false);
        EmotesOne.SetActive(true);
    }
}
