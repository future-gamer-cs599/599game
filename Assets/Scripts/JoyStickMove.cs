using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class JoyStickMove : MonoBehaviour
{
    public AudioSource jumpSound;
    public float moveSpeed = 30f;
    public float jumpSpeed = 30f;
    protected Joystick joystick;
    protected JoyButton joybutton;
    protected bool jump;
    int JumpCount = 0;
    public int MaxJumps = 1; //Maximum amount of jumps (i.e. 2 for double jumps)

    public float TurnSpeed = 40f;
    Quaternion playerRotation = Quaternion.identity;

    public AudioSource fallSound;
    public CanvasGroup FallImageCanvasGroup;
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    bool m_IsPlayerFall;
    float m_Timer;

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
        var rigidbody = GetComponent<Rigidbody>(); // get rigidbody of the player

        // change valocity according to input from keyboard or joystick
        GetComponent<Rigidbody>().velocity = new Vector3(
            joystick.Horizontal * moveSpeed + Input.GetAxis("Horizontal") * moveSpeed, 
            GetComponent<Rigidbody>().velocity.y, 
            joystick.Vertical * moveSpeed + Input.GetAxis("Vertical") * moveSpeed
        );

        // move rotation
        float horizontal = joystick.Horizontal + Input.GetAxis("Horizontal");
        float vertical = joystick.Vertical + Input.GetAxis("Vertical");
        Vector3 movementVec3 = new Vector3();
        movementVec3.Set(horizontal, 0f, vertical);
        movementVec3.Normalize();
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movementVec3, TurnSpeed * Time.deltaTime, 0f);
        playerRotation = Quaternion.LookRotation(desiredForward);
        rigidbody.MoveRotation(playerRotation);

        // if the player falls off, restart the game
        if (SceneManager.GetActiveScene().buildIndex != 6 && GetComponent<Rigidbody>().position.y < -0.5f)
        {
            if (!m_IsPlayerFall) {
                m_IsPlayerFall = true;
                fallSound.Play();
            }
            Fall();
        }

        // jump 
        if ((!jump && joybutton.Pressed) || (!jump && Input.GetKeyDown(KeyCode.Space)))
        {
            
            if (JumpCount > 0)
            {
                jump = true;
                GetComponent<Rigidbody>().velocity += Vector3.up * jumpSpeed;
                JumpCount -= 1;
                jumpSound.Play();
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

    void Fall() {     
        m_Timer += Time.deltaTime;
        FallImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration) {
            Debug.Log("player fell");
            FindObjectOfType<GameManager>().EndGame("Fell");
        }
    }    

}
