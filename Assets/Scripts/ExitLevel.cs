using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    public int levelScreenIndex;
    // Return to home screen
    public void Home() {
        // Analytics Log: level where player exits
        AnalyticsResult exitAnalytics = Analytics.CustomEvent(
            "LevelExit", new Dictionary<string, object> {
                { "Level", SceneManager.GetActiveScene().buildIndex - 1 },
        });
        // Debug: analytics
        Debug.Log("CustomEvent LevelExit sent: " + exitAnalytics);

        SceneManager.LoadScene(levelScreenIndex);
    }
}
