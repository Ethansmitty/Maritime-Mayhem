using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public static float cannonBallFiringVelocity = 200f;
    public static int cannonBallDamage = 10;

    public static float cannonFireDelay = 1f;

    public static float enemyFireRate = 2.0f;

    public static int enemyHealth = 100;
    public static float enemyAccelSpeed = 30f;
    public static float enemyFollowRange = 15f;
    public static float enemyMinDistanceToPlayer = 2f;
    public static int enemyCollisionDamage = 15;

    public static int playerHealth = 100;
    public static float playerTurnSpeed = 7f;
    public static float playerAccelSpeed = 50f;
    public static float playerDefaultDrag = 0.75f;
    public static float playerAnchorDrag = 50f;
    public static int playerCollisionDamage = 1;
}
