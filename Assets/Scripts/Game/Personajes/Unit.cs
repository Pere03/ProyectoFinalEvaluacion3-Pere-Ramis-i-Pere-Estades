using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Unit : MonoBehaviour, IDamageable
{
	[SerializeField]
	private NavMeshAgent agent;
	[SerializeField]
	private Actor3D unitModel;
	[SerializeField]
	private GameObject target;
	[SerializeField]
	private BaseStats stats;
	[SerializeField]
	private List<GameObject> hitTargets;

	public Actor3D UnitModel { get { return unitModel; } }
	public GameObject Target
	{
		get { return target; }
		set { target = value; }
	}
	public BaseStats Stats
	{
		get { return stats; }
	}
	public List<GameObject> HitTargets
	{
		get { return hitTargets; }
	}
	public NavMeshAgent Agent { get { return agent; } }

	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}

    private void Start()
    {
		List<GameObject> objects = GameManager.Instance.Objects;
		objects = GameManager.GetAllEnemies(transform.position, objects, gameObject.tag);
		target = GameFunctions.GetNearestTarget(objects, stats.DetectionObject, gameObject.tag);
    }

    private void Update()
	{
		if (stats.CurrHealth > 0)
		{
			Agent.speed = stats.MoveSpeed;
			stats.UpdateStats();
			Attack();
			
			if (target != null)
			{
				agent.SetDestination(target.transform.position);
			}
		}
		else
		{
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
						if(GameFunctions.CanAttack(gameObject.tag, target.tag, damageable, stats))
						{
							GameFunctions.Attack(damageable, stats.BaseDamage);
							stats.CurrAttackDelay = 0;
						}
					}
				}
			}
		} else
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

	void IDamageable.TakeDamage(float amount)
	{
		stats.CurrHealth -= amount;
	}
}
