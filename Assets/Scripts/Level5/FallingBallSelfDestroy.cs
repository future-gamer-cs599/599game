using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBallSelfDestroy : MonoBehaviour
{
    void OnBecameInvisible(){
        Debug.Log("destroy");
        Destroy(this.gameObject);
    }
}
