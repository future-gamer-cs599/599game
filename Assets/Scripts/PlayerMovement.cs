// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb; // the player rigidbody
    public float forwardForce = 2000f; // forward force in fixedupdate
    public float sidewayForce = 500f; // force moving left or right

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(0, 200, 500);
    }

    // Update is called once per frame
    // use FixedUpdate for physics (add force, etc)
    void FixedUpdate()
    {
        // consider frame rate (different computers have different frame rate)
        // use Time.deltaTime to even out the differences
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (Input.GetKey("d")) {
            // ForceMode
            rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        } else if (Input.GetKey("a")) {
            rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // if the player falls off, restart the game
        if (rb.position.y < -1f) {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
