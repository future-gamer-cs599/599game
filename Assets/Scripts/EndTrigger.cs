using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name == "Player") {
            Debug.Log("end hit");
            gameManager.completeLevel();    
        }
        
    }
}
