using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public float restartDelay = 2f;
    public GameObject levelCompleteUI;

    public void completeLevel() {
        Debug.Log("complete level");
        levelCompleteUI.SetActive(true);
        
    }

    public void EndGame() {
        // use gameEnded varibale so that line 11 is executed only once
        if (!gameEnded) {
            gameEnded = true;
            Debug.Log("Game Over!");
            Invoke("Restart", restartDelay);
        }
        
    }

    void Restart() {
        // restart to the currently active scene (not always level 1)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
