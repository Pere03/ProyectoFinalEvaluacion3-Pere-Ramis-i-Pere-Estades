using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    public GameObject proyectil;

    
    void Start()
    {
        //Esto invocara de forma repetida el "SpawnProyectil" cada 4 segundos
        InvokeRepeating("SpawnProyectil", 2f, 4f);
    }

    void Update()
    {
    }

    public void SpawnProyectil()
    {
        //Esto hace que se instancie el prefab del proyectil
            Instantiate(proyectil, transform.position, transform.rotation);
    }

}
