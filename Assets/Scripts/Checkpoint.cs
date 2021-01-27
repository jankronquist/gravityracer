using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using TMPro;

public class Checkpoint : MonoBehaviour {
    private float record = float.MaxValue;
    public FloatVariable raceTime;
    public TextMeshProUGUI label;
    public AudioClip checkpointSound;
    public AudioClip newRecordSound;
    public AudioSource audioSource;

    private Renderer line;
    private new Collider2D collider;

    void Start() {
        line = this.GetComponent<SpriteRenderer>();
        collider = this.GetComponent<BoxCollider2D>();
    }

    public void RaceStarted() {
        line.enabled = true;
        collider.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Checkpoint colli:" + collision.name + " tag=" + collision.tag);
        if (collision.tag == "Player") {
            line.enabled = false;
            collider.enabled = false;
            if (raceTime.Value < record) {
                audioSource.PlayOneShot(newRecordSound);
                record = raceTime.Value;
                label.text = record.ToString("F2");
            } else {
                audioSource.PlayOneShot(checkpointSound);
            }
        }
    }
}
