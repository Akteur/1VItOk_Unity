using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] GameObject videocard;
    [SerializeField] GameObject processor;
    [SerializeField] GameObject ram;
    [SerializeField] GameObject player;
    [SerializeField] GameObject timer;
    [SerializeField] TextMeshProUGUI minutes;
    [SerializeField] TextMeshProUGUI seconds;
    [SerializeField] GameObject attention;
    TimerScript timerScript;

    public Vector3 playerPos;
    public Vector3 ramPos;
    public Vector3 processorPos;
    public Vector3 videocardPos;

    public Quaternion videocardRot;
    public Quaternion processorRot;
    public Quaternion ramRot;

    public bool buildStarted;
    public bool processorInstalled;
    public bool videocardInstalled;
    public bool ramInstalled;

    public string playerName;
    public float buildTime;
    private void Start()
    {
        timer = GameObject.Find("Timer");
        timerScript = timer.GetComponent<TimerScript>();
        if (GameManager.instance.GetPlayerName() != null)
        {
            playerName = GameManager.instance.GetPlayerName();
        }
        else
        {
            playerName = null;
        }
    }
    public void Load()
    {
        if (GameManager.instance.GetPlayerName() == null)
        {
            if (!GameManager.instance.attentionInstantieted)
            {
                GameObject canvas = GameObject.Find("Canvas");
                GameManager.instance.authScene = false;
                GameManager.instance.mainScene = true;
                Instantiate(attention, canvas.transform);
                GameManager.instance.attentionInstantieted = true;
            }
        }
        else
        {
            SaveData data = SaveSystem.Load();
            playerPos.x = data.playerPosition[0];
            playerPos.y = data.playerPosition[1];
            playerPos.z = data.playerPosition[2];
            player.transform.position = playerPos;

            processorPos.x = data.processorPosition[0];
            processorPos.y = data.processorPosition[1];
            processorPos.z = data.processorPosition[2];
            processor.transform.position = processorPos;
            processorRot.x = data.processorRotation[0];
            processorRot.y = data.processorRotation[1];
            processorRot.z = data.processorRotation[2];
            processor.transform.rotation = Quaternion.Euler(processorRot.x, processorRot.y, processorRot.z);

            videocardPos.x = data.videocardPosition[0];
            videocardPos.y = data.videocardPosition[1];
            videocardPos.z = data.videocardPosition[2];
            videocard.transform.position = videocardPos;
            videocardRot.x = data.videocardRotation[0];
            videocardRot.y = data.videocardRotation[1];
            videocardRot.z = data.videocardRotation[2];
            videocard.transform.rotation = Quaternion.Euler(videocardRot.x, videocardRot.y, videocardRot.z); 

            ramPos.x = data.ramPosition[0];
            ramPos.y = data.ramPosition[1];
            ramPos.z = data.ramPosition[2];
            ram.transform.position = ramPos;
            ramRot.x = data.ramRotation[0];
            ramRot.y = data.ramRotation[1];
            ramRot.z = data.ramRotation[2];
            ram.transform.rotation = Quaternion.Euler(ramRot.x, ramRot.y, ramRot.z);
        
            timerScript.TimerTextUpdate(minutes, seconds, data.buildTime);

            AchievementsManager.instance.BuildStarted(data.buildStarted);
            AchievementsManager.instance.VideocardInstalled(data.videocardInstalled);
            AchievementsManager.instance.ProcessorInstalled(data.processorInstalled);
            AchievementsManager.instance.RamInstalled(data.ramInstalled);
        }
    }
    public void Save()
    {
        if(GameManager.instance.GetPlayerName() == null)
        {
            if (!GameManager.instance.attentionInstantieted && !GameManager.instance.autoSave)
            {
                GameObject canvas = GameObject.Find("Canvas");
                GameManager.instance.authScene = false;
                GameManager.instance.mainScene = true;
                Instantiate(attention, canvas.transform);
                GameManager.instance.attentionInstantieted = true;
            }
        }
        else
        {
            playerPos.x = player.transform.position.x;
            playerPos.y = player.transform.position.y;
            playerPos.z = player.transform.position.z;

            processorPos.x = processor.transform.position.x; 
            processorPos.y = processor.transform.position.y; 
            processorPos.z = processor.transform.position.z;
            processorRot.x = processor.transform.rotation.eulerAngles.x;
            processorRot.y = processor.transform.rotation.eulerAngles.y;
            processorRot.z = processor.transform.rotation.eulerAngles.z;

            videocardPos.x = videocard.transform.position.x;
            videocardPos.y = videocard.transform.position.y;
            videocardPos.z = videocard.transform.position.z;
            videocardRot.x = videocard.transform.rotation.eulerAngles.x;
            videocardRot.y = videocard.transform.rotation.eulerAngles.y;
            videocardRot.z = videocard.transform.rotation.eulerAngles.z;

            ramPos.x = ram.transform.position.x;
            ramPos.y = ram.transform.position.y;
            ramPos.z = ram.transform.position.z;
            ramRot.x = ram.transform.rotation.eulerAngles.x;
            ramRot.y = ram.transform.rotation.eulerAngles.y;
            ramRot.z = ram.transform.rotation.eulerAngles.z;

            buildStarted = AchievementsManager.instance.GetBuildStartedAchievement();
            processorInstalled = AchievementsManager.instance.GetProcessorInstalledAchievement();
            videocardInstalled = AchievementsManager.instance.GetVideocardInstalledAchievement();
            ramInstalled = AchievementsManager.instance.GetRamInstalledAchievement();
        
            buildTime = timerScript.timePassed;

            SaveSystem.Save(this);
        }
    }
}