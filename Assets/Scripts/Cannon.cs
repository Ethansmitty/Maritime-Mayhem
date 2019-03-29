using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Rigidbody CannonballPrefab;
    public float fireDelay = 1f;
    private Vector3 posOnScreen;
    private Vector3 mousePos;
    private Vector3 cannonRot = new Vector3(90f, 0f, 0);


    // Update is called once per frame
    void Update()
    {
        posOnScreen = Camera.main.WorldToScreenPoint(transform.position); // Pos of cannon on screen
        mousePos = Input.mousePosition; // Pos of mouse

        float angle = AngleBetweenTwoPoints(posOnScreen, mousePos);
        cannonRot.z = (angle + 90);
        transform.rotation = Quaternion.Euler(cannonRot);
    }

    public void FireCannon()
    {
        Rigidbody cannonball = (Rigidbody)Instantiate(CannonballPrefab, transform.position, transform.rotation);

    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
