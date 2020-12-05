using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class OpenLevel : MonoBehaviour
{
    public int level;
    public void Open() {
        // Analytics Log: level open
        AnalyticsResult openAnalytics = Analytics.CustomEvent(
            "LevelOpen", new Dictionary<string, object> {
                { "Level", level }
            }
        );
        Debug.Log("CustomEvent LevelOpen sent: " + openAnalytics);

        SceneManager.LoadScene(level + 1);
    }
}
