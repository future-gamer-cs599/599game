using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOn : MonoBehaviour
{
    Transform player;
    float upperBound;
    float lowerBound;
    public float upperBufferSpace;
    public float lowerBufferSpace;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        upperBound = gameObject.transform.position.z + gameObject.transform.localScale.z / 2 + upperBufferSpace;
        lowerBound = gameObject.transform.position.z - gameObject.transform.localScale.z / 2 + lowerBufferSpace;
    }

    // Update is called once per frame
    void Update()
    {
        float player_z = player.transform.position.z;
        if (player_z >= lowerBound && player_z <= upperBound && player.transform.position.y < gameObject.transform.position.y) {
            Debug.Log("failed");
            FindObjectOfType<GameManager>().EndGame("Fell");
        }
    }
}
