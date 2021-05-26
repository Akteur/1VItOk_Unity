using UnityEngine;

public class MbResumeButton : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void ResumeGame()
    {
        var scriptPauseMenu = pauseMenu.GetComponent<MotherboardPauseMenu>();
        scriptPauseMenu.paused = false;
    }
}
