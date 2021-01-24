using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Rigidbody2D target;
    public Vector2 lastPosition;

    void Start() {
        lastPosition = this.transform.position;
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
        this.transform.position = new Vector3(t.x, t.y, this.transform.position.z);
    }
}
