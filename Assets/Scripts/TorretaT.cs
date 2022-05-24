using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaT : MonoBehaviour
{
    public Transform targ;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private BaseStats stats;

    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }

    public BaseStats Stats
    {
        get { return stats; }
    }


    void Start()
    {
        
        List<GameObject> objects = GameManager.Instance.Objects;
        objects = GameManager.GetAllEnemies(transform.position, objects, gameObject.tag);
        target = GameFunctions.GetNearestTarget(objects, stats.DetectionObject, gameObject.tag);
        targ = target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.LookAt(targ);
        
    }
}
