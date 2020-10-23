using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

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
        // if the player falls off, restart the game
        if (rigidbody.position.y < -0.5f)
        {
            FindObjectOfType<GameManager>().EndGame("Fell");
        }
        if ((!jump && joybutton.Pressed) || (!jump && Input.GetKeyDown(KeyCode.Space)))
        {
            if (JumpCount > 0)
            {
                jump = true;
                rigidbody.velocity += Vector3.up * jumpSpeed;
                JumpCount -= 1;
                /***********************/
                /****** ANALYTICS ******/
                /***********************/
                // Analytics Log: jump occurrences of a level
                AnalyticsResult jumpAnalytics = Analytics.CustomEvent(
                    "Jump", new Dictionary<string, object> {
                { "Level", SceneManager.GetActiveScene().buildIndex - 1 },
                });
                // Debug: Analytics
                Debug.Log("CustomEvent Jump sent: " + jumpAnalytics);
            }
        }
        if((jump && !joybutton.Pressed) || (jump && !Input.GetKeyDown(KeyCode.J)))
        {
            jump = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        JumpCount = MaxJumps;
    }

}
