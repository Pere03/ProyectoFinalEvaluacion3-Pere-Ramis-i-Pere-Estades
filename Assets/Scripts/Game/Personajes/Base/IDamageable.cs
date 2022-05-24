using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    BaseStats Stats { get;  }
    List<GameObject> HitTargets { get; }
    GameObject Target { get; set; }

    void TakeDamage(float amount);

}
