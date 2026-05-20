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

    [Header("Animation")]
    [SerializeField] Animator playerAnim;


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
            Movment(new Vector2(-playerSpeed, playerRb.linearVelocity.y),0,180, true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Movment(new Vector2(playerSpeed, playerRb.linearVelocity.y), -172,0, true);
        }
        else
        {
            particleSystem.Stop();
            Movment(new Vector2(0, playerRb.linearVelocityY),100,100, false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && GetComponent<Physics>().CheckIfGrounded())
        {
            MovmentUp();
        }

       
    }

    //Function to move the player in the direction of the input and speed
    void Movment(Vector2 direction, int rotation, int rotationZ , bool animation)
    {
        if (GetComponent<Physics>().CheckIfGrounded()&& particleSystem.isStopped) 
        {
            particleSystem.Play();
            
        }
        else if (!GetComponent<Physics>().CheckIfGrounded() && particleSystem.isPlaying)
        {
            particleSystem.Stop();
            playerAnim.SetBool("PlayerRun", false);
        }
        if(rotationZ!= 100)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, rotationZ, 0);
            particleSystem.transform.rotation = Quaternion.Euler(0, rotation, 0);
        }

        if(animation)
        {
            playerAnim.SetBool("PlayerRun", true);
        }else
        {
            playerAnim.SetBool("PlayerRun", false);
        }

        
        playerRb.linearVelocity = new(Mathf.Lerp(playerRb.linearVelocityX, direction.x, Time.deltaTime * acceleration), direction.y);
    }

    //Function to move the player up in the direction of the input and jump power
    void MovmentUp()
    {
        playerRb.AddForce(Vector2.up * playerjumpPower, ForceMode2D.Impulse);
        particleSystem.Stop();
    }

   
   

      
  
}
