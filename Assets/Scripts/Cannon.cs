using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Rigidbody CannonballPrefab;
    private Vector3 posOnScreen;
    private Vector3 mousePos;
    private Vector3 cannonRot = new Vector3(90f, 0f, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posOnScreen = Camera.main.WorldToViewportPoint(transform.position); // Pos of cannon on screen
        mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition); // Pos of mouse

        float angle = AngleBetweenTwoPoints(posOnScreen, mousePos);
        cannonRot.z = (angle + 90);
        transform.rotation = Quaternion.Euler(cannonRot);

        if (Input.GetMouseButtonDown(1))
        {
            Rigidbody cannonball = (Rigidbody)Instantiate(CannonballPrefab, transform.position, transform.rotation);

        }
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
