﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseListenerScript : MonoBehaviour
{
    public static bool Paused = false;
    public Text PauseText;
    public Text ControlText;
    public Button ExitButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Time.timeScale = 1;
            } else
            {
                Time.timeScale = 0;
            }

            Paused = !Paused;
            PauseText.enabled = Paused;
            ControlText.enabled = Paused;
            ExitButton.GetComponent<Image>().enabled = Paused;
            ExitButton.GetComponentInChildren<Text>().enabled = Paused;
        }
    }
}
