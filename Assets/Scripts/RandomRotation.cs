using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    private Quaternion originalRotation;
    private float currentZ;
    private float originalZ;
    private float targetZ;
    private float nextSwitch;
    public float delay;
    public float rotationSize;

    void Start()
    {
        originalRotation = this.transform.rotation;
        originalZ = this.transform.rotation.eulerAngles.z;
        currentZ = originalZ;
        targetZ = originalZ;
        nextSwitch = Time.time + delay;
    }

    void FixedUpdate() {
        if (Time.time > nextSwitch) {
            targetZ = originalZ + Random.Range(-rotationSize, rotationSize);
            nextSwitch = Time.time + delay + (Random.value * delay);
        }
        currentZ = Mathf.LerpAngle(currentZ, targetZ, 0.05f);
        this.transform.rotation = Quaternion.Euler(0, 0, currentZ);
    }
}
