using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class NextLevel : MonoBehaviour
{
    public int levelBuildIndex;
    public void LoadNextLevel() {
        // save player progress
        if (PlayerPrefs.GetInt("levelAt") < levelBuildIndex) {
            PlayerPrefs.SetInt("levelAt", levelBuildIndex);

            // Analytics Log: level unlocked
            AnalyticsResult unlockAnalytics = Analytics.CustomEvent(
            "LevelUnlocked", new Dictionary<string, object> {
                { "Level", SceneManager.GetActiveScene().buildIndex }
                }
            );

              // Analytics Log: level unlocked
            Debug.Log("CustomEvent LevelUnlock sent: " + unlockAnalytics);
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
        }

        // int levelAt = Math.Max(PlayerPrefs.GetInt("levelAt"), levelBuildIndex + 1);
        // PlayerPrefs.SetInt("levelAt", levelAt);

        // Analytics Log: level completed
        AnalyticsResult completeAnalytics = Analytics.CustomEvent(
            "LevelComplete", new Dictionary<string, object> {
                { "Level", SceneManager.GetActiveScene().buildIndex - 1 }
            }
        );
        // Analytics Log: level open
        AnalyticsResult openAnalytics = Analytics.CustomEvent(
            "LevelOpen", new Dictionary<string, object> {
                { "Level", SceneManager.GetActiveScene().buildIndex }
            }
        );

        // Debug: analytics
        Debug.Log("CustomEvent LevelComplete sent: " + completeAnalytics);
        Debug.Log("CustomEvent LevelOpen sent: " + openAnalytics);
        
        // use build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1) ;
    }
}
