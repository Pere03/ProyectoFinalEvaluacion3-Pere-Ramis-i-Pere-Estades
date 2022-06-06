using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class UnitE : MonoBehaviour, IDamageable
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


	public Animator animator;
	public Actor3D UnitModel { get { return unitModel; } }

	public AudioSource Audios;
	public AudioClip AuSpawn;
	public AudioClip AuAttack;
	public AudioClip AuWalk;

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
		Audios = GetComponent<AudioSource>();
		Audios.PlayOneShot(AuSpawn);
		animator = GetComponent<Animator>();

		//Aqu� hacemos que se a�ada la unidad en la lista del game manager, y que adquiera la lista de enemigos cerca
		List<GameObject> objects = GameManager.Instance.Objects;
		objects = GameManager.GetAllEnemies(transform.position, objects, gameObject.tag);
		target = GameFunctions.GetNearestTarget(objects, stats.DetectionObject, gameObject.tag);
		GameManager.AddObject(gameObject);
	}

	private void Update()
	{
		//Esto hace que si su vida es superior a 0, que se dirija hacia el enemigo mas cercano, pero si su vida es inferior a 0, se elimina de la lista de objetos del game manager y se destruye
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
	//Con esto hacemos la funcion de ataque de nuesta unidad, que cuando tenga un objetivo y pueda atacarlo, pues que le empiece a bajar vida
	void Attack()
	{
		if (target != null)
		{
			if (stats.CurrAttackDelay >= stats.AttackDelay)
			{
				Component damageable = target.GetComponent(typeof(IDamageable));

				if (damageable)
				{
					animator.SetBool("isPunching", false);
					Audios.loop = false;

					if (hitTargets.Contains(target))
					{
						if (GameFunctions.CanAttack(gameObject.tag, target.tag, damageable, stats))
						{
							animator.SetBool("isPunching", true);
							Audios.loop = true;
							Audios.PlayOneShot(AuAttack);
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

	void IDamageable.TakeDamage(float amount)
	{
		stats.CurrHealth -= amount;
	}
}
