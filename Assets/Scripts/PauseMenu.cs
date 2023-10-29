using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject PauseButton;
    public void OnPausePress()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
        PauseButton.SetActive(false);
    }
    public void OnResumePress()
    {
        Time.timeScale = 1.0f;
        PausePanel.SetActive(false);
        PauseButton.SetActive(true);
    }
}
