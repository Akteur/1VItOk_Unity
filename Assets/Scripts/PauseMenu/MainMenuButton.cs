using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void MainMenuExit()
    {        
        SceneManager.LoadScene("MainMenu");
    }
}
