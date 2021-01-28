using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour {
    private float currentZ;
    public float speed;

    void Start() {
        currentZ = this.transform.rotation.eulerAngles.z;
    }

    void FixedUpdate() {
        currentZ = Mathf.Repeat(currentZ + (speed * Time.deltaTime), 360);
        this.transform.rotation = Quaternion.Euler(0, 0, currentZ);
    }
}
