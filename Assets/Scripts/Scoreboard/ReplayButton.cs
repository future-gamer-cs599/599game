using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour
{
    public float restartDelay = 2f;
    // Return to home screen
    public void Home()
    {
        Debug.Log("restart called");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
