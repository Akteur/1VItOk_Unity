[System.Serializable]
public class SaveData
{
    public float[] playerPosition;
    public float[] processorPosition;
    public float[] videocardPosition;
    public float[] ramPosition;

    public float[] processorRotation;
    public float[] videocardRotation;
    public float[] ramRotation;

    public bool buildStarted;
    public bool processorInstalled;
    public bool videocardInstalled;
    public bool ramInstalled;

    public float buildTime;

    public SaveData(PlayerData playerData)
    {
        buildStarted = playerData.buildStarted;
        processorInstalled = playerData.processorInstalled;
        videocardInstalled = playerData.videocardInstalled;
        ramInstalled = playerData.ramInstalled;

        playerPosition = new float[3];
        playerPosition[0] = playerData.playerPos.x;
        playerPosition[1] = playerData.playerPos.y;
        playerPosition[2] = playerData.playerPos.z;

        processorPosition = new float[3];
        processorPosition[0] = playerData.processorPos.x;
        processorPosition[1] = playerData.processorPos.y;
        processorPosition[2] = playerData.processorPos.z;

        videocardPosition = new float[3];
        videocardPosition[0] = playerData.videocardPos.x;
        videocardPosition[1] = playerData.videocardPos.y;
        videocardPosition[2] = playerData.videocardPos.z;

        ramPosition = new float[3];
        ramPosition[0] = playerData.ramPos.x;
        ramPosition[1] = playerData.ramPos.y;
        ramPosition[2] = playerData.ramPos.z;

        processorRotation = new float[3];
        processorRotation[0] = playerData.processorRot.x;
        processorRotation[1] = playerData.processorRot.y;
        processorRotation[2] = playerData.processorRot.z;

        videocardRotation = new float[3];
        videocardRotation[0] = playerData.videocardRot.x;
        videocardRotation[1] = playerData.videocardRot.y;
        videocardRotation[2] = playerData.videocardRot.z;

        ramRotation = new float[3];
        ramRotation[0] = playerData.ramRot.x;
        ramRotation[1] = playerData.ramRot.y;
        ramRotation[2] = playerData.ramRot.z;

        buildTime = playerData.buildTime;
    }
}
