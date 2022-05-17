using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BaseStats
{
	[SerializeField]
	private float currHealth;
	[SerializeField]
	private float maxHealth;
	[SerializeField]
	private float range;
	[SerializeField]
	private float baseDamage;
	[SerializeField]
	private float attackDelay;
	[SerializeField]
	private float currAttackDelay;
	[SerializeField]
	private float moveSpeed;
	[SerializeField]
	private Image healthBar;
	[SerializeField]
	private SphereCollider detectionObject;
	[SerializeField]
	private GameConstants.OBJECT_TYPE objectType;
	[SerializeField]
	private GameConstants.OBJECT_ATTACKABLE objectAttackable;


	public float CurrHealth
	{
		get { return currHealth; }
		set 
		{
			if (value <= 0)
				currHealth = 0;
			else if (value >= maxHealth)
				currHealth = maxHealth;
			else
				currHealth = value;
		}
	}
	public float MaxHealth
	{
		get { return maxHealth; }
	}
	public float ParectHealth
	{
		get { return currHealth / maxHealth; }
	}
	public float Range
	{
		get { return range; }
	}
	public float BaseDamage
	{
		get { return baseDamage; }
	}
	public float AttackDelay
	{
		get { return attackDelay; }
	}
	public float CurrAttackDelay
	{
		get { return currAttackDelay; }
		set { currAttackDelay = value; }
	}
	public float MoveSpeed
	{
		get { return moveSpeed; }
		set { moveSpeed = value; }
	}
	public Image HealthBar
	{
		get { return healthBar; }
	}
	public SphereCollider DetectionObject
	{
		get { return detectionObject; }
	}
	public GameConstants.OBJECT_TYPE ObjectType
	{
		get { return objectType; }
	}
	public GameConstants.OBJECT_ATTACKABLE ObjectAttackable
	{
		get { return objectAttackable; }
	}
	
	public void UpdateStats()
	{
		healthBar.fillAmount = ParectHealth;
		detectionObject.radius = range;
		if (currAttackDelay < attackDelay)
			currAttackDelay += Time.deltaTime;
	}
}
