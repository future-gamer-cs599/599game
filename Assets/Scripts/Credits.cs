using UnityEngine;

public class Credits : MonoBehaviour
{
    public void quit() {
        Debug.Log("quit");
        Application.Quit(); // won't be seen right now in unity but should work once exported
    }
}
