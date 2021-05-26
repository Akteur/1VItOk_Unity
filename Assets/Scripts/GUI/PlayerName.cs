using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    [SerializeField] Text playerName;
    void Start()
    {
        SetPlayerName();
    }
    private void SetPlayerName()
    {
        string name = GameManager.instance.GetUserName();
        if (name == null)
        {
            playerName.text = "NAME";
        }
        else
        {
            playerName.text = GameManager.instance.GetUserName();
        }
    }
}