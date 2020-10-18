using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject completeUI;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.transform.name == "END")
        {
            if (other.GetComponent<Collider>().name == "Player")
            {

                Debug.Log("end hit");
                completeUI.SetActive(true);
                gameManager.completeLevel();
            }
        }
        else
        {

            gameManager.EndGame();
            FindObjectOfType<PlayerMovement>().enabled = false;
            FindObjectOfType<PlayerMoveForward>().enabled = false;
        }
    }
}
