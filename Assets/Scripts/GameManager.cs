using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System; 
using System.Collections.Generic;  

public class GameManager : MonoBehaviour
{
    public int levelBuildIndex;
    public float restartDelay = 2f;
    bool gameEnded = false;

    // public GameObject levelCompleteUI;

    public bool getGameEnded() {
        return gameEnded;
    }
    public void completeLevel() {
        Debug.Log("complete level");
        // levelCompleteUI.SetActive(true);
    }

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

        // // Analytics Log: level completed
        // AnalyticsResult completeAnalytics = Analytics.CustomEvent(
        //     "LevelComplete", new Dictionary<string, object> {
        //         { "Level", SceneManager.GetActiveScene().buildIndex - 1 },
        //         { "CompleteTime", GameObject.FindWithTag("scoreScore").GetComponent<Text>().text}
        //     }
        // );
        // Analytics Log: level open
        AnalyticsResult openAnalytics = Analytics.CustomEvent(
            "LevelOpen", new Dictionary<string, object> {
                { "Level", SceneManager.GetActiveScene().buildIndex }
            }
        );

        // Debug: analytics
        // Debug.Log("CustomEvent LevelComplete sent: " + completeAnalytics);
        Debug.Log("CustomEvent LevelOpen sent: " + openAnalytics);
        
        // use build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1) ;
    }

    public void EndGame(string endReason) {
        // use gameEnded varibale so that line 11 is executed only once
        if (!gameEnded) {
            gameEnded = true;
            Debug.Log("Game Over!");
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
            // Analytics Log: Level lost by failling
            GameObject player = GameObject.Find("Player");
            AnalyticsResult lossAnalytics = Analytics.CustomEvent(
                "LevelLost", new Dictionary<string, object> {
                    { "Level", SceneManager.GetActiveScene().buildIndex - 1 },
                    { "Obstacle", endReason},
                    { "X", player.GetComponent<Transform>().position.x },
                    { "Y", player.GetComponent<Transform>().position.y },
                    { "Z", player.GetComponent<Transform>().position.z }
            });
            // Debug: analytics
            Debug.Log("CustomEvent LevelLost sent: " + lossAnalytics);
             Debug.Log("CustomEvent player x sent: " + player.GetComponent<Transform>().position.x );

            Invoke("Restart", restartDelay);
        }
    }

    void Restart() {
        // restart to the currently active scene (not always level 1)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
