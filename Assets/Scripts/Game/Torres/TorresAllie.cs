using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorresAllie : MonoBehaviour, IDamageable
{
    [SerializeField]
    private BaseStats stats;
    [SerializeField]
    private List<GameObject> hitTargets;
    [SerializeField]
    private GameObject target;

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
        List<GameObject> objects = GameManager.Instance.Objects;
        objects = GameManager.GetAllEnemies(transform.position, objects, gameObject.tag);
        target = GameFunctions.GetNearestTarget(objects, stats.DetectionObject, gameObject.tag);
    }

    void Update()
    {
        if (stats.CurrHealth > 0)
        {
            stats.UpdateStats();
            Attack();
        } else
        {
            print(gameObject.name + "Se ha matao!");
            GameManager.RemoveObjectsFromList(gameObject);
            Destroy(gameObject);
        }
    }

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
