using UnityEngine;

public class manualSaving : MonoBehaviour
{
    public void IsManualSaving()
    {
        GameManager.instance.autoSave = false;
    }
}
