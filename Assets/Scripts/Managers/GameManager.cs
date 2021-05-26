using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private string id;
    private string playerName;
    private bool authFromTheory;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;        
        }    
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public string GetUserID()
    {
        return id;
    }
    public string GetUserName()
    {
        return playerName;
    }
    public void SetUserID(string id)
    {
        this.id = id;
    }
    public void SetUserName(string name)
    {
        this.playerName = name;
    }
    public bool GetAuthState()
    {
        return authFromTheory;
    }
    public void SetAuthFromTheoryState(bool state)
    {
        authFromTheory = state;
    }
}
