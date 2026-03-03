using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    //This script is responsible for the player's movement and jump
    Rigidbody2D playerRb;
    //Ground check to check if the player is on the ground or not
    [SerializeField] GameObject groundCheck;

    //Player jump power and speed
    [SerializeField] int playerjumpPower;
    [SerializeField] int playerSpeed = 5;

    //Player direction to check the direction of the player
    [SerializeField] Vector2 playerDirection;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement and jump
        if (Input.GetKey(KeyCode.A))
        {
            Movment(new Vector2(-playerSpeed, playerRb.linearVelocity.y));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Movment(new Vector2(playerSpeed, playerRb.linearVelocity.y));
        }
        else
        {
            playerRb.linearVelocity = new Vector2(0, playerRb.linearVelocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.GetComponent<IsGrounded>().isGrounded)
        {
            MovmentUp(Vector2.up);
        }

       
    }

    //Function to move the player in the direction of the input and speed
    void Movment(Vector2 direction)
    {

        playerRb.linearVelocity = direction;

    }

    //Function to move the player up in the direction of the input and jump power
    void MovmentUp(Vector2 direction)
    {
        playerRb.AddForce(direction * playerjumpPower, ForceMode2D.Impulse);
    }

}
