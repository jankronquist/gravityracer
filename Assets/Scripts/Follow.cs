using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Rigidbody2D target;
    public Vector2 lastPosition;
    private float z;
    private float orthographicSize;
    private new Camera camera;

    void Start() {
        lastPosition = this.transform.position;
        z = this.transform.position.z;
        this.camera = this.GetComponent<Camera>();
        orthographicSize = this.camera.orthographicSize;
    }

    void FixedUpdate() {
        Vector2 aimPosition;
        if (target != null) {
            lastPosition = target.position;
            aimPosition = target.position + 1.4f * target.velocity;
        } else {
            aimPosition = lastPosition;
        }
        Vector2 t = Vector2.Lerp(this.transform.position, aimPosition, Time.deltaTime);
        if (camera.orthographic) {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, orthographicSize + Mathf.Sqrt(Vector2.Distance(t, aimPosition)), Time.deltaTime);
            this.transform.position = new Vector3(t.x, t.y, z);
        } else {
            float tz = Mathf.Lerp(this.transform.position.z, z - Vector2.Distance(t, aimPosition), Time.deltaTime);
            this.transform.position = new Vector3(t.x, t.y, tz);
        }
    }
}
