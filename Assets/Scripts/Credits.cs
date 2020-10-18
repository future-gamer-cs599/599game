using System;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public GameObject win;

    public GameObject loss;
    public void quit() {
        Debug.Log("quit");
        Application.Quit(); // won't be seen right now in unity but should work once exported
    }

    public void Restar()
    {
        GroupCreate.continueCreate = true;
        SceneManager.LoadScene(0,LoadSceneMode.Single);
        GameManager.instance.isLossed = false;
        GameManager.instance.gameEnded = false;
    }

    public void Continue()
    {
        GroupCreate.continueCreate = true;
        SceneManager.LoadScene(GameManager.instance.lossSenceID, LoadSceneMode.Single);
        GameManager.instance.isLossed = false;
        GameManager.instance.gameEnded = false;
    }

    private void Start()
    {
        if (GameManager.instance.isLossed)
        {
            GroupCreate.continueCreate = true;
            GetComponent<Image>().color=Color.red;
            this.loss.SetActive(true);
            this.win.SetActive(false);
        }
        else
        {
            GroupCreate.continueCreate = true;
            GetComponent<Image>().color=Color.white;
            this.win.SetActive(true);
            this.loss.SetActive(false);
        }
    }
}
