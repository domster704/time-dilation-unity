using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float speed = 4f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    private Vector3 moveDir;

    public GameObject ui;
    private RectTransform rectTransfrom;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        rectTransfrom = ui.GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || !controller.isGrounded) {
            rectTransfrom.sizeDelta = new Vector2(100, 100);
        } else {
            rectTransfrom.sizeDelta = new Vector2(50, 50);
        }

        if (controller.isGrounded) {
            moveDir = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded) {
            moveDir.y = jumpSpeed;
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            speed = 24f;
        } else {
            speed = 4f;
        }

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * speed * Time.deltaTime);
    }
}
