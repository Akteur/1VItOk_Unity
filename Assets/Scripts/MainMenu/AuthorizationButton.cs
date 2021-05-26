using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthorizationButton : MonoBehaviour
{
    public void Authorization()
    {
        GameManager.instance.SetAuthFromTheoryState(false);
        SceneManager.LoadScene("Authorization");
    }
}
