using System.IO;
using System.Data;
using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Authorization : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI loginText;
    [SerializeField] TextMeshProUGUI passwordText;
    [SerializeField] GameObject manager;
    [SerializeField] GameObject attention;
    DataBase db;
    string query;
    string UserId;
    string temp;
    string playerName;
    string password;
    bool firstPlayer = false;    
    int id;
    void Start()
    {
        db = manager.GetComponent<DataBase>();
        id = GetMaxId();
        temp = db.ExecuteQueryWithAnswer("select name from Player where id = @id", "id", id.ToString());
        if (temp != null)
        {
            firstPlayer = true;
        }
    }
    void Update()
    {

    }
    private bool NotEmptyAuthDataChecker(string playerName, string password)
    {
        if (string.IsNullOrEmpty(playerName) || string.IsNullOrEmpty(password))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private bool CanRegistre(string playerName, string password)
    {
        bool result;
        if (UniqueName(playerName) && NotEmptyAuthDataChecker(playerName, password))
        {
            result = true;
        }
        else
        {
            result = false;
        }       
        if(!NotEmptyAuthDataChecker(playerName, password))
        {
            GameManager.instance.SetEmptyAuthDataState(true);            
        }
        else
        {
            GameManager.instance.SetEmptyAuthDataState(false);
        }
        if (UniqueName(playerName))
        {
            GameManager.instance.SetUniquePlayerState(true);
        }
        else
        {
            GameManager.instance.SetUniquePlayerState(false);
        }
        return result;
    }
    private bool CanAuth(string playerName, string password)
    {
        GameManager.instance.SetUniquePlayerState(true);

        bool result;
        if (NotEmptyAuthDataChecker(playerName, password))
        {
            result = true;
        }
        else
        {
            result = false;
        }
        if (NotEmptyAuthDataChecker(playerName, password))
        {
            GameManager.instance.SetEmptyAuthDataState(false);
        }
        else
        {
            GameManager.instance.SetEmptyAuthDataState(true);
        }
        return result;
    }
    int GetMaxId()
    {
        string tempId;
        int id;
        query = "select id from Player order by id desc";
        tempId = db.ExecuteQueryWithAnswer(query);
        if (tempId == null)
        {
            id = 0;
        }
        else id = int.Parse(tempId);
        return id;
    }
    public void RegistrationButton()
    {
        id = GetMaxId();
        if (id > 0 || firstPlayer)
        {
            id++;
        }
        playerName = loginText.text;
        password = passwordText.text;
        if (CanRegistre(playerName, password))
        {            
            query = "insert into Player values (@id, @name, @password)";
            db.ExecuteQueryWithoutAnswer(query, "id", "name", "password", id.ToString(), playerName, password);
        }
        else
        {
            if (!GameManager.instance.attentionInstantieted)
            {
                GameObject canvas = GameObject.Find("Canvas");
                Instantiate(attention, canvas.transform);
                GameManager.instance.attentionInstantieted = true;
            }
        }
    }
    public void AuthorizationButton()
    {
        playerName = loginText.text;
        password = passwordText.text;
        query = "select id from Player where name=@name and password=@password";
        UserId = db.ExecuteQueryWithAnswer(query, "name", "password", playerName, password);
        if (CanAuth(playerName, password))
        {
            if(UserId != null)
            {
                GameManager.instance.SetUserID(UserId);
                GameManager.instance.SetUserName(playerName);
                if (GameManager.instance.GetAuthState())
                {
                    SceneManager.LoadScene("MainScene");
                }
                else
                {
                    SceneManager.LoadScene("Motherboard");
                }
            }
        }
        else
        {
            if (!GameManager.instance.attentionInstantieted)
            {
                GameObject canvas = GameObject.Find("Canvas");
                Instantiate(attention, canvas.transform);
                GameManager.instance.attentionInstantieted = true;
            }
        }
    }
    private bool UniqueName(string playerName)
    {
        string id;
        string query = "select id from Player where name = @name";
        id = db.ExecuteQueryWithAnswer(query, "name", playerName);
        if (id != null) return false;
        else return true;
    }
}
