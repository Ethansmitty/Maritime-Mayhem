﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public float firingVelocity = 1f;
    public int damage = 10;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 forceDirection = this.transform.up * firingVelocity;
        rb.AddForce(forceDirection);
        Destroy(this.gameObject, 10);
    }

    private void OnCollisionEnter(Collision col)
    {
        col.gameObject.SendMessage("OnCBHit", damage);
        Destroy(this.gameObject);
    }
}
