using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundSway : MonoBehaviour
{
    public float speed = 3;
    private bool movingRight = true;

	  void FixedUpdate ()
    {
        if(movingRight)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            if (transform.position.y >= 3)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            if (transform.position.y <= 0)
            {
                movingRight = true;
            }
        }
	}

}
