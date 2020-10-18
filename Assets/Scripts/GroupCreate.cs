using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GroupCreate : MonoBehaviour
{
    public float startTime = 0.1f;
    public float repeatRate = 0.5f;
    public GameObject line1;//长钢丝
    public GameObject line2;//短钢丝
    public GameObject cube;//树桩
    public GameObject Clock;//摆锤
    public GameObject player;//玩家

    public static bool continueCreate=true;
    public GameObject fallCube;//掉落物品
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startTime, repeatRate);

    }

    // Update is called once per frame
    void Spawn()
    {
        if (continueCreate)
        {
            Vector3 playerPostion = player.transform.position;
            if (PlayerMovement.instance.goForward)
            {
                switch (Random.Range((int) 1, (int) 6))
                {
                    case 1:
                        Instantiate(line1, new Vector3(-0.25f, 1.5f, playerPostion.z + 15), Quaternion.identity);

                        break;
                    case 2:
                        Instantiate(line2, new Vector3(Random.Range(-2.3f, 2.25f), 1.25f, playerPostion.z + 15),
                            Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(cube, new Vector3(playerPostion.x + Random.Range(-2.5f, 2.5f), 1, playerPostion.z + 15),
                            Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(Clock, new Vector3(0, 20.25f, playerPostion.z + 18),
                            Quaternion.identity);
                        continueCreate = false;
                        break;//当摆锤出现就暂停生成物品
                    case 5:
                        Instantiate(fallCube,
                            new Vector3(playerPostion.x + Random.Range(-6, 6), 5.0f, playerPostion.z + 15),
                            Quaternion.identity);
                        break;
                    default: break;
                }
            }
        }
    }
}