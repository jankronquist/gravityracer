using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using TMPro;

public class TutorialText : MonoBehaviour
{
    public BoolVariable alive;
    public Color aliveColor;
    public Color deadColor;
    private TextMeshProUGUI label;

    void Start() {
        label = this.GetComponent<TextMeshProUGUI>();
        alive.AddListener(AliveChanged);
    }

    private void OnDestroy() {
        alive.RemoveListener(AliveChanged);
    }

    void AliveChanged() {
        label.CrossFadeColor(alive.Value ? aliveColor : deadColor, 2, false, true);
    }
}
