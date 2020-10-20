using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickMove : MonoBehaviour
{
    public float moveSpeed = 30f;
    public float jumpSpeed = 30f;
    protected Joystick joystick;
    protected JoyButton joybutton;
    protected bool jump;
    int JumpCount = 0;
    public int MaxJumps = 1; //Maximum amount of jumps (i.e. 2 for double jumps)
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoyButton>();
        JumpCount = MaxJumps;

    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * moveSpeed + Input.GetAxis("Horizontal") * moveSpeed, rigidbody.velocity.y, joystick.Vertical * moveSpeed + Input.GetAxis("Vertical") * moveSpeed);
        if(!jump && joybutton.Pressed)
        {
            if (JumpCount > 0)
            {
                jump = true;
                rigidbody.velocity += Vector3.up * jumpSpeed;
                JumpCount -= 1;
            }
        }
        if(jump && !joybutton.Pressed)
        {
            jump = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        JumpCount = MaxJumps;
    }

}
