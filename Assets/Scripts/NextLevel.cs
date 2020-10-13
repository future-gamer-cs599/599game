using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public int levelBuildIndex;
    public void LoadNextLevel() {
        // save player progress
        if (PlayerPrefs.GetInt("levelAt") < levelBuildIndex) {
            PlayerPrefs.SetInt("levelAt", levelBuildIndex);

            // Analytics Log: first time completing level
            AnalyticsResult firstCompleteAnalytics = Analytics.CustomEvent(
                "LevelFirstComplete", new Dictionary<string, object> {
                    { "Level", SceneManager.GetActiveScene().buildIndex - 1}
                }
            );

            // Analytics Log: level unlocked
            AnalyticsResult unlockAnalytics = Analytics.CustomEvent(
                "LevelUnlocked", new Dictionary<string, object> {
                    { "Level", SceneManager.GetActiveScene().buildIndex }
                }
            );

            // Debug: Analytics 
            Debug.Log("CustomEvent LevelUnlock sent: " + unlockAnalytics);
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("CustomEvent FirstLevelComplete sent: " + firstCompleteAnalytics);
            Debug.Log(SceneManager.GetActiveScene().buildIndex - 1);
        }

        // Analytics Log: level completed
        AnalyticsResult completeAnalytics = Analytics.CustomEvent(
            "LevelComplete", new Dictionary<string, object> {
                { "Level", SceneManager.GetActiveScene().buildIndex - 1 },
                { "CompleteTime", GameObject.Find("Score").GetComponent<Text>().text}
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
