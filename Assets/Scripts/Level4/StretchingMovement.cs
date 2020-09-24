using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchingMovement : MonoBehaviour
{
	public bool isStretching = false;
	public float stretchingSpeed = 6f;
    public float cycleTime = 2f;
    public float maxScale = 15f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Stretching());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float scaleChange = (isStretching) ? stretchingSpeed*Time.deltaTime : -stretchingSpeed*Time.deltaTime;
        transform.localScale += new Vector3(scaleChange,0,0);
        transform.localPosition += new Vector3(scaleChange/2,0,0);
        if (transform.localScale[0] >= maxScale)
        {
            isStretching = false;
        }
        else if (transform.localScale[0] <= 0)
        {
            isStretching = true;
        }
    }

    IEnumerator Stretching()
    {
        while (true)
        {
        	// isStretching = !isStretching;

            yield return new WaitForSeconds(cycleTime);

        }
    }

}
