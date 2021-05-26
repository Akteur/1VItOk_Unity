using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsManager : MonoBehaviour
{
    [SerializeField] GameObject buildStartedObject;
    [SerializeField] GameObject processorInstalledObject;
    [SerializeField] GameObject videocardInstalledObject;
    [SerializeField] GameObject ramInstalledObject;

    public static AchievementsManager instance = null;
    private static bool buildStartedAchievement;
    private static bool processorInstalledAchievement;
    private static bool videocardInstalledAchievement;
    private static bool ramInstalledAchievement;
    private void Awake()
    {
        BuildStarted(false);
        ProcessorInstalled(false);
        VideocardInstalled(false);
        RamInstalled(false);
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void BuildStarted(bool state)
    {
        buildStartedAchievement = state;
        if (state) buildStartedObject.GetComponent<AchievementEarned>().AchievementEarn(true);
    }
    public void ProcessorInstalled(bool state)
    {
        processorInstalledAchievement = state;
        if (state) processorInstalledObject.GetComponent<AchievementEarned>().AchievementEarn(true);
    }
    public void VideocardInstalled(bool state)
    {
        videocardInstalledAchievement = state;
        if (state) videocardInstalledObject.GetComponent<AchievementEarned>().AchievementEarn(true);
    }
    public void RamInstalled(bool state)
    {
        ramInstalledAchievement = state;
        if (state) ramInstalledObject.GetComponent<AchievementEarned>().AchievementEarn(true);
    }
    public bool GetBuildStartedAchievement()
    {
        return buildStartedAchievement;
    }
    public bool GetProcessorInstalledAchievement()
    {
        return processorInstalledAchievement;
    }
    public bool GetVideocardInstalledAchievement()
    {
        return videocardInstalledAchievement;
    }
    public bool GetRamInstalledAchievement()
    {
        return ramInstalledAchievement;
    }

}
