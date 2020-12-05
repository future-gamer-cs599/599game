using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public JoyStickMove movement;
    public AudioSource hitSound;
    public CanvasGroup LoseImageCanvasGroup;
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;

    bool m_IsPlayerLose;
    float m_Timer;
    string m_LoseReason;

    private void Start()
    {
        // GameOverText.SetActive(false);
    }

    void Update() {
         if (m_IsPlayerLose) {
            LoseLevel();
        }
    }

    void OnCollisionEnter(Collision other){
        if (other.collider.tag == "Obstacle") {
            Debug.Log("It hurts! I'm colliding with: " + other.collider.name);
            // GameOverText.SetActive(true);
            m_IsPlayerLose = true;
            hitSound.Play();
            //playerObj.GetComponent<JoyStickMove>().enabled = false;
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame(other.collider.name);
        }
        else if (other.collider.tag == "Block") {
        	Debug.Log("Wrong way! I'm walking towards: " + other.collider.name);
            // movement.enabled = false;
            // FindObjectOfType<GameManager>().EndGame();
        }
    }

    void LoseLevel() {
        m_Timer += Time.deltaTime;
        LoseImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration) {
            Debug.Log("player lose");
            FindObjectOfType<GameManager>().EndGame(m_LoseReason);
        }
    }
}
