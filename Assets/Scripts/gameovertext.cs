using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameovertext : MonoBehaviour
{
    public GameObject GameOverText;
    // Start is called before the first frame update
    void Start()
    {
        GameOverText.SetActive(false);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameOverText.SetActive(true);
        }
    }
}
