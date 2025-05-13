using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    class PointsInTime {
        public Vector3 position;
        public Quaternion rotation;

        public PointsInTime(Vector3 _position, Quaternion _rotation) {
            this.position = _position;
            this.rotation = _rotation;
        }
    }

    public bool isRewind = false;
    List<PointsInTime> points;
    public float maxTime = 20f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        points = new List<PointsInTime>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            startRewind();
        } 
        if (Input.GetKeyUp(KeyCode.P)) {
            stopRewind();
        }
    }

    private void FixedUpdate() {
        if (isRewind) {
            rewind();
        } else {
            record();
        }
    }

    void rewind() {

        if (points.Count > 0) {
            transform.position = points[0].position;
            transform.rotation = points[0].rotation;
            points.RemoveAt(0);
        }
    }

    void record() {
        if (points.Count > (1f / Time.fixedDeltaTime) * maxTime) {
            points.RemoveAt(points.Count - 1);
        }
        points.Insert(0, new PointsInTime(transform.position, transform.rotation));
    }

    void startRewind() {
        isRewind = true;
        try {
            rb.isKinematic = true;
        } catch {}
    }

    void stopRewind() {
        isRewind = false;
        try {
            rb.isKinematic = false;
        } catch { }
    }
}
