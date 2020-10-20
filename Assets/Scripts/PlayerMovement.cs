using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float GroundSpeed = 8f;
    public float AirSpeed = 4f;
    public float TurnSpeed = 20f;
    public float JumpSpeed = 300f;
    private bool grounded = true;
    Animator playerAnimator;
    Rigidbody playerRigidbody;
    Vector3 movementVec3;
    Quaternion playerRotation = Quaternion.identity;
    // protected JoyButton joybutton;
    // protected Joystick joystick;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        // joystick = FindObjectOfType<Joystick>();
        // joybutton = FindObjectOfType<JoyButton>();
    }

    void FixedUpdate()
    {
        // float horizontal = Input.GetAxis("Horizontal");
        // float vertical = Input.GetAxis("Vertical");

        // movementVec3.Set(horizontal, 0f, vertical);
        // movementVec3.Normalize();

        // bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        // bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        // bool isWalking = hasHorizontalInput || hasVerticalInput;
        // playerAnimator.SetBool("IsWalking", isWalking);

        // Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movementVec3, TurnSpeed * Time.deltaTime, 0f);
        // playerRotation = Quaternion.LookRotation(desiredForward);

        // test merge to final-test

        movementVec3.Set(0, 0, 0f);

        // move left or right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            movementVec3.x = 1f;
        } else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            movementVec3.x = -1f;
        }

        // move forward or backward
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            movementVec3.z = 1f;
        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            movementVec3.z = -1f;
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
        if(grounded) 
            playerRigidbody.MovePosition(playerRigidbody.position + GroundSpeed * movementVec3 * playerAnimator.deltaPosition.magnitude);
        else 
            playerRigidbody.MovePosition(playerRigidbody.position + AirSpeed * movementVec3 * playerAnimator.deltaPosition.magnitude);
        playerRigidbody.MoveRotation(playerRotation);
    }

    private void Jump()  
    {
        if (grounded)
        {
            // playerRigidbody.AddForce(0f, JumpSpeed, 0f, ForceMode.VelocityChange);
            playerRigidbody.AddForce(Vector3.up * JumpSpeed);
            grounded = false;
        }

        // Analytics Log: jump occurrences of a level
        AnalyticsResult jumpAnalytics = Analytics.CustomEvent(
            "Jump", new Dictionary<string, object> {
                { "Level", SceneManager.GetActiveScene().buildIndex - 1 },
        });
        // Debug: Analytics
        Debug.Log("CustomEvent Jump sent: " + jumpAnalytics);

    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }
}