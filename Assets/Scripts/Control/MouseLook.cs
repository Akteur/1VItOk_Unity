using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/MoseLook")]
public class MouseLook : MonoBehaviour
{
    public enum RotationAxis { MouseXandY = 0, MouseX = 1, MouseY = 2 };
    public RotationAxis axis = RotationAxis.MouseXandY;

    public float sensitivityX = 2F;
    public float sensitivityY = 2F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -45F;
    public float maximumY = 45F;

    public float rotationX = 0f;
    public float rotationY = 0f;

    Quaternion originalRotation;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject pauseMenuObject;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        originalRotation = transform.localRotation;
    }
    void Update()
    {
        Look();
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
    private void Look()
    {
        var scriptGUI = mainCamera.GetComponent<GUIObjectName>();
        var scriptPause = pauseMenuObject.GetComponent<PauseMenu>();
        if (scriptGUI.controlPossibility && !scriptPause.paused)
        {
            if (scriptGUI.canLook)
            {
                if (axis == RotationAxis.MouseXandY)
                {
                    rotationX += Input.GetAxis("Mouse X") * sensitivityX;
                    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

                    rotationX = ClampAngle(rotationX, minimumX, maximumX);
                    rotationY = ClampAngle(rotationY, minimumY, maximumY);
                    Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
                    Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);

                    transform.localRotation = originalRotation * xQuaternion * yQuaternion;
                }
                else if (axis == RotationAxis.MouseX)
                {
                    rotationX += Input.GetAxis("Mouse X") * sensitivityX;
                    rotationX = ClampAngle(rotationX, minimumX, maximumX);
                    Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
                    transform.localRotation = originalRotation * xQuaternion;
                }
                else if (axis == RotationAxis.MouseY)
                {
                    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                    rotationY = ClampAngle(rotationY, minimumY, maximumY);
                    Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);
                    transform.localRotation = originalRotation * yQuaternion;
                }
            }
        }
    }
}
