using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeClockwise : MonoBehaviour
{
    public float rotateSpeed = 0.1f;
    public float initWait = 0f;
    public bool clockwise = true;
    Quaternion temp;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(StartRotate(initWait, rotateSpeed, clockwise));
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(StartRotate(initWait, rotateSpeed, clockwise));
    }



    IEnumerator StartRotate(float delay, float rotateSpeed, bool clockwise)
    {
        yield return new WaitForSeconds(delay);
        temp = transform.localRotation; //get current rotation
        if (clockwise)
        {
            temp.z += Time.deltaTime * rotateSpeed;
        }
        else
        {
            temp.z -= Time.deltaTime * rotateSpeed;
        }
        transform.localRotation = temp;

    }

}
