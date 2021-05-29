using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private string id;
    private string playerName;
    private bool authFromTheory;
    private bool uniquePlayer;
    private bool emptyAuthData;
    public bool attentionInstantieted;
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
    public bool GetUniquePlayerState()
    {
        return uniquePlayer;
    }
    public string GetUserID()
    {
        return id;
    }
    public string GetUserName()
    {
        return playerName;
    }
    public bool GetAuthState()
    {
        return authFromTheory;
    }
    public bool GetEmptyAuthDataState()
    {
        return emptyAuthData;
    }

    public void SetEmptyAuthDataState(bool state)
    {
        emptyAuthData = state;
    }
    public void SetUniquePlayerState(bool state)
    {
        uniquePlayer = state;
    }
    public void SetUserID(string id)
    {
        this.id = id;
    }
    public void SetUserName(string name)
    {
        this.playerName = name;
    }
    public void SetAuthFromTheoryState(bool state)
    {
        authFromTheory = state;
    }
}
