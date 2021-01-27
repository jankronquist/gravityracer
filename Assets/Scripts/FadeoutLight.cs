using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FadeoutLight : MonoBehaviour
{
    public float time=3f;

    private float startTime;
    private float intensity;
    private new Light2D light;

    void Start() {
        this.startTime = Time.time;
        this.light = this.GetComponent<Light2D>();
        intensity = light.intensity;
    }

    void FixedUpdate() {
        float t = Time.time - startTime;
        if (t >= time) {
            Destroy(this.gameObject);
        } else {
            this.light.intensity = intensity * Mathf.InverseLerp(time, 0, t);
        }
    }
}
