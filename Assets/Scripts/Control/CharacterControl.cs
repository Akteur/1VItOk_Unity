using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject pauseMenuObject;
    [SerializeField] float speed = 3.0f;
    [SerializeField] float jumpspeed = 8.0f;
    [SerializeField] float gravity = 30.0f;
    private Vector3 moveDir = Vector3.zero;
    private CharacterController controller;
    private GUIObjectName scriptGUI;
    private PauseMenu scriptPause;
    void Start()
    {
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
        scriptPause = pauseMenuObject.GetComponent<PauseMenu>();
        scriptGUI = mainCamera.GetComponent<GUIObjectName>();
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (scriptGUI.controlPossibility && !scriptPause.paused)
        {
            if (scriptGUI.canMove)
            {
                if (controller.isGrounded)
                {
                    moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    moveDir = transform.TransformDirection(moveDir);
                    moveDir *= speed;
                }
                if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
                {
                    moveDir.y = jumpspeed;
                }
                moveDir.y -= gravity * Time.deltaTime;

                controller.Move(moveDir * Time.deltaTime);
            }
        }
    }
}
