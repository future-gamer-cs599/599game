using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player; // use Transform instead of GameObject bc only interested in position only
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(player.position.z.ToString("0"));
        scoreText.text = player.position.z.ToString("0");
    }
}
