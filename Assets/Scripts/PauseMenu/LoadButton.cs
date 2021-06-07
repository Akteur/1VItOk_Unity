using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour
{
    [SerializeField] GameObject videocard;
    [SerializeField] GameObject processor;
    [SerializeField] GameObject ram;
    [SerializeField] GameObject player;
    [SerializeField] GameObject timerGO;
    PlayerData playerData;
    TimerScript timer;
    public void Load()
    {
        timer = timerGO.GetComponent<TimerScript>();
        SaveData data = SaveSystem.Load();
        player.transform.position = playerData.playerPos;

        processor.transform.position = playerData.processorPos;
        processor.transform.rotation = playerData.processorRot;

        videocard.transform.position = playerData.videocardPos;
        videocard.transform.rotation = playerData.videocardRot;

        ram.transform.position = playerData.ramPos;
        ram.transform.rotation = playerData.ramRot;

        timer.timePassed = playerData.buildTime;
    }
}
