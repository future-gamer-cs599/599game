using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;



public class gotoNextButton : MonoBehaviour
{
    public GameManager gameManager;
    public void NextLevel()
    {
        Debug.Log("complete level");
        gameManager.LoadNextLevel();
    }
}
