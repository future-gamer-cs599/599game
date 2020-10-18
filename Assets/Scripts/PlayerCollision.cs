using System;
using System.Collections.Generic;

using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    public PlayerMoveForward moveForward;

    private List<GameObject> gameManagers=new List<GameObject>();

    private void Start()
    {
        foreach (var VARIABLE in GameObject.FindGameObjectsWithTag("GameManager"))
        {
            this.gameManagers.Add(VARIABLE);
        }

        for (int i = 0; i < this.gameManagers.Count-1; i++)
        {
            Destroy(this.gameManagers[i]);
        }
    }

    void OnCollisionEnter(Collision other){
        if (other.collider.tag == "Obstacle") {
            Debug.Log("obstacle encountered");
            movement.enabled = false;
            moveForward.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Obstacle")
        {
            Debug.Log("obstacle encountered");
            movement.enabled = false;
            moveForward.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CanKill")
        {
            Invoke("ContinueCreate",0.5f);
        }
    }

    void ContinueCreate()
    {
        GroupCreate.continueCreate = true;
    }
}
