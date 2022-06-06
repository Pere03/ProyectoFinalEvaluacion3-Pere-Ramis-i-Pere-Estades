using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource Audio;
    private float musicVolume = 1f;

    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }


    void Update()
    {
        Audio.volume = musicVolume;
    }

    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }
}
