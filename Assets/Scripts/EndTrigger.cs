using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource winningSound;
    public float timeStart;
    bool updateTimer = true;

    void Update()
    {
        if (updateTimer)
        {
            timeStart += Time.deltaTime;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name == "Player")
        {
            winningSound.Play();
            updateTimer = false;
            Debug.Log("end hit");
            gameManager.completeLevel();
        }

        AnalyticsResult timeAnalytics = Analytics.CustomEvent(
               "LevelTimeCost", new Dictionary<string, object> {
                    { "Level", SceneManager.GetActiveScene().buildIndex - 1 },
                    { "Time", timeStart}
               });

        Debug.Log("CustomEvent LevelTime sent: " + timeAnalytics);

  
        
    }
}
