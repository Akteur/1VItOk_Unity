using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpSpeed = 10.0f;
    [SerializeField] private float gravity = 20.0f;
    private Vector3 moveDir = Vector3.zero;

    // Компонент CharacterController
    private CharacterController cc;

    void Start()
    {
        // Получаем компонент CharacterController
        cc = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        // Получаем нажатия предустановленных клавиш
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Записываем данные в отдельную переменную
        Vector2 input = new Vector2(horizontal, vertical);
        // Определяем направление движения
        Vector3 desiredMove = transform.forward * input.y + transform.right * input.x;
        Vector3 moveDir = new Vector3(desiredMove.x * speed, 0, desiredMove.z * speed);
        // Передвигаем объект
        cc.Move(moveDir * Time.fixedDeltaTime);
    }
}