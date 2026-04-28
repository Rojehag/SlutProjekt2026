using UnityEngine;

public class Physics : MonoBehaviour
{
    Rigidbody2D playerRb;
    [SerializeField] float gravity = 9.82f;
    public Vector2 playerDirection;


        
        
    float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!GetComponent<PlayerMovment>().CheckIfGrounded())
        {
            playerDirection.y = gravity * playerRb.mass;
        }
        else
        {
            playerDirection.y = 0;
        }

        playerRb.AddForce(-playerDirection, ForceMode2D.Force);
    }
}
