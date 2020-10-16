// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     Vector3 movement;
//     Rigidbody playerRigidbody;
//     Animator animator;

//     // player移动速度
//     public float speed = 6f;

//     private float x;
//     private float y;
//     private float xSpeed = 2;
//     private float ySpeed = 2;
//     private Quaternion direct; // player direct

//     // 判断是否落地
//     private bool grounded = true;

//     void Awake()
//     {
//         playerRigidbody = GetComponent<Rigidbody>();
//         animator = GetComponent<Animator>();
//     }

//     void Update() {
//         // keyboard move
//         float h = Input.GetAxisRaw("Horizontal"); // A D
//         float v = Input.GetAxisRaw("Vertical");   // W S

//         // animating
//         bool walking = h != 0f || v != 0f;
//         animator.SetBool("Forward", walking);

//         transform.Translate(Vector3.forward * v * speed * Time.deltaTime); // W S 上 下
//         transform.Translate(Vector3.right * h * speed * Time.deltaTime); // A D 左右

//         // Jump
//         if (Input.GetButtonDown("Jump")) {
//             if (grounded == true)
//             {
//                 animator.SetBool("Jump", true);
//                 playerRigidbody.velocity += new Vector3(0, 5, 0); //添加加速度
//                 playerRigidbody.AddForce(Vector3.up * 50); //给刚体一个向上的力，力的大小为Vector3.up*mJumpSpeed
//                 grounded = false;
//             }
//         }


//         // mouse move
//         x += Input.GetAxis("Mouse X") * xSpeed;
//         y -= Input.GetAxis("Mouse Y") * ySpeed;

//         direct = Quaternion.Euler(y, x, 0);
//         transform.rotation = direct;
//     }

//     // 落地检测
//     void OnCollisionEnter(Collision collision) {
//         animator.SetBool("Jump", false);
//         grounded = true;
//     }
// }

public class CubePlayerMovement : MonoBehaviour
{
    public Rigidbody rb; // the player rigidbody
    public float initialForwardForce = 2000f;
    public float forwardForce = 10f; // forward force in fixedupdate
    public float sidewayForce = 1f; // force moving left or right
    public float jumpForce = 10f; // forward force in fixedupdate
    public GameObject ground;
    public float forwardSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        // rb.AddForce(0, 200, 500);
    }

    // Update is called once per frame
    // use FixedUpdate for physics (add force, etc)
    void FixedUpdate()
    {
        // consider frame rate (different computers have different frame rate)
        // use Time.deltaTime to even out the differences
        rb.AddForce(0, 0, initialForwardForce * Time.deltaTime);

        // use WASD and up down left right to control the player movement  
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        } else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        // } else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
        //     rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        // } else if (Input.GetKey(KeyCode.S) ||  Input.GetKey(KeyCode.DownArrow)) {
        //     rb.AddForce(0, 0, -forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        } else if (Input.GetKey(KeyCode.Space) ) {
            rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }

        // if the player falls off, restart the game
        if (rb.position.y < -1f) {
            FindObjectOfType<GameManager>().EndGame("Fell");
        }
    }
}
