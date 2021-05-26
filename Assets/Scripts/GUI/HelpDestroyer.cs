using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HelpDestroyer : MonoBehaviour
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
        objectText.GetComponent<TextMeshProUGUI>().text = gui.helpText;
        StartCoroutine(HelpDestroy());
    }

    IEnumerator HelpDestroy()
    {
        yield return new WaitForSeconds(3f);
        gui.helpInstantiated = false;
        Destroy(gameObject);
    }
}
