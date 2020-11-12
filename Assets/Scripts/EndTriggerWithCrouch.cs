using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTriggerWithCrouch : MonoBehaviour
{
    private GameManagerWithCrouch gameManager;
    public GameObject completeUI;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerWithCrouch>();

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
            FindObjectOfType<PlayerMovementWithCrouch>().enabled = false;
            FindObjectOfType<PlayerMoveForwardWithCrouch>().enabled = false;
        }
    }
}
