using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCbuilding : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject player;
    [SerializeField] public GameObject buildHand;
    [SerializeField] GameObject manager;
    private GUIObjectName gui;
    private ObjectScaling objectScaling;
    private Raycasting raycastScript;
    private ComponentInstallation componentInstallation;
    private float wheelSpeed = 0.5f;
    public bool pickedUp = false;
    public bool pressed = false;
    void Start()
    {
        objectScaling = mainCamera.GetComponent<ObjectScaling>();
        raycastScript = mainCamera.GetComponent<Raycasting>();
        gui = mainCamera.GetComponent<GUIObjectName>();
    }
    void Update()
    {
        DragAndDrop();
        if (pickedUp && !componentInstallation.componentInstalled && pressed)
        {
            TakeObject(raycastScript.raycastedObject);
        }
        if (raycastScript.raycastedObject != null)
        {
            objectScaling.Scaling(buildHand, buildHand, wheelSpeed, 2f, 0.7f);
        }
    }
    private void DragAndDrop()
    {
        if(raycastScript.raycastedObject == null)
        {
            return;
        }
        if (GameManager.instance.buildStarted)
        {
            componentInstallation = raycastScript.raycastedObject.GetComponent<ComponentInstallation>();
            if (raycastScript.succesful)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!pickedUp && !componentInstallation.componentInstalled && !pressed)
                    {
                        pickedUp = true;
                        pressed = true;
                        TakeObject(raycastScript.raycastedObject);
                    }
                    else if(pickedUp && !componentInstallation.componentInstalled && pressed)
                    {
                        DropObject(raycastScript.raycastedObject, false);
                        raycastScript.raycastedObject = null;
                        pickedUp = false;
                        pressed = false;
                        buildHand.transform.localPosition = new Vector3(0, 0, 0.7f);
                    }
                }
            }
        }
        else
        {
            if (raycastScript.succesful && pickedUp)
            {
                DropObject(raycastScript.raycastedObject, true);
                raycastScript.raycastedObject = null;
                pickedUp = false;
                pressed = false;
                buildHand.transform.localPosition = new Vector3(0, 0, 0.7f);
            }
        }
    }
    private void TakeObject(GameObject obj)
    {
        obj.transform.position = buildHand.transform.position;
        switch (obj.name)
        {
            case "Videocard":
                {
                    obj.transform.rotation = Quaternion.Euler(90, 0, 180);
                    break;
                }
            case "Processor":
                {
                    obj.transform.rotation = Quaternion.Euler(0, 180, 0);
                    break;
                }
            case "RAM":
                {
                    obj.transform.rotation = Quaternion.Euler(0, 90, -90);
                    break;
                }
        }
        gui.helpText = "Вставьте комплектующее";
        gui.buildAreaHelpInstall = false;
        obj.GetComponent<Rigidbody>().isKinematic = true;
    }
    private void DropObject(GameObject obj, bool exitWithComponent)
    {
        if (GameManager.instance.buildStarted || exitWithComponent)
        {
            GameObject objPlace = GameObject.Find(raycastScript.raycastedObject.name + "Place");
            obj.transform.position = objPlace.transform.position;
            obj.transform.rotation = objPlace.transform.rotation;
            obj.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}