using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool moveUp = true;
    public bool moveFlag = true;
    Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(upDown());
    }

    // Update is called once per frame
    void Update()
    {
        temp = transform.localScale;
        if(moveUp == true) {
            temp.y += Time.deltaTime*moveSpeed;
            transform.localScale = temp; 
        }
        else if (moveUp == false) {
            temp.y -= Time.deltaTime* moveSpeed;
            transform.localScale = temp;
        }
    }

    IEnumerator upDown() {
        for (int i =1; i>0; i++)
        {
            print("hello");
            yield return new WaitForSeconds(1f);
            moveUp = false;
            yield return new WaitForSeconds(1f);
            moveUp = true;
        }
    }
}
