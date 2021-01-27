using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ScriptableObjectArchitecture;

public class RaceTimer : MonoBehaviour {
    public TextMeshProUGUI label;
    public FloatVariable raceTime;

    private float startTime;
    private float totalTime;
    private bool racing;

    void Start() {
        ResetTimer();
    }

    public void ResetTimer() {
        label.text = "";
        racing = false;
    }

    public void RaceStarted(float t) {
        racing = true;
        startTime = t;
    }

    public void RaceFinished(float t) {
        racing = false;
        totalTime = t;
        label.text = "";
    }

    void FixedUpdate() {
        if (racing) {
            raceTime.Value = (Time.time - startTime);
            label.text = (Time.time - startTime).ToString("F2");
        }
    }
}
