using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingButton : MonoBehaviour
{
    public void OpenBuildingScene()
    {
        string name = GameManager.instance.GetPlayerName();       
        if(name != "NAME" && name != null)
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            GameManager.instance.SetAuthFromTheoryState(true);
            SceneManager.LoadScene("Authorization");
        }
    }
}
