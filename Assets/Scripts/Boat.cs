using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public int health = 100;
    public float turnSpeed = 1f;
    public float accelSpeed = 1f;
    public float defaultDrag = 0.75f;
    public float anchorDrag = 50f;
    private bool isAnchored = false;
    private Rigidbody rb;
    private GameObject anchor;
    private Vector3 anchorPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anchor = GameObject.FindGameObjectWithTag("Anchor");      
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Anchor the ship when Space is pressed
        {
            anchorPos = anchor.transform.position;

            if (isAnchored)
            {
                isAnchored = false;
                anchorPos.z--;
                rb.drag = defaultDrag;
            }
            else
            {
                isAnchored = true;
                anchorPos.z++;
                rb.drag = anchorDrag;
            }
            anchor.transform.position = anchorPos; //Move anchor sprite
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
