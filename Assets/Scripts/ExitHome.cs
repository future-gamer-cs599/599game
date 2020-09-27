using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitHome : MonoBehaviour
{
    public int levelScreenIndex;
    // Return to home screen
    public void Home() {
        SceneManager.LoadScene(levelScreenIndex);
    }
}
