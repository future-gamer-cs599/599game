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

    public CanvasGroup WinImageCanvasGroup;
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    bool m_IsPlayerWin;
    float m_Timer;

    private void Start()
    {
        scoreBoard.SetActive(false);
        timeDisplayed.SetActive(true);
        var levelName = (SceneManager.GetActiveScene().buildIndex - 1).ToString();
        if (PlayerPrefs.GetFloat(levelName, 10000f) == 10000f)
        {
            bestScore.text = "Not Available";
        }
        else
        {
            bestScore.text = PlayerPrefs.GetFloat(levelName, 10000f).ToString("F2") + "s";
        }

    }

    void Update()
    {
        if (updateTimer)
        {
            timeStart += Time.deltaTime;
        }

        if (m_IsPlayerWin) {
            WinLevel();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name == "Player")
        {
            m_IsPlayerWin = true;
            winningSound.Play();
            updateTimer = false;
            movement.enabled = false;
            Debug.Log("end hit");
            var levelName = (SceneManager.GetActiveScene().buildIndex - 1).ToString();
            if (timeStart < PlayerPrefs.GetFloat(levelName, 10000f))
            {
                PlayerPrefs.SetFloat(levelName, timeStart);
                bestScore.text = PlayerPrefs.GetFloat(levelName, 10000f).ToString("F2") + "s";
                PlayerPrefs.Save();
            }
        }

        AnalyticsResult timeAnalytics = Analytics.CustomEvent(
               "LevelTimeCost", new Dictionary<string, object> {
                    { "Level", SceneManager.GetActiveScene().buildIndex - 1 },
                    { "Time", timeStart}
               });

        Debug.Log("CustomEvent LevelTime sent: " + timeAnalytics);
    }

    void WinLevel() {
        m_Timer += Time.deltaTime;
        WinImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration) {
            WinImageCanvasGroup.alpha = 0;
            scoreBoard.SetActive(true);//show scoreboard
            timeDisplayed.SetActive(false);
            score.text = timeStart.ToString("F2") + "s";
            // Debug.Log("player win");
            // gameManager.completeLevel();
        } 
    }
}
