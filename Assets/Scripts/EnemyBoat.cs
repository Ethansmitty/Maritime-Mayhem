using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoat : MonoBehaviour
{
    public Config Config;

    private int health;
    private float accelSpeed;
    private float followRange;
    private float minDistanceToPlayer;
    private int collisionDamage;
    public TextMesh healthTextPrefab;

    private TextMesh healthText;
    private Rigidbody rb;
    private Transform target;
    private Vector3 posOnScreen, targetPosOnScreen;

    // Start is called before the first frame update
    void Start()
    {
        health = Config.enemyHealth;
        accelSpeed = Config.enemyAccelSpeed;
        followRange = Config.enemyFollowRange;
        minDistanceToPlayer = Config.enemyMinDistanceToPlayer;
        collisionDamage = Config.enemyCollisionDamage;

        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();

        healthText = Instantiate(healthTextPrefab);
        healthText.GetComponent<HealthFollow>().followTarget = this.gameObject.transform;
    }

    void Update()
    {
        if (!PauseListenerScript.Paused)
        {
            this.transform.rotation = this.gameObject.transform.GetChild(0).transform.rotation;

            if (healthText != null)
            {
                healthText.text = string.Format("Health: {0}%", health);
            }
            if (health <= 0)
            {
                GameObject.FindGameObjectWithTag("MainCamera").SendMessage("AddPoints", 1);
                Destroy(healthText.gameObject);
                Destroy(this.gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        if (!PauseListenerScript.Paused)
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
