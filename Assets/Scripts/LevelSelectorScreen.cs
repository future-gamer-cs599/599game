using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using TMPro;

public class LevelSelectorScreen : MonoBehaviour
{
    public bool unlockLevels;

    void Start() {
        InitializeLevels();
    }

    void InitializeLevels() {
        if (!PlayerPrefs.HasKey("levelAt"))
        {
            // Analytics Log: level unlocked
            AnalyticsResult unlockAnalytics = Analytics.CustomEvent(
                "LevelUnlocked", new Dictionary<string, object> {
                    { "Level", 1 }
                }
            );

            // Debug: Analytics 
            Debug.Log("New User, CustomEvent LevelUnlock sent: " + unlockAnalytics);
            Debug.Log(1);
        }
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);

        Button[] buttons = this.GetComponentsInChildren<Button> ();

        if (!unlockLevels) {
            for (int i = 0; i < buttons.Length; i++) {
                if (Int32.Parse(buttons[i].name) > levelAt) {
                    buttons[i].interactable = false;
                }
            }
        }
    }
}
