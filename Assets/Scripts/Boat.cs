using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boat : MonoBehaviour
{
    private int health;
    private float turnSpeed;
    private float accelSpeed;
    private float defaultDrag;
    private float anchorDrag;
    private int collisionDamage;

    public TextMesh healthTextPrefab;

    private TextMesh healthText;
    private bool isAnchored = false;
    private Rigidbody rb;
    private GameObject anchor;
    private GameObject cannon;
    private Vector3 anchorPos;

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Config").GetComponent<Config>().playerHealth;
        turnSpeed = GameObject.FindGameObjectWithTag("Config").GetComponent<Config>().playerTurnSpeed;
        accelSpeed = GameObject.FindGameObjectWithTag("Config").GetComponent<Config>().playerAccelSpeed;
        defaultDrag = GameObject.FindGameObjectWithTag("Config").GetComponent<Config>().playerDefaultDrag;
        anchorDrag = GameObject.FindGameObjectWithTag("Config").GetComponent<Config>().playerAnchorDrag;
        collisionDamage = GameObject.FindGameObjectWithTag("Config").GetComponent<Config>().playerCollisionDamage;

        rb = GetComponent<Rigidbody>();
        anchor = GameObject.FindGameObjectWithTag("Anchor");
        cannon = this.transform.GetChild(0).gameObject;
        healthText = Instantiate(healthTextPrefab);
        healthText.GetComponent<HealthFollow>().followTarget = this.gameObject.transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Anchor the ship when Space is pressed
        {
            anchorPos = anchor.transform.position;

            if (isAnchored)
            {
                isAnchored = false;
                anchorPos.y += 15;
                rb.drag = defaultDrag;
            }
            else
            {
                isAnchored = true;
                anchorPos.y -= 15;
                rb.drag = anchorDrag;
            }
            anchor.transform.position = anchorPos; //Move anchor sprite
        }

        if (Input.GetMouseButtonDown(1))
        {
            cannon.SendMessage("FireCannon");
        }

        
        healthText.text = string.Format("Health: {0}%", this.health);
        if (health <=0)
        {
            Destroy(healthText.gameObject);
            Destroy(this.gameObject);
        }

    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rb.AddTorque(0f, h * this.turnSpeed, 0f);
        Vector3 speed = this.transform.up * (v * accelSpeed);
        rb.AddForce(speed);
    }

    private void OnCBHit(int damage)
    {
        this.health -= damage;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Boat"))
        {
            this.health -= collisionDamage;
        }
    }

}
