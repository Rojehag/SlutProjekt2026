using UnityEngine;

public class Physics : MonoBehaviour
{
    //This script is responsible for the player's physics, such as gravity and ground check
    Rigidbody2D playerRb;
    [SerializeField] float gravity = 9.82f;

    //Vector2 to store the player's direction for the gravity and movement
    public Vector2 playerDirection;

    //Ground check to check if the player is on the ground or not
    [SerializeField] GameObject groundCheck;

    //Layer mask to check if the player is colliding with the ground
    [SerializeField] LayerMask groundLayer;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Apply gravity to the player if they are not grounded
        if (!CheckIfGrounded())
        {
            playerDirection.y = gravity * playerRb.mass;
        }
        else
        {
            playerDirection.y = 0;
        }

        //Apply the gravity to the player
        playerRb.AddForce(-playerDirection, ForceMode2D.Force);
    }

    //Check if the player is grounded by using a box cast to check for colliders in the ground layer
    public bool CheckIfGrounded()
    {
        RaycastHit2D[] colliders = Physics2D.BoxCastAll(groundCheck.transform.position, new Vector2(0.5f, 0.2f), 0, Vector2.down, 0.5f, groundLayer);
        return colliders.Length > 0;

    }
}
