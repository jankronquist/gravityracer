using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;

public class CompletedPopup : MonoBehaviour
{
    public TextMeshProUGUI label;
    public TextMeshProUGUI timeText;
    public Animator animator;
    public NewLife newLife;
    private bool visible;

    public void OnRaceCompleted(float t) {
        label.text = "Total time";
        timeText.text = t.ToString("F2");
        animator.Play("Popup");
    }

    public void OnRaceRecord(float t) {
        label.text = "New record!";
    }

    public void SetVisible() {
        this.visible = true;
    }

    public void StartGame() {
        newLife.StartGame();
    }

    private void FixedUpdate() {
        if (visible && Input.anyKey) {
            animator.Play("Popdown");
            visible = false;
        }
    }
}
