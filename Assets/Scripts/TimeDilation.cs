using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimeDilation : MonoBehaviour
{

    public float force_deceleration = 10f;
    private Vector3 moveDir;
    public static bool isDeceleration = false;
    public float slowDownLength = 3f;

    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) {
            isDeceleration = true;
            Time.timeScale = 1 / force_deceleration;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;

            // player.transform.position = new Vector3(Input.GetAxis("Horizontal") * force_deceleration, 0, Input.GetAxis("Vertical") * force_deceleration);
            // moveDir = transform.right * (Input.GetAxis("Horizontal") * force_deceleration) + transform.forward * (Input.GetAxis("Vertical") * force_deceleration);
            // controller.Move(moveDir * 5 * Time.deltaTime);

        }
        if (Input.GetKeyDown(KeyCode.J)) {
            isDeceleration = false;
            Time.timeScale = 1f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            // transform.position = deafult_settings.position;
        }

        // Time.timeScale += 1f / slowDownLength;
        // Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }
}
