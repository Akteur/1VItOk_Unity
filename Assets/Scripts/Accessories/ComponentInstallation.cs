using UnityEngine;

public class ComponentInstallation : MonoBehaviour
{
    [SerializeField] GameObject componentObject;
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject buildHand;
    PCbuilding pcBuilding;
    GUIObjectName gui;
    private string componentName;
    public bool componentInstalled = false;
    void Start()
    {
        componentInstalled = false;
        pcBuilding = mainCamera.GetComponent<PCbuilding>();
        gui = mainCamera.GetComponent<GUIObjectName>();
        componentName = componentObject.name + "MBplace";
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (componentObject.name)
        {
            case "Videocard":
                {
                    if (other.gameObject.name != componentName) break;
                    InstallComponent(other.gameObject, 90, 0, 180, "Видеокарта установлена!");
                    AchievementsManager.instance.VideocardInstalled(true);
                    break;
                }
            case "Processor":
                {
                    if (other.gameObject.name != componentName) break;
                    InstallComponent(other.gameObject, 0, 180, 0, "Процессор установлен!");
                    AchievementsManager.instance.ProcessorInstalled(true);
                    break;
                }
            case "RAM":
                {
                    if (!other.gameObject.GetComponent<SlotEmptyState>().slotEmpty) break;
                    InstallComponent(other.gameObject, 0, 90, -90, "ОЗУ установлена!");
                    AchievementsManager.instance.RamInstalled(true);
                    break;
                }
        }
    }
    private void InstallComponent(GameObject other, float x, float y, float z, string achievement)
    {
        componentObject.transform.position = other.transform.position;
        componentObject.GetComponent<Rigidbody>().isKinematic = true;
        gui.achievementVisibility = true;
        gui.achievementText = achievement;
        componentObject.transform.rotation = Quaternion.Euler(x, y, z);
        buildHand.transform.localPosition = new Vector3(0, 0, 0.5f);;
        pcBuilding.pickedUp = false;
        pcBuilding.pressed = false;
        gui.componentInstalled = true;
    }
}