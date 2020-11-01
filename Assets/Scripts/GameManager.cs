using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System; 
using System.Collections.Generic;  

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public float restartDelay = 2f;
    public GameObject levelCompleteUI;

    public bool getGameEnded() {
        return gameEnded;
    }
    public void completeLevel() {
        Debug.Log("complete level");
        levelCompleteUI.SetActive(true);
        
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
