using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    [SerializeField] Image panel;
    [SerializeField] RectTransform rectTransformPanel;
    [SerializeField] RectTransform rectTransformText;
    [SerializeField] RectTransform rectTransformCanvas;
    [SerializeField] GameObject lookHand;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject table;
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] Transform player;
    [SerializeField] GameObject globalVolume;
    [SerializeField] GameObject pauseMenuObject;
    private ObjectScaling objectScaling;
    private GUIObjectName scriptGUI;
    private Raycasting raycastScript;
    private GameObject obj;
    private PauseMenu pauseMenu;
    private float wheelSpeed = 0.5f;
    public bool PickedUp = false;
    private float x, y;
    List<string> strings;
    void Start()
    {
        scriptGUI = mainCamera.GetComponent<GUIObjectName>();
        raycastScript = mainCamera.GetComponent<Raycasting>();
        objectScaling = mainCamera.GetComponent<ObjectScaling>();
        pauseMenu = pauseMenuObject.GetComponent<PauseMenu>();
        rectTransformPanel.anchoredPosition = new Vector2((rectTransformCanvas.sizeDelta.x / 2) - (rectTransformCanvas.sizeDelta.x / 6), 0);
    }
    void Update()
    {
        TakeObject();
        if (obj != null && PickedUp)
        {
            objectScaling.Scaling(lookHand, lookHand, wheelSpeed, 1.5f, 0.7f);
            obj.transform.position = lookHand.transform.position;
        }
    }
    IEnumerator CanPause()
    {
        yield return new WaitForSeconds(2f);
        pauseMenu.canPause = true;
    }
    private void TakeObject()
    {
        x = player.transform.eulerAngles.x;
        y = player.transform.eulerAngles.y;
        if (PickedUp)
        {
            ChangeTextPanel();
        }
        if (raycastScript.succesful)
        {
            var scriptView = raycastScript.raycastedObject.GetComponent<ObjectView>();
            var buildArea = table.GetComponent<BuildArea>();
            if (scriptGUI.controlPossibility && !buildArea.inBuildArea)
            {
                if (Input.GetMouseButton(0) && !pauseMenu.paused)
                {
                    StopAllCoroutines();
                    ChangeTextPanel();
                    scriptView.isPicked = true;
                    PickedUp = true;
                    scriptGUI.controlPossibility = false;
                    obj = raycastScript.raycastedObject.gameObject;
                    pauseMenu.canPause = false;
                    Cursor.visible = true;
                    MoveToPlayer();                    
                }
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && scriptGUI.controlPossibility == false)
            {
                rectTransformPanel.sizeDelta = new Vector2(0, 0);
                rectTransformText.sizeDelta = new Vector2(0, 0);
                scriptView.isPicked = false;
                PickedUp = false;
                scriptGUI.controlPossibility = true;
                MoveToStartPlace();
                Cursor.visible = false;
                StartCoroutine(CanPause());
            }
        }
    }
    private void ChangeTextPanel()
    {
        rectTransformPanel.anchoredPosition = new Vector2((rectTransformCanvas.sizeDelta.x / 2) - (rectTransformCanvas.sizeDelta.x / 6), 0);
        rectTransformPanel.sizeDelta = new Vector2(rectTransformCanvas.sizeDelta.x / 3, rectTransformCanvas.sizeDelta.y - 50);
        rectTransformText.sizeDelta = new Vector2(rectTransformPanel.sizeDelta.x - 20, rectTransformPanel.sizeDelta.y - 20);
    }
    private void MoveToPlayer()
    {
        obj.transform.position = lookHand.transform.position;
        obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation, Quaternion.Euler(x, y, 90), Time.deltaTime * 50);
        obj.GetComponent<Rigidbody>().isKinematic = true;
        textMesh.SetText(LineBreak(obj.GetComponent<Name>().Description));
    }
    private void MoveToStartPlace()
    {
        obj.GetComponent<Transform>().position = GameObject.Find(obj.name + "Place").transform.position;
        obj.GetComponent<Rigidbody>().isKinematic = !obj.GetComponent<Rigidbody>().isKinematic;
        textMesh.SetText("");
        lookHand.transform.localPosition = new Vector3(0, 0.0025f, 1.5f);
    }
    private string LineBreak(string description)
    {
        string result = "";
        string[] temp = description.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        for(int i = 0; i < temp.Length; i++)
        {
            result += temp[i] + "\n";
        }
        return result;
    }
}
