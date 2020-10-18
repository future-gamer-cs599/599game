using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void LoadNextLevel() {
        // use build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1) ;
    }
}
