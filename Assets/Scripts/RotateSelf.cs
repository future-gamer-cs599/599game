using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        int i = Random.Range(-1, 1);
        if (i ==0)
        {
            i = 1;
        }
        anim.SetInteger("Dir",i);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
