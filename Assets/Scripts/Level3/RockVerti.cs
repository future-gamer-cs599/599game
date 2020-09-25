using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RockVerti : MonoBehaviour
{
    public float speed = 10;
    private bool movingUP = true;

	  void FixedUpdate ()
    {
        if(movingUP)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            if (transform.position.y >= 5)
            {
                movingUP = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            if (transform.position.y <= 1)
            {
                movingUP = true;
            }
        }
	}

}
