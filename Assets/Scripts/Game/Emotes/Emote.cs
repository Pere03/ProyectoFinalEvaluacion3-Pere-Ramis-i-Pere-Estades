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
        currentTime -= 1 * Time.deltaTime;
        if ( currentTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
