using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RockHori : MonoBehaviour
{
    public float speed = 20;
    private bool movingRight = true;

	  void FixedUpdate ()
    {
        if(movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            if (transform.position.x >= 6)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (transform.position.x <= -6)
            {
                movingRight = true;
            }
        }
	}

}
