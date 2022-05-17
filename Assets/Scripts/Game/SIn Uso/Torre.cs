using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torre : MonoBehaviour
{
    private float Live;
    [SerializeField] private float maxLive = 3000;
    public Text Vida;
   
    void Start()
    {
        Live = maxLive;
    }

    
    void Update()
    {
        //LockOn();
       Vida.text = Live.ToString();
    }
    /*
    public void LockOn()
    {
        if (GameObject.FindWithTag("Duende") != null)
        {
            var Duende = GameObject.FindWithTag("Duende");
            transform.LookAt(Duende.transform);
        }
    }
    */
    /*
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Duende"))
        {
            Live -= 30;
        }
    }
    */

    public void UpdateHealth(float mod)
    {
        Live += mod;
        if (Live > maxLive)
        {
            Live = maxLive;
        }else if (Live <= 0)
        {
            Live = 0;
            Destroy(gameObject);
        }
    }


}
