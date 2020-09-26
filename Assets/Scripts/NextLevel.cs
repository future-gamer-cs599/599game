using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int levelBuildIndex;
    public void LoadNextLevel() {
        // save player progress
        int levelAt = Math.Max(PlayerPrefs.GetInt("levelAt"), levelBuildIndex + 1);
        PlayerPrefs.SetInt("levelAt", levelAt);
        
        // use build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1) ;
    }
}
