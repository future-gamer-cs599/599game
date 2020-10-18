using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public float TurnSpeed = 20f;
    public float JumpSpeed = 0.001f;
    public float ForwardForce = 10f; // forward force in fixedupdate
    public float SidewayForce = 1f; // force moving left or right
    public bool goForward;
    private bool grounded = true;
    private bool isMoving;
    private bool isCrouched;
    private Vector3 playerPos;
    private float crouchTime = 0.0f;
    
    Animator playerAnimator;
    Rigidbody playerRigidbody;
    Vector3 movementVec3;
    Quaternion playerRotation = Quaternion.identity;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        instance = this;
        playerPos = transform.transform.position;
    }

    void Update()
    {

    }
    void FixedUpdate()
    {
        goForward = false;
        isMoving = false;
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

        movementVec3.Set(0, 0, 0f);

        // move left or right
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))&&!isCrouched) {
            movementVec3.x = 1f;
            isMoving = true;
        } else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !isCrouched) {
            movementVec3.x = -1f;
            isMoving = true;
        }

        // move forward or backward
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !isCrouched) {
            movementVec3.z = 1f;
            isMoving = true;
            goForward = true;
        } else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) )&& !isCrouched) {
            movementVec3.z = -1f;
            isMoving = true;
        }

        movementVec3.Normalize();
        playerAnimator.SetBool("IsWalking", true);

        if (Input.GetKey(KeyCode.Space)) {
            Jump();
        }
        Crouch();

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
            // playerRigidbody.AddForce(0f, JumpSpeed, 0f, ForceMode.VelocityChange);
            playerRigidbody.AddForce(Vector3.up * JumpSpeed);
            grounded = false;
        }
    }

    private void Crouch()
    {
        isCrouched = false;
        if (grounded && isMoving == false && Input.GetKey(KeyCode.LeftControl))
        {
            isCrouched = true;
            transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);
        }
        else if (grounded && isMoving == true && Input.GetKey(KeyCode.LeftControl) && (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)))
        {

            transform.eulerAngles = new Vector3(90, 0, 0);
            transform.Translate(0, 0, 25*Time.deltaTime,Space.World);
            crouchTime += Time.deltaTime;
            if (crouchTime >= 1.0f)
            {
                crouchTime = 0.0f;
                grounded = false;
                return;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouchTime = 0.0f;
        }
        //else if(grounded && isMoving == false && Input.GetKeyUp(KeyCode.LeftControl))
        //{
        //    transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
        //    isCrouched = false;
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }
}

// base movement script by yini and jeff

// public class PlayerMovement : MonoBehaviour
// {
//     public Rigidbody rb; // the player rigidbody
//     public float initialForwardForce = 2000f;
//     public float ForwardForce = 10f; // forward force in fixedupdate
//     public float SidewayForce = 1f; // force moving left or right
//     public float jumpForce = 10f; // forward force in fixedupdate
//     public GameObject ground;
//     public float forwardSpeed = 20f;
//     // Start is called before the first frame update
//     void Start()
//     {
//         // rb.AddForce(0, 200, 500);
//     }

//     // Update is called once per frame
//     // use FixedUpdate for physics (add force, etc)
//     void FixedUpdate()
//     {
//         // consider frame rate (different computers have different frame rate)
//         // use Time.deltaTime to even out the differences
//         rb.AddForce(0, 0, initialForwardForce * Time.deltaTime);

//         // use WASD and up down left right to control the player movement  
//         if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
//             rb.AddForce(SidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
//         } else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
//             rb.AddForce(-SidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
//         // } else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
//         //     rb.AddForce(0, 0, ForwardForce * Time.deltaTime, ForceMode.VelocityChange);
//         // } else if (Input.GetKey(KeyCode.S) ||  Input.GetKey(KeyCode.DownArrow)) {
//         //     rb.AddForce(0, 0, -ForwardForce * Time.deltaTime, ForceMode.VelocityChange);
//         } else if (Input.GetKey(KeyCode.Space) ) {
//             rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
//         }

//         // if the player falls off, restart the game
//         if (rb.position.y < -1f) {
//             FindObjectOfType<GameManager>().EndGame();
//         }
//     }
// }