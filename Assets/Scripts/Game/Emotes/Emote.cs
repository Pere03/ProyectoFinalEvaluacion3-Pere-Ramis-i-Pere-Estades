using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emote : MonoBehaviour
{
    private float currentTime = 0f;
    private float startingTime = 1.5f;
    void Start()
    {
        currentTime = startingTime;
    }

    
    void Update()
    {
        //Esto es una cuenta atras para cuando lancemos un emoticono, que hará que se destruia
        currentTime -= 1 * Time.deltaTime;
        if ( currentTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
