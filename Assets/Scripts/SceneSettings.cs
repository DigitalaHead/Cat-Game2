using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneSettings : MonoBehaviour
{
    public GameObject PausePanel;

    public void PauseButtonPressed()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinueButtonPressed()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ExitButtonPressed()
    {
        Application.Quit();
    }
}
