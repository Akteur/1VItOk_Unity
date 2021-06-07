using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildArea : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject workPlace;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject pauseManuObject;
    [SerializeField] GameObject buildStartedAchievement;
    [SerializeField] GameObject timer;
    [SerializeField] Transform window;
    GUIObjectName gui;
    MouseLook scriptMouseLook;
    PauseMenu pauseMenu;
    PCbuilding pcBuilding;
    AchievementEarned achievement;
    TimerScript timerScript;
    public bool inBuildArea = false;
    public bool canBuild = false;
    public bool buildStarted = false;
    private void Start()
    {
        timerScript = timer.GetComponent<TimerScript>();
        achievement = buildStartedAchievement.GetComponent<AchievementEarned>();
        gui = mainCamera.GetComponent<GUIObjectName>();
        scriptMouseLook = player.GetComponent<MouseLook>();
        pauseMenu = pauseManuObject.GetComponent<PauseMenu>();
        pcBuilding = mainCamera.GetComponent<PCbuilding>();
    }
    private void Update()
    {
        StartBuild();
        if (buildStarted)
        {
            MoveWindow(27.3f);
        }
        else
        {
            MoveWindow(26.3f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        string objectName = other.name;
        if (objectName == "Player" && !buildStarted)
        {
            canBuild = true;
            inBuildArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        string objectName = other.name;
        if (objectName == "Player")
        {
            canBuild = false;
            inBuildArea = false;
        }
    }
    IEnumerator CanPause()
    {
        yield return new WaitForSeconds(2f);
        pauseMenu.canPause = true;
    }
    private void StartBuild()
    {    
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canBuild && !buildStarted)
            {
                StopAllCoroutines();
                pcBuilding.buildHand.transform.localPosition = new Vector3(0, 0, 0.7f);
                float x = workPlace.transform.position.x;
                float y = workPlace.transform.position.y;
                float z = workPlace.transform.position.z;
                player.transform.position = new Vector3(x, y, z);
                scriptMouseLook.rotationX = 0;
                gui.canMove = false;
                gui.helpText = "Возьмите комплектующее";
                buildStarted = true;
                pauseMenu.canPause = false;
                achievement.AchievementEarn(true);
                timerScript.saveTime = false;
                timerScript.startTimer = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && buildStarted)
        {
            if (buildStarted)
            {
                buildStarted = false;
                gui.canMove = true;
                gui.buildAreaHelpPickup = false;
                StartCoroutine(CanPause());
                timerScript.saveTime = true;
                timerScript.startTimer = false;
            }
        }
    }
    private void MoveWindow(float y)
    {
        Vector3 target = new Vector3(window.position.x, y, window.position.z);
        window.position = Vector3.MoveTowards(window.transform.position, target, 0.05f);
    }
}
