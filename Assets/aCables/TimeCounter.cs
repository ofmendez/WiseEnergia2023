using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCounter : MonoBehaviour {
    internal bool isRunning = false;
    TextMeshProUGUI valueText;
    float time = 0f;

    internal void StartTimer() {
        isRunning = true;

    }

    // Start is called before the first frame update
    void Start() {
        valueText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ResetTimer() {
        isRunning = false;
        time = 0f;
        valueText.text = "00:00";
    }

    // Update is called once per frame
    void Update() {
        
        if (isRunning) {
            time += Time.deltaTime;
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            string timeText = timeSpan.ToString(@"mm\:ss");
            valueText.text = timeText;
        }
    }
}
