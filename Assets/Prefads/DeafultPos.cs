using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeafultPos : MonoBehaviour
{
    private Vector3 deafultPosition;
    private Quaternion deafultRotation;

    // Start is called before the first frame update
    void Start()
    {
        deafultPosition = transform.position;
        deafultRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            transform.position = deafultPosition;
            transform.rotation = deafultRotation;
        }
    }
}
