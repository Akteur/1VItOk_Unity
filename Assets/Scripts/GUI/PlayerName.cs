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
        string name = GameManager.instance.GetPlayerName();
        if (name == null)
        {
            playerName.text = "NAME";
        }
        else
        {
            playerName.text = GameManager.instance.GetPlayerName();
        }
    }
}