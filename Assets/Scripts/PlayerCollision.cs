using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    void OnCollisionEnter(Collision other){
        if (other.collider.tag == "Obstacle") {
            Debug.Log("obstacle encountered");
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
