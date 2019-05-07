using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour
{
    public Config Config;
    private GameObject Player;
    private int goldValue;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        this.goldValue = Random.Range(Config.enemyGoldMin, Config.enemyGoldMax);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<Boat>().gold += goldValue;
            Destroy(this.gameObject);
        }
    }
}
