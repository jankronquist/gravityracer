using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Rigidbody2D target;

    void FixedUpdate() {
        Vector2 t = Vector2.Lerp(this.transform.position, target.position + 1.4f * target.velocity, Time.deltaTime);
        this.transform.position = new Vector3(t.x, t.y, this.transform.position.z);
    }
}
