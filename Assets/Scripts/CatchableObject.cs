using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchableObject : MonoBehaviour
{
    private Rigidbody rgbd;

    void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
    }

    public void Take(bool isTaked)
    {
        if (isTaked)
            rgbd.constraints = RigidbodyConstraints.FreezeAll;
        else
            rgbd.constraints = RigidbodyConstraints.None;
    }

    private void OnCollisionEnter(Collision collision)
    {
        transform.parent = null;
        rgbd.constraints = RigidbodyConstraints.None;
    }

    void Update()
    {
        
    }
}
