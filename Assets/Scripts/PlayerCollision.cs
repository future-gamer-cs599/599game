using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public JoyStickMove movement;
    public AudioSource sound;
    public GameObject GameOverText;
    //GameObject playerObj = GameObject.Find("Player");

    private void Start()
    {
        GameOverText.SetActive(false);
    }

    void OnCollisionEnter(Collision other){
        if (other.collider.tag == "Obstacle") {
            Debug.Log("It hurts! I'm colliding with: " + other.collider.name);
            GameOverText.SetActive(true);
            sound.Play();
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
}
