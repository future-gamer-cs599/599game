using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class upBridge : MonoBehaviour
{
    public float speed = 5;
    private bool movingUp = true;

    void FixedUpdate()
    {
        if (movingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            if (transform.position.y >= 4)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            if (transform.position.y <= -4)
            {
                movingUp = true;
            }
        }
    }

}
