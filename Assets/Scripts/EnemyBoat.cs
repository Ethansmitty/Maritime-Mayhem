using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoat : MonoBehaviour
{
    public int health = 100;
    public float accelSpeed = 1f;
    public float followRange = 10f;
    public float minDistanceToPlayer = 1f;
    public int collisionDamage = 15;
    public TextMesh healthTextPrefab;

    private TextMesh healthText;
    private Rigidbody rb;
    private Transform target;
    private Vector3 posOnScreen, targetPosOnScreen;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();

        healthText = Instantiate(healthTextPrefab);
        healthText.GetComponent<HealthFollow>().followTarget = this.gameObject.transform;
    }

    void Update()
    {
        this.transform.rotation = this.gameObject.transform.GetChild(0).transform.rotation;

        healthText.text = string.Format("Health: {0}%", health);
        if (health <= 0)
        {
            Destroy(healthText.gameObject);
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            //Calculate player's position
            Vector3 direction = target.position - transform.position;
            float magnitude = direction.magnitude;
            direction.Normalize();

            //Calculate enemy's speed
            Vector3 velocity = direction * accelSpeed;

            if (magnitude > (minDistanceToPlayer + 0.5) && magnitude < followRange)
            {
                //Move the enemy
                rb.AddForce(new Vector3(velocity.x, rb.velocity.y, velocity.z));
            }
            else if (magnitude < minDistanceToPlayer)
            {
                rb.AddForce(new Vector3(-velocity.x, rb.velocity.y, -velocity.z));
            }
        }
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
