using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cylinderRotate : MonoBehaviour
{
    public float rotateSpeed = 360f;
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
        //StartCoroutine(StartRotate(initWait, rotateSpeed, clockwise));
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }



    IEnumerator StartRotate(float delay, float rotateSpeed, bool clockwise)
    {
        yield return new WaitForSeconds(delay);
        temp = transform.localRotation; //get current rotation
        if (clockwise)
        {
            
            temp.y += Time.deltaTime * rotateSpeed;
        }
        else
        {
            temp.y -= Time.deltaTime * rotateSpeed;
            
        }
        if (temp.y > 360.0f)
        {
            temp.y = 0.0f;
        }
        transform.localRotation = temp;

    }
}
