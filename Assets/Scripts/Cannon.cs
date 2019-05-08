using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Config Config;

    public Rigidbody CannonballPrefab;
    private float fireDelay;
    private bool canFire = true;
    private Vector3 posOnScreen;
    private Vector3 mousePos;
    private Vector3 cannonRot = new Vector3(90f, 0f, 0);

    private void Start()
    {
        fireDelay = Config.cannonFireDelay;
    }

    void Update()
    {
        if (!PauseListenerScript.Paused)
        {
            posOnScreen = Camera.main.WorldToScreenPoint(transform.position); // Pos of cannon on screen
            mousePos = Input.mousePosition; // Pos of mouse

            float angle = AngleBetweenTwoPoints(posOnScreen, mousePos);
            cannonRot.z = (angle + 90);
            transform.rotation = Quaternion.Euler(cannonRot);
        }
    }

    public void FireCannon()
    {
        if (canFire)
        {
            Rigidbody cannonball = (Rigidbody)Instantiate(CannonballPrefab, transform.position, transform.rotation);
            canFire = false;
            Invoke("ResetCannonTimer", fireDelay);
        }
    }

    private void ResetCannonTimer()
    {
        canFire = true;
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
