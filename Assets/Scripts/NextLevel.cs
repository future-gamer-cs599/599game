using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int levelBuildIndex;
    public void LoadNextLevel() {
        // save player progress
        if (PlayerPrefs.GetInt("levelAt") == levelBuildIndex) {
            PlayerPrefs.SetInt("levelAt", levelBuildIndex + 1);
        }

        // use build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1) ;
    }
}
