using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public Transform player;
    // public Rigidbody fallingBall;
    public Rigidbody[] fallingBalls;
    public Transform[] cubes;
    // public Rigidbody rollingBall;
    bool fallingStarted = false;
    // bool rollingStarted = false;
    float xOffset = 4f;
    float yOffsetMin = 2f;
    float yOffsetMax = 4f;
    float zOffset = 10f;
    float fallingStart = 0.3f;
    public float fallingRate = 0.7f;
    // float rollingRate = 1f;
    int fallStop = 180;
    // int rollStop = 350;
    // List<Rigidbody> rollingBalls = new List<Rigidbody>();
    // List<int> rollingForces = new List<int>();
    // List<Vector3> rollingForceOptions = new List<Vector3>();
    Vector3 previousPlayerPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        // rollingBalls = new List<Rigidbody>();
        player = GameObject.Find("Player").transform;
        InvokeRepeating("SpawnFalling", fallingStart, fallingRate);
        // rollingForceOptions.Add(new Vector3(-10, 0, 0));
        // rollingForceOptions.Add(new Vector3(10, 0, 0));
        // rollingForceOptions.Add(new Vector3(-20, 0, 0));
        // rollingForceOptions.Add(new Vector3(20, 0, 0));
        for (int i = 0; i < 37; i ++) {
            Debug.Log(cubes[i].position.z);
        }
    }

    bool fallingOutOfCube() {
        // float z = player.position.z;
        // float y = player.position.y;
        // for (int i = 0; i < cubes.length; i ++) {
        //     if (z < cubes_z[i] && y < cubes_y[i]) {
        //         return true;
        //     }
        // }
        return false;
    }

    void Update() {
        // if (fallingOutOfCube()) {
        //     FindObjectOfType<GameManager>().EndGame("Fell");
        // }
        
        if (FindObjectOfType<GameManager>().getGameEnded()) {
            CancelInvoke("SpawnFalling");
            // CancelInvoke("SpawnRolling");
        }
        if (player.position.z >= fallStop) {
            // StopFalling
            CancelInvoke("SpawnFalling");
            // if (!rollingStarted) {
            //     rollingStarted = true;
            //     InvokeRepeating("SpawnRolling", 1f, rollingRate);
            // }
        }
        //  else if (player.position.z >= rollStop) {
        //     // StopRolling
        //     CancelInvoke("SpawnRolling");
        // }
    }

    // void FixedUpdate() {
    //     for (int i = 0; i < rollingBalls.Count; i ++) {
    //         if (rollingBalls[i].position.z > player.position.z) {
    //             rollingBalls[i].AddForce(rollingForceOptions[rollingForces[i]]);    
    //         } else {
    //             Destroy(rollingBalls[i]);
    //             rollingBalls.RemoveAt(i);
    //             rollingForces.RemoveAt(i);
    //         }
    //     }
    // }

    // void SpawnRolling() {
    //     Vector3 playerPostion = player.transform.position;
    //     if (previousPlayerPosition.z != playerPostion.z) {
    //         Rigidbody ball = Instantiate(rollingBall, new Vector3(playerPostion.x + Random.Range(-xOffset,xOffset), 1, playerPostion.z + zOffset + 5), Quaternion.identity);
    //         rollingBalls.Add(ball);
    //         rollingForces.Add(Random.Range(0, rollingForceOptions.Count));
    //         previousPlayerPosition = playerPostion;
    //     }
    // }

    void SpawnFalling() {
        Vector3 playerPostion = player.position;
        if (!fallingStarted) {
            fallingStarted = true;
            Instantiate(fallingBalls[Random.Range(0, 12)], new Vector3(playerPostion.x - 3f, Random.Range(yOffsetMin, yOffsetMax), playerPostion.z + zOffset), Quaternion.identity);
            return;
        }
        if (previousPlayerPosition.z != playerPostion.z) {
            Instantiate(fallingBalls[Random.Range(0, 12)], new Vector3(playerPostion.x + Random.Range(-xOffset,xOffset), Random.Range(yOffsetMin, yOffsetMax), playerPostion.z + zOffset), Quaternion.identity);
            previousPlayerPosition = playerPostion;
        }
        
    }

}