using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] Cartas;
    void Start()
    {
        InvokeRepeating("SpawnCard", 5, 7);
    }

    public Vector3 RandomSpawnPosition1()
    {
        return new Vector3(100, 1, -27);
    }

    public Vector3 RandomSpawnPosition2()
    {
        return new Vector3(100, 1, 24);
    }

    public void SpawnCard()
    {
        float randomNumber = Random.Range(0, 3);
        int randomIndex = Random.Range(0, Cartas.Length);

        //Dependiendo de que numero aleatorio contenga randomNumber, iniciara una de las 2 instanciaciones siguientes

        if (randomNumber == 1)
        {

            /*Si randomNumber vale 1, instanciara uno de los 2 obstaculos de forma aleatoria, con la posicion declarada en RandomSpawnPosition1, y tambien rotara 180 grados, 
              para que asi el obstaculo aparezca en la derecha y asi ira hacia la izquierda */
            Instantiate(Cartas[randomIndex], RandomSpawnPosition1(), Quaternion.Euler(new Vector3(0, 180, 0)));
        }
        else
        {

            /*Si randomNumber vale cualquier otro numero que no sea 1, instanciara uno de los 2 obstaculos de forma aleatoria, con la posicion declarada en 
              RandomSpawnPosition2, para que asi el obstaculo aparezca en la izquierda y asi ira hacia la derecha*/
            Instantiate(Cartas[randomIndex], RandomSpawnPosition2(), Cartas[randomIndex].transform.rotation);
        }
    }
}
