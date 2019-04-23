using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public float cannonBallFiringVelocity = 1f;
    public int cannonBallDamage = 10;

    public float cannonFireDelay = 1f;

    public float enemyFireRate = 2.0f;

    public int enemyHealth = 100;
    public float enemyAccelSpeed = 10f;
    public float enemyFollowRange = 10f;
    public float enemyMinDistanceToPlayer = 1.5f;
    public int enemyCollisionDamage = 15;

    public int playerHealth = 100;
    public float playerTurnSpeed = 1f;
    public float playerAccelSpeed = 1f;
    public float playerDefaultDrag = 0.75f;
    public float playerAnchorDrag = 50f;
    public int playerCollisionDamage = 15;
}
