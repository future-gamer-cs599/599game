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
        TimeSpan span = (TimeSpan)(DateTime.Now - startTime);
        scoreText.text = String.Format("Time: {0}.{1} s", span.Seconds, span.Milliseconds); 
    }
}
