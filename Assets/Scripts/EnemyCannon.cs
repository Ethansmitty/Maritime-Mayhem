using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : MonoBehaviour
{
    public Rigidbody CannonballPrefab;
    private float fireRate = 2.0f;
    private Transform target;
    private Vector3 posOnScreen, targetPosOnScreen;
    private Vector3 cannonRot = new Vector3(90f, 0f, 0);

    // Start is called before the first frame update
    void Start()
    {
        fireRate = GameObject.FindGameObjectWithTag("Config").GetComponent<Config>().enemyFireRate;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("FireCannon", fireRate, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            posOnScreen = Camera.main.WorldToScreenPoint(transform.position); // Pos of cannon on screen
            targetPosOnScreen = Camera.main.WorldToScreenPoint(target.position); // Pos of target on screen
            float angle = AngleBetweenTwoPoints(posOnScreen, targetPosOnScreen);
            cannonRot.z = (angle + 90);
            transform.rotation = Quaternion.Euler(cannonRot);
        }


    }

    private void FireCannon()
    {
        Vector3 direction = target.position - transform.position;
        float magnitude = direction.magnitude;

        if (magnitude <= GameObject.FindGameObjectWithTag("Config").GetComponent<Config>().enemyFollowRange)
        {
            Rigidbody cannonball = (Rigidbody)Instantiate(CannonballPrefab, transform.position, transform.rotation);
        }
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
