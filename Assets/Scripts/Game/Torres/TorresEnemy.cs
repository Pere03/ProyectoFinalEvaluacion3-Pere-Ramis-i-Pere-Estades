using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorresEnemy : MonoBehaviour, IDamageable
{
    [SerializeField]
    private BaseStats stats;
    [SerializeField]
    private List<GameObject> hitTargets;
    [SerializeField]
    private GameObject target;
    public ParticleSystem ExplosionParticleSystem;
    public GameObject Barra;

    public BaseStats Stats 
    { 
        get
        {
            return stats;
        }
    }
    public List<GameObject> HitTargets
    {
        get
        {
            return hitTargets;
        }
    }
    public GameObject Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }
     
    void IDamageable.TakeDamage(float amount)
    {
        stats.CurrHealth -= amount;
    }

    private void Start()
    {
        //Aquí hacemos que adquiera la lista de enemigos cerca
        List<GameObject> objects = GameManager.Instance.Objects;
        objects = GameManager.GetAllEnemies(transform.position, objects, gameObject.tag);
        target = GameFunctions.GetNearestTarget(objects, stats.DetectionObject, gameObject.tag);
    }

    void Update()
    {
        //Esto hace que si su vida es superior a 0 pueda atacar, pero si su vida es inferior a 0, se elimina de la lista de objetos del game manager y se destruye, ademas de instanciar unas particulas de explosion
        if (stats.CurrHealth > 0)
        {
            stats.UpdateStats();
            Attack();
        } else
        {
            print(gameObject.name + "Se ha matao!");
            GameManager.RemoveObjectsFromList(gameObject);
            Vector3 offset = new Vector3(0, 0, 0);
            var inst = Instantiate(ExplosionParticleSystem, transform.position + offset, ExplosionParticleSystem.transform.rotation);
            inst.Play();
            Destroy(Barra);
            Destroy(gameObject);
        }
    }

    //Con esto hacemos la funcion de ataque de nuesta torre, que cuando tenga un objetivo y pueda atacarlo, pues que le empiece a bajar vida
    void Attack()
    {
        if (target != null)
        {
            if (stats.CurrAttackDelay >= stats.AttackDelay)
            {
                Component damageable = target.GetComponent(typeof(IDamageable));

                if (damageable)
                {
                    if (hitTargets.Contains(target))
                    {
                        if (GameFunctions.CanAttack(gameObject.tag, target.tag, damageable, stats))
                        {
                            GameFunctions.Attack(damageable, stats.BaseDamage);
                            stats.CurrAttackDelay = 0;
                        }
                    }
                }
            }
        }
        else
        {
            List<GameObject> objects = GameManager.Instance.Objects;
            objects = GameManager.GetAllEnemies(transform.position, objects, gameObject.tag);
            target = GameFunctions.GetNearestTarget(objects, stats.DetectionObject, gameObject.tag);
        }
    }

    //Con esto hacemos saber cuando esta en contacto con un enemigo y que tambien puede atacar
    public void OnTriggerEnter(Collider other)
    {
        if (!other.transform.parent.CompareTag(gameObject.tag))
        {
            Component damageable = other.transform.parent.GetComponent(typeof(IDamageable));
            if (damageable)
            {
                if (!hitTargets.Contains(damageable.gameObject))
                {
                    hitTargets.Add(damageable.gameObject);
                }
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag(gameObject.tag))
        {
            GameObject go = GameFunctions.GetNearestTarget(hitTargets, stats.DetectionObject, gameObject.tag, stats.Range);

            if (go != null)
                target = go;
        }
    }   
}
