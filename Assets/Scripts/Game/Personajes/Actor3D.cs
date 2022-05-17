using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor3D : MonoBehaviour
{
    [SerializeField]
    GameObject followTarget;
    [SerializeField]
    Animator Anim;

    private void Awake()
    {
        //Anim = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        if (followTarget != null)
        {
            transform.localPosition = new Vector3(followTarget.transform.localPosition.x, followTarget.transform.localPosition.y, followTarget.transform.localPosition.z);
        }
    }
}
