using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using UnityEngine.UI;
public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource winningSound;
    public JoyStickMove movement;
    public float timeStart;
    bool updateTimer = true;

    public Text score;
    public Text bestScore;
    public GameObject scoreBoard;
    public GameObject timeDisplayed;

    private void Start()
    {
        scoreBoard.SetActive(false);
        timeDisplayed.SetActive(true);
        var levelName = (SceneManager.GetActiveScene().buildIndex - 1).ToString();
        if (PlayerPrefs.GetFloat(levelName + "HighScore", 0f) == 0)
        {
            bestScore.text = "Not Available";
        }
        else
        {
            bestScore.text = PlayerPrefs.GetFloat(levelName + "HighScore", 0f).ToString("F2") + "s";
        }

    }

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
            movement.enabled = false;
            Debug.Log("end hit");
            var levelName = (SceneManager.GetActiveScene().buildIndex - 1).ToString();
            if (timeStart < PlayerPrefs.GetFloat(levelName + "HighScore", 0f))
            {
                PlayerPrefs.SetFloat(levelName + "HighScore", timeStart);
            }
            scoreBoard.SetActive(true);//show scoreboard
            timeDisplayed.SetActive(false);
            score.text = timeStart.ToString("F2") + "s";

            //gameManager.completeLevel();
        }

        AnalyticsResult timeAnalytics = Analytics.CustomEvent(
               "LevelTimeCost", new Dictionary<string, object> {
                    { "Level", SceneManager.GetActiveScene().buildIndex - 1 },
                    { "Time", timeStart}
               });

        Debug.Log("CustomEvent LevelTime sent: " + timeAnalytics);



    }
}
