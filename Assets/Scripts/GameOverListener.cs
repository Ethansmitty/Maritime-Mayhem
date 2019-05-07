using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverListener : MonoBehaviour
{
    public Text GameOverText;
    public Text PointsText;
    public Text GoldText;
    public GameObject Player;
    private int playerPoints = 0;
    private int playerGold;

    void Update()
    {
        PointsText.text = string.Format("Points: {0}", this.playerPoints);
        if (Player == null)
        {
            GameOverText.enabled = true;
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("_scene_0");
            }
        }
    }

    private void AddPoints(int points)
    {
        this.playerPoints += points;
    }
}
