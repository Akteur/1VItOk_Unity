using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsButton : MonoBehaviour
{
    [SerializeField] GameObject achievementsMenuObject;    
    [SerializeField] GameObject pauseMenu;    
    public void ShowAchievementsMenu()
    {
        PauseMenu.instance.achievementsOpened = true;
        achievementsMenuObject.SetActive(true);
    }
}
