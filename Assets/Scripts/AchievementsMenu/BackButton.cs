using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] GameObject achievementsMenuObject;
    [SerializeField] GameObject pauseMenuObject;
    public void GoBack()
    {
        PauseMenu.instance.achievementsOpened = false;
        PauseMenu.instance.canPause = true;
        pauseMenuObject.SetActive(true);
        achievementsMenuObject.SetActive(false);
    }
}
