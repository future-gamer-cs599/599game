// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class PushPhysics : MonoBehaviour
{
    public Transform Player;
    public float force = 100f;

    void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Player") {
            Vector3 direction = gameObject.transform.position - other.collider.transform.position;
            gameObject.GetComponent<Rigidbody>().AddForce(direction * force);
        }
    }

}
