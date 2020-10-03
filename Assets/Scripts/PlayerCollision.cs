﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    void OnCollisionEnter(Collision other){
        if (other.collider.tag == "Obstacle") {
            Debug.Log("It hurts! I'm colliding with: " + other.collider.name);
            movement.enabled = false;

            // Log in anaytics
            AnalyticsResult analyticsResult = Analytics.CustomEvent(
                "LevelLost", new Dictionary<string, object> {
                    // add level //
                    { "Level", SceneManager.GetActiveScene().buildIndex - 1 },
                    { "Obstacle", other.collider.name},
                    { "X", GetComponent<Transform>().position.x },
                    { "Y", GetComponent<Transform>().position.y },
                    { "Z", GetComponent<Transform>().position.z }
            });

            // Debug analytics log
            Debug.Log("CustomEvent LevelLost sent: " + analyticsResult);
            Debug.Log("Level: " + (SceneManager.GetActiveScene().buildIndex - 1).ToString());
            Debug.Log("Obstacle: " + other.collider.name);
            Debug.Log("X: " + GetComponent<Transform>().position.x);
            Debug.Log("Y: " + GetComponent<Transform>().position.y);
            Debug.Log("Z: " + GetComponent<Transform>().position.z);

            FindObjectOfType<GameManager>().EndGame();
        }
        else if (other.collider.tag == "Block") {
        	Debug.Log("Wrong way! I'm walking towards: " + other.collider.name);
            // movement.enabled = false;
            // FindObjectOfType<GameManager>().EndGame();
        }
    }
}
