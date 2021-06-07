using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float timePassed = 0f;
    [SerializeField] GameObject table;
    [SerializeField] public TextMeshProUGUI minutesText;
    [SerializeField] public TextMeshProUGUI secondsText;
    [SerializeField] GameObject manager;
    [SerializeField] GameObject player;
    DataBase dataBase;
    PlayerData playerData;
    int minutes = 0;
    int seconds = 0;
    public bool saveTime = false;
    public bool startTimer;
    void Start()
    {
        dataBase = manager.GetComponent<DataBase>();
        playerData = player.GetComponent<PlayerData>();
    }
    void Update()
    {
        TimerValueUpdate(timePassed);
        TimerTextUpdate(minutesText, secondsText, minutes, seconds);
    }
    private void TimerValueUpdate(float time)
    {
        if (startTimer)
        {
            timePassed += Time.deltaTime;
            minutes = (int)time / 60;
            seconds = (int)time % 60;
        }
        else if(saveTime)
        {
            SaveTime();
        }
    }
    public void TimerTextUpdate(TextMeshProUGUI minutesTMPro, TextMeshProUGUI secondsTMPro, int minutes, int seconds)
    {
        minutesTMPro.text = minutes >= 10 ? minutes.ToString() : "0" + minutes.ToString();
        secondsTMPro.text = seconds >= 10 ? seconds.ToString() : "0" + seconds.ToString();
    }
    public void TimerTextUpdate(TextMeshProUGUI minutesTMPro, TextMeshProUGUI secondsTMPro, float time)
    {
        int minutesValue = (int)time / 60;
        int secondsValue = (int)time % 60;
        minutesTMPro.text = minutesValue >= 10 ? minutesValue.ToString() : "0" + minutesValue.ToString();
        secondsTMPro.text = secondsValue >= 10 ? secondsValue.ToString() : "0" + secondsValue.ToString();
    }
    private void SaveTime()
    {
        string playerName = GameManager.instance.GetPlayerName();
        if (playerName != "NAME" || !string.IsNullOrEmpty(playerName))
        {
            string query;
            string timerId = GetTimerId();
            string playerId = GetPlayerID();
            if(timerId != null)
            {
                query = "update Building set " +
                    "playerId = @playerId, minutes = @minutes, seconds = @seconds where Id = @id";
            }
            else
            {
                timerId = GetMaxTimerId().ToString();
                query = "insert into Building values (@id, @playerId, @minutes, @seconds)";
            }
            if(playerId != null)
            {
                dataBase.ExecuteQueryWithoutAnswer(query, "id", "playerId", "minutes", "seconds",
                    timerId, playerId.ToString(), minutes.ToString(), seconds.ToString());
            }
            saveTime = false;
            playerData.Save();
        }
    }
    private string GetPlayerID()
    {
        string result = null;
        string playerName = GameManager.instance.GetPlayerName();
        if(playerName != null)
        {
            string query = "select id from Player where name = @name";
            result = dataBase.ExecuteQueryWithAnswer(query, "name", playerName);
        }
        return result;
    }
    private string GetTimerId()
    {
        string result = null;
        string playerId = GetPlayerID();
        if(playerId != null)
        {
            string query = "select id from Building where PlayerId = @playerId";
            result = dataBase.ExecuteQueryWithAnswer(query, "playerId", playerId);
        }
        return result;
    }
    private int GetMaxTimerId()
    {
        string query;
        string tempId;
        int id;
        query = "select Id from Building order by Id desc";
        tempId = dataBase.ExecuteQueryWithAnswer(query);
        if (tempId == null)
        {
            id = 0;
        }
        else id = int.Parse(tempId);
        return id;
    }
}