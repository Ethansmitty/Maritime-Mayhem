using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public Config Config;

    private float firingVelocity;
    private int damage;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        firingVelocity = Config.cannonBallFiringVelocity;
        damage = Config.cannonBallDamage;
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

    private void AddVelocity(Vector3 newVelocity)
    {
        rb = GetComponent<Rigidbody>();
        this.rb.AddForce(-(newVelocity * firingVelocity));
    }
}
