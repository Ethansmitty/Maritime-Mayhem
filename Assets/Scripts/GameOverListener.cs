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
    public Boat Player;

    void Update()
    {
        PointsText.text = string.Format("Points: {0}", Player.points);
        GoldText.text = string.Format("Gold: {0}", Player.gold);
        if (Player.health <= 0)
        {
            GameOverText.enabled = true;
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("_scene_0");
            }
        }
    }
}
