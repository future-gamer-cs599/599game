using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.FindWithTag("instructionTag").GetComponent<Text>();
        StartBlinking();
    }

    IEnumerator Blink()
    {
        while (true)
        {
            switch(text.color.a.ToString())
            {
                case "0":
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                    yield return new WaitForSeconds(1f);
                    break;
                case "1":
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
                    yield return new WaitForSeconds(1f);
                    break;
            }
        }
    }
    

    void StartBlinking()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");

    }

    void StopBlinking()
    {
        StopCoroutine("Blink");
    }
}
