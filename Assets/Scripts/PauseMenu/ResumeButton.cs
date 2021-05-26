using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void ResumeGame()
    {
        var scriptPauseMenu = pauseMenu.GetComponent<PauseMenu>();
        scriptPauseMenu.paused = false;
    }
}
