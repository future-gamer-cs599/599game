using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public Transform player;
    public Rigidbody fallingBall;
    public Rigidbody rollingBall;
    public float xOffset = 3f;
    public float yOffsetMin = 2f;
    public float yOffsetMax = 10f;
    public float zOffset = 5f;
    public float fallingStart = 0.5f;
    public float fallingRate = 0.4f;
    public float fallingDuration = 5f;
    public float rollingStart = 7f;
    public float rollingRate = 1f;
    public float rollingDuration = 5f;
    public float xForce = 2f;
    public float yForce = 0f;
    public float zForce = 0f;
    public List<Rigidbody> rollingBalls;
    public List<int> rollingForces;
    public List<Vector3> rollingForceOptions;
    // bool rollingStarted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        InvokeRepeating("SpawnFalling", fallingStart, fallingRate);
        InvokeRepeating("SpawnRolling", rollingStart, rollingRate);
        StartCoroutine("StopFalling");
        StartCoroutine("StopRolling");
        rollingForceOptions.Add(new Vector3(-10, 0, 0));
        rollingForceOptions.Add(new Vector3(10, 0, 0));
        rollingForceOptions.Add(new Vector3(-20, 0, 0));
        rollingForceOptions.Add(new Vector3(20, 0, 0));
    }


    void FixedUpdate() {
        for (int i = 0; i < rollingBalls.Count; i ++) {
            if (rollingBalls[i].position.z > player.position.z) {
                rollingBalls[i].AddForce(rollingForceOptions[rollingForces[i]]);    
            } else {
                Destroy(rollingBalls[i]);
                rollingBalls.RemoveAt(i);
                rollingForces.RemoveAt(i);
            }
        }
    }

    void SpawnRolling() {
        Vector3 playerPostion = player.transform.position;
        Rigidbody ball = Instantiate(rollingBall, new Vector3(playerPostion.x + Random.Range(-xOffset,xOffset), 1, playerPostion.z + zOffset), Quaternion.identity);
        rollingBalls.Add(ball);
        rollingForces.Add(Random.Range(0, rollingForceOptions.Count));
    }

    IEnumerator StopRolling() {
        yield return new WaitForSeconds(rollingStart + rollingDuration);
        CancelInvoke("SpawnRolling");
    }

    IEnumerator StopFalling() {
        yield return new WaitForSeconds(fallingStart + fallingDuration);
        CancelInvoke("SpawnFalling");
    }


    void SpawnFalling() {
        Vector3 playerPostion = player.position;
        Instantiate(fallingBall, new Vector3(playerPostion.x + Random.Range(-xOffset,xOffset), Random.Range(yOffsetMin, yOffsetMax), playerPostion.z + zOffset), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // if the player fails, stop current routine and all scheduled coroutines
        if (FindObjectOfType<GameManager>().getGameEnded()) {
            CancelInvoke("SpawnFalling");
            CancelInvoke("SpawnRolling");
            StopCoroutine("StopFalling");
            StopCoroutine("StopRolling");
        }
    }
}
