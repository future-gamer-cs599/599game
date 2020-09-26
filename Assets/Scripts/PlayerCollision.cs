using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    void OnCollisionEnter(Collision other){
        if (other.collider.tag == "Obstacle") {
            Debug.Log("It hurts! I'm colliding with: " + other.collider.name);
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
        else if (other.collider.tag == "Block") {
        	Debug.Log("Wrong way! I'm walking towards: " + other.collider.name);
            // movement.enabled = false;
            // FindObjectOfType<GameManager>().EndGame();
        }
    }
}
