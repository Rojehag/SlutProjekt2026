using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    Vector3 offset = new Vector3(0,0, -10);
    float smothSpeed = 0.25f;
    Vector3 velocity = Vector3.zero;

    [SerializeField] Transform player;

    private void FixedUpdate()
    {
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smothSpeed);
    }
   
}
