using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    

    //This script is responsible for the player's movement and jump
    Rigidbody2D playerRb;

    [Header("Player Locomotion")]
    [SerializeField] int playerjumpPower;
    [SerializeField] int playerSpeed = 5;
    [SerializeField] float acceleration;

    [Header("Particle System")]
    [SerializeField]ParticleSystem particleSystem;


    //Player direction to check the direction of the player
    Vector2 playerDirection;


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
            Movment(new Vector2(-playerSpeed, playerRb.linearVelocity.y),0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Movment(new Vector2(playerSpeed, playerRb.linearVelocity.y), -172);
        }
        else
        {
            particleSystem.Stop();
            Movment(new Vector2(0, playerRb.linearVelocityY),0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && GetComponent<Physics>().CheckIfGrounded())
        {
            MovmentUp();
        }

       
    }

    //Function to move the player in the direction of the input and speed
    void Movment(Vector2 direction, int rotation)
    {
        if (GetComponent<Physics>().CheckIfGrounded() && particleSystem.isStopped) 
        {
            particleSystem.Play();
        }
        particleSystem.transform.rotation = Quaternion.Euler(0, rotation, 0);
        playerRb.linearVelocity = new(Mathf.Lerp(playerRb.linearVelocityX, direction.x, Time.deltaTime * acceleration), direction.y);
    }

    //Function to move the player up in the direction of the input and jump power
    void MovmentUp()
    {
        playerRb.AddForce(Vector2.up * playerjumpPower, ForceMode2D.Impulse);
        particleSystem.Stop();
    }

   
   

      
  
}
