using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameEnded = false;
    public float restartDelay = 2f;
    public GameObject levelCompleteUI;

    public bool isLossed;
    public int lossSenceID;

    void Awake()
    {
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public void completeLevel() {
        Debug.Log("complete level");
        levelCompleteUI.SetActive(true);
        
    }

    public void EndGame() {
        // use gameEnded varibale so that line 11 is executed only once
        if (!gameEnded) {
            gameEnded = true;
            Debug.Log("Game Over!");
            this.lossSenceID = SceneManager.GetActiveScene().buildIndex;
            this.isLossed = true;
            Invoke("Restart", restartDelay);
        }
        
    }

    void Restart() {
        // restart to the currently active scene (not always level 1)
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Bye");
    }
}
