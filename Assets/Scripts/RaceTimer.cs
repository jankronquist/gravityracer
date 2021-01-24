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
    private bool finished;

    void Start() {
        ResetTimer();
    }

    public void ResetTimer() {
        label.text = "";
        racing = false;
        finished = false;
    }

    public void RaceStarted(float t) {
        racing = true;
        startTime = t;
    }

    public void RaceFinished(float t) {
        finished = true;
        totalTime = t - startTime;
        raceTime.SetValue(totalTime);
    }

    void FixedUpdate() {
        if (racing) {
            if (finished) {
                label.text = totalTime.ToString("F2");
            } else {
                raceTime.Value = (Time.time - startTime);
                label.text = (Time.time - startTime).ToString("F2");
            }
        }
    }
}
