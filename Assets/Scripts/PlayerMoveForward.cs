using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveForward : MonoBehaviour
{
    public float TurnSpeed = 20f;
    public float JumpSpeed = 0.001f;
    public float ForwardForce = 10f; // forward force in fixedupdate
    public float SidewayForce = 1f; // force moving left or right
    private bool grounded = true;
    Animator playerAnimator;
    Rigidbody playerRigidbody;
    Vector3 movementVec3;
    Quaternion playerRotation = Quaternion.identity;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        movementVec3.Set(0, 0, 1f);

        // move left or right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            movementVec3.x = 1f;
        } else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            movementVec3.x = -1f;
        }

        movementVec3.Normalize();
        playerAnimator.SetBool("IsWalking", true);

        if (Input.GetKey(KeyCode.Space)) {
            Jump();
        }

        // if the player falls off, restart the game
        if (playerRigidbody.position.y < -0.5f) {
            FindObjectOfType<GameManager>().EndGame("Fell");
        }
    }

    void OnAnimatorMove()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + 10 * movementVec3 * playerAnimator.deltaPosition.magnitude);
        playerRigidbody.MoveRotation(playerRotation);
    }

    private void Jump()  
    {
        if (grounded)
        {
            playerRigidbody.AddForce(Vector3.up * JumpSpeed);
            grounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }
}