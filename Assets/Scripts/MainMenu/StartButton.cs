using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.instance.SetAuthFromTheoryState(false);
        SceneManager.LoadScene("Motherboard");
    }
}
