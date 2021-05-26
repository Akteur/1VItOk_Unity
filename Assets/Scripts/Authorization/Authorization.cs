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
    DataBase db;
    string query;
    string UserId;
    string temp;
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
        string name = loginText.text;
        string password = passwordText.text;
        query = "insert into Player values (@id, @name, @password)";
        db.ExecuteQueryWithoutAnswer(query, "id", "name", "password", id.ToString(), name, password);
    }
    public void AuthorizationButton()
    {
        string name = loginText.text;
        string password = passwordText.text;
        query = "select id from Player where name=@name and password=@password";
        UserId = db.ExecuteQueryWithAnswer(query, "name", "password", name, password);
        if(UserId != null)
        {
            GameManager.instance.SetUserID(UserId);
            GameManager.instance.SetUserName(name);
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
    private bool UniqueName(string name)
    {
        string id;
        string query = "select id from Player where name = @name";
        id = db.ExecuteQueryWithAnswer(query, "name", name);
        if (id != null) return false;
        else return true;
    }
}
