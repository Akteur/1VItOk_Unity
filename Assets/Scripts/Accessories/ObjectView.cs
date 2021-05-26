using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectView : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    private Vector3 StartPos;
    private float x, y, z;
    public bool CanRotate = false, isPicked = false;
    // Update is called once per frame
    void Update()
    {
        ViewObject();
    }
    private void ViewObject()
    {
        if (isPicked)
        {
            x = Input.mousePosition.x;
            y = Input.mousePosition.y;
            z = Input.mousePosition.z;
            var script = mainCamera.GetComponent<GUIObjectName>();
            if (!script.controlPossibility)
            {
                Cursor.visible = true;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    StartPos = Input.mousePosition;

                    CanRotate = true;
                }
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    CanRotate = false;
                }
                if (CanRotate)
                {
                    transform.localRotation = Quaternion.Euler((StartPos.y - y), (StartPos.x - x), (StartPos.z - z));
                }
            }
        }
    }
}