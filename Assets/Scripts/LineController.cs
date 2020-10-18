using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LineController : MonoBehaviour
{
    public float startTime = 0.1f;
    public float repeatRate = 0.3f;
    public GameObject line1;
    public GameObject line2;
    public GameObject cube;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (player.transform.position.z + 15 < 100)
        {
            InvokeRepeating("Spawn", startTime, repeatRate);
        }
    }

    // Update is called once per frame
    void Spawn()
    {
        Vector3 playerPostion = player.transform.position;
        switch (Random.Range((int) 1,(int)4))
        {
            case 1: Instantiate(line1, new Vector3(0, 1.5f, playerPostion.z + 15), Quaternion.identity);
                break;
            case 2: Instantiate(line2, new Vector3(Random.Range(-5.5f,5.5f), 1.25f, playerPostion.z + 15), Quaternion.identity);
                break;
            case 3:
                Instantiate(cube, new Vector3(playerPostion.x + Random.Range(-4f, 4f), 1, playerPostion.z + 15),
                    Quaternion.identity);
                break;
            default:break;
        }

    }
}