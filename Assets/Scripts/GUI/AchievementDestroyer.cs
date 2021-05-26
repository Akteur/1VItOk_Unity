using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementDestroyer : MonoBehaviour
{
    [SerializeField] string objectName;
    [SerializeField] string objectTextName;
    GameObject mainCamera;
    GameObject objectText;
    GUIObjectName gui;

    void Start()
    {
        mainCamera = GameObject.Find(objectName);
        objectText = GameObject.Find(objectTextName);
        gui = mainCamera.GetComponent<GUIObjectName>();
        objectText.GetComponent<TextMeshProUGUI>().text = gui.achievementText;
        StartCoroutine(AchievementDestroy());
    }

    IEnumerator AchievementDestroy()
    {
        yield return new WaitForSeconds(2f);
        gui.achievementInstantiated = false;
        Destroy(gameObject);
        StopCoroutine(AchievementDestroy());
    }
}
