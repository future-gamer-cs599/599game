﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObj : MonoBehaviour
{
    public float startTime = 0.1f;
    public float repeatRate = 0.3f;
    public GameObject cube;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startTime, repeatRate);
    }

    // Update is called once per frame
    void Spawn()
    {
        Vector3 playerPostion = player.transform.position;
        Instantiate(cube, new Vector3(playerPostion.x + Random.Range(-6,6), 4, playerPostion.z + 15), Quaternion.identity);
    }
}
