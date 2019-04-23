using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    private float firingVelocity;
    private int damage;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        firingVelocity = GameObject.FindGameObjectWithTag("Config").GetComponent<Config>().cannonBallFiringVelocity;
        damage = GameObject.FindGameObjectWithTag("Config").GetComponent<Config>().cannonBallDamage;
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
