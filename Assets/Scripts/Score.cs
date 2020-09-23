using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    public Transform player; // use Transform instead of GameObject bc only interested in position only
    public Text scoreText;
    private DateTime startTime;

    void Start()
    {
        startTime = DateTime.Now;
    }
    void Update()
    {
        // Debug.Log(player.position.z.ToString("0"));
        // scoreText.text = "Time: " + (DateTime.Now - startTime); 
        // scoreText.text = "Time: " + (DateTime.Now - startTime).ToString("MM/dd/yyyy hh:mm:ss.fff tt"); 
        // TimeSpan time = DateTime.Now - startTime;
        // scoreText.text = String.Format("{0}.{1}", time.Seconds, time.Milliseconds.ToString().PadLeft(3, '0'));
        // scoreText.text = "Time: " + (DateTime.Now - startTime).Seconds.ToString() + " s"; 
        TimeSpan span = (TimeSpan)(DateTime.Now - startTime);
        scoreText.text = String.Format("Time: {0}.{1} s", span.Seconds, span.Milliseconds); 
    }
}
