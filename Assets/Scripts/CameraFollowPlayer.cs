using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 1, -5);

    // Update is called once per frame
    void Update()
    {
        // use 0 vector to appoximate first-person view
        transform.position = player.position + offset;

    }
}
