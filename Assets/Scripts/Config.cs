using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public float cannonBallFiringVelocity = 200f;
    public int cannonBallDamage = 10;

    public float cannonFireDelay = 1f;

    public float enemyFireRate = 2.0f;

    public int enemyHealth = 100;
    public float enemyAccelSpeed = 30f;
    public float enemyFollowRange = 15f;
    public float enemyMinDistanceToPlayer = 2f;
    public int enemyCollisionDamage = 15;

    public int playerHealth = 100;
    public float playerTurnSpeed = 7f;
    public float playerAccelSpeed = 50f;
    public float playerDefaultDrag = 0.75f;
    public float playerAnchorDrag = 50f;
    public float playerAnchorTurnSpeed = 8f;
    public int playerCollisionDamage = 1;
}
