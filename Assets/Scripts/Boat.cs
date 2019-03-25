using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public float turnSpeed = 1f;
    public float accelSpeed = 1f;
    public float defaultDrag = 0.75f;
    public float anchorDrag = 50f;
    private bool isAnchored = false;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isAnchored)
            {
                isAnchored = false;
                rb.drag = defaultDrag;
            }
            else
            {
                isAnchored = true;
                rb.drag = anchorDrag;
            }
        }
    }


    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rb.AddTorque(0f, h * turnSpeed, 0f);
        Vector3 speed = this.transform.up * (v * accelSpeed);
        rb.AddForce(speed);
    }
}
