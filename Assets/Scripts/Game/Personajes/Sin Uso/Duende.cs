using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duende : MonoBehaviour
{
    public float speed = 20f;
    [SerializeField] private float attackDamage = 200f;
    [SerializeField] private float attackSpeed = 2f;
    private float canAtacck;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // LockOn();
    }
     
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("LeftZone"))
        {
            var Torre1 = GameObject.FindWithTag("Torre1");
            transform.LookAt(Torre1.transform);
        }

        if (otherCollider.gameObject.CompareTag("RIghtZone"))
        {
            var Torre2 = GameObject.FindWithTag("Torre2");
            transform.LookAt(Torre2.transform);
        }
        /*
        if (otherCollider.gameObject.tag == ("Torre1"))
        {
            speed = 0;
            otherCollider.gameObject.GetComponent<Torre>().UpdateHealth(-attackDamage);

        }
        
        
        if (otherCollider.gameObject.CompareTag("AttackZoneMelee2"))
        {
            speed = 0;
        }
        */
    }

   
    public void LockOn()
    {
        
        if (GameObject.FindWithTag("Enemigo") != null)
        {
            var Enemigo = GameObject.FindWithTag("Enemigo");
            transform.LookAt(Enemigo.transform);  
        } else
        {
            if (GameObject.FindWithTag("Torre1") != null)
            {
                var Torre = GameObject.FindWithTag("Torre1");
                transform.LookAt(Torre.transform);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
        
        
    }
    
}
