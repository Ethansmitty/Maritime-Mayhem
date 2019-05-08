using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverListener : MonoBehaviour
{
    public Text GameOverText;
    public GameObject Player;


    void LateUpdate()
    {
        if (Player == null)
        {
            GameOverText.enabled = true;
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("_scene_0");
            }
        }
    }
}
