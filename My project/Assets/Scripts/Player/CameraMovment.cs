using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    //This script is responsible for the camera movement, it follows the player with a smooth damp effect
    Vector3 offset = new Vector3(0,0, -10);
    float smothSpeed = 0.25f;
    Vector3 velocity = Vector3.zero;

    //Transform of the player to follow
    [SerializeField] Transform player;

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smothSpeed);
    }
   
}
